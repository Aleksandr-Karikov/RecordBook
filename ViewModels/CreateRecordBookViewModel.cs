using RecordBook.DataBase;
using RecordBook.DataBase.DataModels;
using RecordBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecordBook.ViewModels
{
    internal class CreateRecordBookViewModel:INotifyPropertyChanged
    {
        private string _fio;
        private int _numbrerRB;
        private int _course;
        private string _spec;
        private string _univer;
        private string _group;

        public List<string> Courses { get; set; } = new List<string>
        {
            "1", "2", "3", "4", "5"
        };

        private RelayCommand _createCommand;
        public string University
        {
            get => _univer;
            set
            {
                _univer = value;
                OnPropertyChanged(nameof(University));
            }
        }
        public string Speciality
        {
            get => _spec;
            set
            {
                _spec = value;
                OnPropertyChanged(nameof(Speciality));
            }
        }
        public string Fio
        {
            get => _fio;
            set
            {
                _fio = value;
                OnPropertyChanged(nameof(Fio));
            }
        }

        public int NumberRecordBook
        {
            get => _numbrerRB;
            set
            {
                _numbrerRB = value;
                OnPropertyChanged(nameof(NumberRecordBook));
            }
        }

        public int Course
        {
            get => _course;
            set
            {
                _course = value;
                OnPropertyChanged(nameof(Course));
            }
        }



        public string Group
        {
            get => _group;
            set
            {
                _group = value;
                OnPropertyChanged(nameof(Group));
            }
        }
        private RecordBkContext context;
        public CreateRecordBookViewModel(RecordBkContext context)
        {
            this.context = context;
        }

        public RelayCommand CreateCommand { get => _createCommand ?? (_createCommand = new RelayCommand(obj => Create())); }

        private void Create()
        {
            try
            {
                context.Recordbooks.Add(new RecordBk()
                {
                    Name = Fio,
                    Group = this.Group,
                    Course = this.Course,
                    Speciality = this.Speciality,
                    University = this.University,
                    ID = NumberRecordBook
                     
                });
                context.SaveChanges();
                MessageBox.Show("Зачетная книжка создана!");

                var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                window.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно создать зачетку! Возможно, данные не введены, или введены не корректно.");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
