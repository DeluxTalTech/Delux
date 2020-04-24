using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Delux.Aids {
    public static class GetClass {
        private const string G = "get_";
        private const string S = "set_";
        private const string A = "add_";
        private const string R = "remove_";
        private const string C = ".ctor";
        private const string V = "value__";
        private const string T = "+TestClass";
        public static string Namespace(Type type) {
            return type is null ? string.Empty : type.Namespace;
        }
        public static List<MemberInfo> Members(Type type,
            BindingFlags f = PublicBindingFlagsFor.AllMembers,
            bool clean = true) {
            if (type is null) return new List<MemberInfo>();
            var l = type.GetMembers(f).ToList();
            if (clean) RemoveSurrogates(l);
            return l;
        }
        public static List<PropertyInfo> Properties(Type type,
            BindingFlags f = PublicBindingFlagsFor.AllMembers) {
            return type?.GetProperties(f).ToList() ?? new List<PropertyInfo>();
        }
        public static PropertyInfo Property<T>(string name) {
            return Safe.Run(() => typeof(T).GetProperty(name), null);
        }
        public static PropertyInfo Property<T>(Expression<Func<T, object>> ex) {
            var name = GetMember.Name(ex);
            return Safe.Run(() => typeof(T).GetProperty(name), null);
        }
        private static void RemoveSurrogates(IList<MemberInfo> l) {
            for (var i = l.Count; i > 0; i--) {
                var m = l[i - 1];
                if (!IsSurrogate(m)) continue;
                l.RemoveAt(i - 1);
            }
        }
        private static bool IsSurrogate(MemberInfo m) {
            var n = m.Name;
            if (string.IsNullOrEmpty(n)) return false;
            if (n.Contains(G)) return true;
            if (n.Contains(S)) return true;
            if (n.Contains(A)) return true;
            if (n.Contains(R)) return true;
            if (n.Contains(V)) return true;
            return n.Contains(T) || n.Contains(C);
        }
        public static List<object> ReadWritePropertyValues(object obj) {
            var l = new List<object>();
            if (obj is null) return l;
            foreach (var p in Properties(obj.GetType())) {
                if (!p.CanWrite) continue;
                AddValue(p, obj, l);
            }
            return l;
        }
        private static void AddValue(PropertyInfo p, object o, List<object> l) {
            var indexer = p.GetIndexParameters();
            if (indexer.Length == 0 ) l.Add(p.GetValue(o));
            else {
                var i = 0;
                while (true) {
                    try {
                        l.Add(p.GetValue(o, new object[] {i++}));
                    }
                    catch {
                        l.Add(i);
                        return;
                    }
                }
            }
        }

    }
}





