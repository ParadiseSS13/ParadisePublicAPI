using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class InstanceDataCache
    {
        public string ServerId { get; set; } = null!;
        public string KeyName { get; set; } = null!;
        public string KeyValue { get; set; } = null!;
        public DateTime LastUpdated { get; set; }
    }
}
