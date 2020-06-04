using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models
{
    public class ViewTeacherDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string matter { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public int teacherID { get; set; }
    }
}
