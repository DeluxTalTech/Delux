using System.Reflection;

namespace Delux.Aids {

    public static class PublicBindingFlagsFor {
        private const BindingFlags P = BindingFlags.Public;
        private const BindingFlags I = BindingFlags.Instance;
        private const BindingFlags S = BindingFlags.Static;
        private const BindingFlags D = BindingFlags.DeclaredOnly;
        public const BindingFlags AllMembers = P | I | S;
        public const BindingFlags InstanceMembers = P | I;
        public const BindingFlags StaticMembers = P | S;
        public const BindingFlags DeclaredMembers = P | D | I | S;
    }

}




