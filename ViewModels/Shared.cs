using RecordBook.DataBase;
using RecordBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecordBook.ViewModels
{
    internal abstract class  Shared : INotifyPropertyChanged
    {
        private RelayCommand _filterRecordBookCommand;
        protected RecordBkContext context;
        public Shared(RecordBkContext context)
        {
            this.context = context;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<RecBook> RecordBooks { get; set; } =
            new ObservableCollection<RecBook> { };

        public ObservableCollection<RecBook> RecordBooksChoosen { get; set; } =
            new ObservableCollection<RecBook> { };
        public ObservableCollection<string> Terms { get; set; }
            = new ObservableCollection<string> { };

        private string _choosen;
        public string ChoosenRecordBook
        {
            get => _choosen;
            set
            {
                _choosen = value;
                OnPropertyChanged(nameof(ChoosenRecordBook));
            }
        }
        protected void UpdateRecordBooks()
        {
            RecordBooks.Clear();
            RecordBooksChoosen.Clear();



            var books = context.Recordbooks.ToList();

            if (books == null) return;
            foreach (var book in books)
            {
                int numberRB = book.ID;
                string name = book.Name;
                int course = book.Course;
                string univer = book.University;
                string group = book.Group;
                string spec = book.Speciality;

                RecordBooks.Add(new RecBook(numberRB, name, course, group, univer,spec,context));
                RecordBooksChoosen.Add(new RecBook(numberRB, name, course, group, univer, spec, context));
            }

            
        }
        public RelayCommand FilterRecordBookCommand { get => _filterRecordBookCommand ?? (_filterRecordBookCommand = new RelayCommand(obj => FilterRecordBook(obj))); }
        private void FilterRecordBook(object obj)
        {
            string searchedString = obj as string;

            if (!string.IsNullOrWhiteSpace(searchedString) || !string.IsNullOrWhiteSpace(ChoosenRecordBook))
            {
                if (string.IsNullOrWhiteSpace(searchedString))
                    searchedString = ChoosenRecordBook;

                RecordBooksChoosen.Clear();
                Terms.Clear();

                try
                {
                    foreach (var item in RecordBooks)
                    {
                        if (item.FIO.ToLower().Contains(searchedString.ToLower()) ||
                            item.Group.ToLower().Contains(searchedString.ToLower()) ||
                            item.Number.ToString().Contains(searchedString.ToLower()))
                        {
                            RecordBooksChoosen.Add(item);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                ChoosenRecordBook = "";
            }
            else
            {
                UpdateRecordBooks();
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
