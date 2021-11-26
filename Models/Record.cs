using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordBook.Models
{
    public class Record
    {
        public int NumberRB { get; set; }
        public string Term { get; set; }
        public string NameSubject { get; set; }
        public int CountHours { get; set; }
        public string Mark { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Teacher { get; set; }
        public Record(int number, string term, string nameSub, int countHours, string mark, DateTime date, string type,string teacher)
        {
            NumberRB = number;
            Term = term;
            NameSubject = nameSub;
            CountHours = countHours;
            Mark = mark;
            Date = date;
            Type = type;
            Teacher = teacher;
        }
    }
}
