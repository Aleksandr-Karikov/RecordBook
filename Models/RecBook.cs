using Microsoft.EntityFrameworkCore;
using RecordBook.DataBase;
using RecordBook.DataBase.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecordBook.Models
{
    public class RecBook: INotifyPropertyChanged
    {

        private RecordBkContext context;
        public RecBook(int number, string fio, int course, string group, string nameDeputyHead,RecordBkContext context)
        {
            this.context = context;
            FIO = fio;
            Number = number;
            Course = course;
            Group = group;
            NameDeputyHead = nameDeputyHead;
        }
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private string _fio;

        public string FIO
        {
            get => _fio;
            set
            {
                _fio = value;
                OnPropertyChanged(nameof(FIO));
            }
        }

        private int _course;
        public int Course
        {
            get => _course;
            set
            {
                _course = value;
                OnPropertyChanged(nameof(Course));
            }
        }
        private string _group;
        public string Group
        {
            get => _group;
            set
            {
                _group = value;
                OnPropertyChanged(nameof(Group));
            }
        }
        public int Number { get; set; }
        public string NameDeputyHead { get; set; }

        public List<Record> Records = new List<Record> { };
        public void UpdateRecords()
        {
            Records.Clear();

            var marks = context.Marks.Where(x => x.RecordBkID == Number);

            foreach (var mark in marks)
            {
                int number = mark.RecordBkID;
                string term = mark.Term;
                string subject = mark.Subject;
                int hours = mark.Hours;
                DateTime date = mark.Date;
                string type = mark.Type;
                string teacher = mark.Teacher;
                Records.Add(new Record(number, term, subject, hours, mark.mark, date, type,teacher));
            }
        }

        public void AddMark(string term, string nameSubject, int countHours, string mark, string _date, string _type)
        {
            try
            {
                DateTime date = default;
                if (_date != null && _date != "")
                    date = DateTime.Parse(_date);

                if (String.IsNullOrEmpty(_date) && String.IsNullOrEmpty(mark))
                    context.Marks.Add(new Mark() { RecordBkID = Number, Hours = countHours, Term = term, Subject = nameSubject, Type = _type});
                else if (String.IsNullOrEmpty(_date))
                    context.Marks.Add(new Mark() { RecordBkID = Number, Hours = countHours, Term = term, Subject = nameSubject, Type = _type, mark = mark });
                else if (String.IsNullOrEmpty(mark))
                    context.Marks.Add(new Mark() { RecordBkID = Number, Hours = countHours, Term = term, Subject = nameSubject, Type = _type,Date=date });
                else
                context.Marks.Add(new Mark() { RecordBkID = Number, Hours = countHours, Term = term, Subject = nameSubject, Type = _type, mark = mark, Date = date });
                context.SaveChanges();
                UpdateRecords();
                MessageBox.Show("Оценка занесена в зачетную книжку!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void EditMark(string mark, string subject, string term)
        {
            var rec = context.Marks.FirstOrDefault(x => x.Subject == subject && x.Term == term && x.RecordBkID == Number);
            rec.mark = mark;
            context.SaveChanges();
            MessageBox.Show($"Оценка исправлена");
        }
        public void EditDate(string _date, string subject, string term)
        {
            DateTime date = default;
            if (_date != null && _date != "")
                date = DateTime.Parse(_date);
            var rec = context.Marks.FirstOrDefault(x => x.Subject == subject && x.Term == term && x.RecordBkID == Number);
            rec.Date= date;
            UpdateRecords();
            context.SaveChanges();
            MessageBox.Show($"Исправление даты");
        }
        public void ToNextCourse()
        {
            if (Course < 5)
            {
                Course++;

                var rec = context.Recordbooks.FirstOrDefault(x => x.ID == Number);
                rec.Course = Course;
                context.SaveChanges();
                UpdateRecords();
                MessageBox.Show($"Студент {FIO} переведен на {Course} курс!");
            }
            else
            {
                MessageBox.Show("Студент учится на выпускном курсе!");
            }
        }

    }
}
