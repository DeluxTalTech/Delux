﻿using System.Globalization;

namespace Delux.Aids {
    public class UseCulture
    {
        public static CultureInfo Current => CultureInfo.CurrentCulture;
        public static CultureInfo English => new CultureInfo("en-GB");
        public static CultureInfo Invariant => CultureInfo.InvariantCulture;
    }
}