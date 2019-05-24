using Eds.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.Common.Attributes
{
    public class TableAttribute : Attribute
    {

        public string TableName { get; set; }
        public string ViewName { get; set; }
        public string TableDesc { get; set; }
        public bool IsLogicValid { get; set; }
        public DataEntityPrimaryKeyValueModes KeyMode { get; set; }
    }
}
