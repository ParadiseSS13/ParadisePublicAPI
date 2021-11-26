using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Customuseritem
    {
        public int Id { get; set; }
        public string CuiCkey { get; set; } = null!;
        public string CuiRealName { get; set; } = null!;
        public string CuiPath { get; set; } = null!;
        public string? CuiItemName { get; set; }
        public string? CuiDescription { get; set; }
        public string? CuiReason { get; set; }
        public string? CuiPropAdjust { get; set; }
        public string CuiJobMask { get; set; } = null!;
    }
}
