namespace Delux.Aids {
    public class IsRunning {

        private const string TestFramework = "Microsoft.VisualStudio.QualityTools.UnitTestFramework";
        private const string UnitTesting = "Microsoft.VisualStudio.TestPlatform";

        public static bool Namespace(string name) {
            if (string.IsNullOrEmpty(name)) return false;
            return
                Safe.Run(() => {
                    var assemblies = GetSolution.Assemblies;
                    foreach (var a in assemblies) { if (a.FullName.StartsWith(name)) return true; }
                    return false;
                }, false);
        }
        public static bool Tests(bool ignore = false) {
            return !ignore && (
                       Namespace(TestFramework) || Namespace(UnitTesting));
        }
    }
}
