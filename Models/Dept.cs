using System;
using System.Collections.Generic;

namespace TestSqliteCore.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emps = new HashSet<Emp>();
        }

        public string DeptNo { get; set; } = null!;
        public string DeptName { get; set; } = null!;

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
