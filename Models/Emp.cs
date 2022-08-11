using System;
using System.Collections.Generic;

namespace TestSqliteCore.Models
{
    public partial class Emp
    {
        public string EmpNo { get; set; } = null!;
        public string EmpName { get; set; } = null!;
        public long Age { get; set; }
        public string? DeptNo { get; set; }

        public virtual Dept? DeptNoNavigation { get; set; }
    }
}
