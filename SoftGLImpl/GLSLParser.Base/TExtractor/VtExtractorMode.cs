using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// how to deal with extractor items for Vt symbols ?
    /// </summary>
    public enum VtExtractorMode {
        /// <summary>
        /// one uniform fixed extractor item for all Vt symbols
        /// </summary>
        SingleFixed,
        /// <summary>
        /// one uniform user-defined extractor item for all Vt symbols
        /// </summary>
        Single,
        /// <summary>
        /// ignore Vt symbols at all.
        /// </summary>
        Omit,
        /// <summary>
        /// speicifies an extractor-item for each Vt symbol.
        /// </summary>
        Each,
    }
}
