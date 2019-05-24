using Eds.Common.Attributes;
using Eds.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eds.Common.Models
{
    public class BaseDataEntity
    {

        [Column(LogicName = "序号", FieldType = DataEntityFieldType.Logic)]
        public int RowIndex { get; set; }
        [Column(Name = "UPDATEDATE", FiledValueRule = DataEntityFieldValueRuleSets.CurTime)]
        public DateTime? UpdateDate { get; set; }
        [Column(Name = "UPDATEMAN", FiledValueRule = DataEntityFieldValueRuleSets.CurOpPersonId)]
        public string UpdateMan { get; set; }
        [Column(Name = "CREATEDATE", FiledValueRule = DataEntityFieldValueRuleSets.CurTime, UpdateMode = DataEntityFieldDMLActions.Create)]
        public DateTime? CreateDate { get; set; }
        [Column(Name = "CREATEMAN", FiledValueRule = DataEntityFieldValueRuleSets.CurOpPersonId, UpdateMode = DataEntityFieldDMLActions.Create)]
        public string CreateMan { get; set; }
    }
}
