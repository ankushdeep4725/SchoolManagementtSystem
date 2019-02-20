using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementtSystem.Models
{
    public class StudentMaster
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
        public ClassMaster ClassMaster { get; set; }
        public int TeacherId { get; set; }
        public TeacherMaster TeacherMaster { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

    }
}