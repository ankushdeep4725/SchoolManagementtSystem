using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementtSystem.Models
{
    public class ClassMaster
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public List<StudentMaster> StudentMasters { get; set; }
    }
}