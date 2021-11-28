using Microsoft.Data.SqlClient;
using RecordBook.DataBase;
using RecordBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecordBook.ViewModels
{
    internal class EditViewModel:Shared
    {
        public List<string> Marks { get; set; } = new List<string>
        {
            "2", "3", "4", "5"
        };

        public ObservableCollection<string> Subjects { get; set; } = new ObservableCollection<string> { };

        private string _currentTerm;
        public string CurrentTerm
        {
            get => _currentTerm;
            set
            {
                _currentTerm = value;
                SetSubjects();
            }
        }

        private string _mark;
        public string Mark
        {
            get => _mark;
            set => _mark = value;
        }

        public string Subject { get; set; }

        private RelayCommand _editCommand;


        private RecBook _selectedRB;
        public RecBook SelectedRB
        {
            get => _selectedRB;
            set
            {
                _selectedRB = value;
                SetTerms();
                OnPropertyChanged(nameof(SelectedRB));
            }
        }

        private string _date;
        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public RelayCommand EditCommand { get => _editCommand ?? (_editCommand = new RelayCommand(obj => Edit())); }
        
        public EditViewModel(RecordBkContext context, ICollection<RecBook> recordBooks):base(context)
        {
            foreach (var item in recordBooks)
            {
                RecordBooks.Add(item);
                RecordBooksChoosen.Add(item);
            }
        }

        private void SetSubjects()
        {
            var Marks = context.Marks.Where(x => x.RecordBkID == SelectedRB.Number && x.Term == CurrentTerm).ToList();

            Subjects.Clear();
            foreach(var mark in Marks)
            {
                Subjects.Add(mark.Subject);
            }
        }

        private void SetTerms()
        {
            string command = $"select distinct Term from Marks where RecordBkID='{SelectedRB.Number}'";
            SqlConnection _sqlConnection = new SqlConnection("Server=(local)\\sqlexpress;Database=RecordBook;Trusted_Connection=True;");
            SqlCommand sqlCommand = new SqlCommand(command, _sqlConnection);
            _sqlConnection.Open();
            Terms.Clear();
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Terms.Add(reader.GetValue(0) as string);
                }
            }
            _sqlConnection.Close();
        }

        private void Edit()
        {
            try
            {
                if (String.IsNullOrEmpty(Date) && String.IsNullOrEmpty(Mark))
                    throw new Exception("Введите данные!");

                if (!String.IsNullOrEmpty(Mark))
                    SelectedRB.EditMark(Mark, Subject, CurrentTerm);

                if (!String.IsNullOrEmpty(Date))
                    SelectedRB.EditDate(Date, Subject, CurrentTerm);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
