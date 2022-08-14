using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1264688.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}