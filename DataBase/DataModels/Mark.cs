using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordBook.DataBase.DataModels
{
    public class Mark
    {
        public int ID { get; set; }
        public string mark { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public string Subject { get; set; }
        public string Term { get; set; }
        public string Type { get; set; }
        public int RecordBkID{ get; set; }
        public RecordBk recordBk { get; set; }
        public string Teacher { get; set; }
    }
}
