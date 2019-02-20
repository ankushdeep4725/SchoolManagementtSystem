using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementtSystem.Models
{
    public class ViewModel
    {
        public IEnumerable<ClassMaster> ClassMastersss { get; set; }
        public IEnumerable<TeacherMaster> TeacherMastersss { get; set; }
    }
}