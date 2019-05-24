using Eds.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ColumnAttribute : Attribute
    {

        public bool IsPrimaryKey { get; set; }
        public bool IsPrimaryText { get; set; }
        public bool IsViewerIgnore { get; set; }
        public bool IsModelIgnore { get; set; }
        public string Name { get; set; }
        public string LogicName { get; set; }
        public string JsonName { get; set; }
        public DataEntityFieldType FieldType { get; set; }
        public DataEntityFieldValueRuleSets FiledValueRule { get; set; }
        public DataEntityFieldDMLActions UpdateMode { get; set; }
    }
}
