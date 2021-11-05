using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEF.Interfaces
{
    interface IStudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool isDeleted { get; set; }
        
    }
}
