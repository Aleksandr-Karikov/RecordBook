using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordBook.DataBase.DataModels
{
    public class RecordBk
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string University { get; set; }
        private string Group { get; set; }
        public string Speciality { get; set; }
        public int Course { get; set; }
    }
}
