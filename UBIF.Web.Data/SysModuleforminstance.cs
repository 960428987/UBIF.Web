using System;
using System.Collections.Generic;

namespace UBIF.Web.Data
{
    public partial class SysModuleforminstance
    {
        public string FId { get; set; }
        public string FFormId { get; set; }
        public string FObjectId { get; set; }
        public string FInstanceJson { get; set; }
        public int? FSortCode { get; set; }
        public DateTime? FCreatorTime { get; set; }
        public string FCreatorUserId { get; set; }

        public SysModuleform F { get; set; }
    }
}
