using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementtSystem.Models
{
    public class TeacherMaster
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Qualification { get; set; }
        public List<StudentMaster> StudentMasters { get; set; }
        
    }
}