using Microsoft.Data.SqlClient;
using RecordBook.DataBase;
using RecordBook.Models;
using RecordBook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecordBook.ViewModels
{
    internal class RecBookViewModel :Shared
    {

        public RecBookViewModel(RecordBkContext context):base(context)
        {
            UpdateRecordBooks();
            
        }
        // private AgreeWindow _agreeWindow;
        private RecBook _current;
        private string _currentTerm = "1 семестр";
        private int _termNumber = 1;
        private RelayCommand _createRecordBookCommand;
        private RelayCommand _addMarkCommand;
        private RelayCommand _editCommand;
        private RelayCommand _calculateProbability;
        private RelayCommand _findCommand;
        public ObservableCollection<DataTable> RBTable { get; set; } =
           new ObservableCollection<DataTable> { };
        public RecBook CurrentRecordBook
        {
            get => _current;
            set
            {
                _current = value;

                //CurrentTerm = "1 семестр";
                if (CurrentRecordBook!=null)
                {
                    CurrentRecordBook.UpdateRecords();
                    UpdateDataGrid();
                    SetTerms();
                    Info = "";
                    OnPropertyChanged(nameof(CurrentRecordBook));
                }
                
            }
        }
        public string CurrentTerm
        {
            get => _currentTerm;
            set
            {
                if (value != null)
                {
                    _currentTerm = value;

                    if (_termNumber != 10)
                        _termNumber = Convert.ToInt32(_currentTerm[0]) - '0';

                    UpdateDataGrid();
                    OnPropertyChanged(nameof(CurrentTerm));
                }
            }
        }
        private void UpdateDataGrid()
        {
            try
            {
                SqlConnection _sqlConnection = new SqlConnection("Server=(local)\\sqlexpress;Database=RecordBook;Trusted_Connection=True;");
                DataTable table = new DataTable();
                if (CurrentRecordBook == null) return;
                string command = $"select [Subject], [Hours], [mark], [Date], [Type], [Teacher] from Marks where [RecordBkID] = N'{CurrentRecordBook.Number}' and [Term] = N'{CurrentTerm}'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command, _sqlConnection);
                dataAdapter.Fill(table);

                RBTable.Clear();
                RBTable.Add(table);
            }
            catch (Exception e ) { MessageBox.Show(e.Message); }
        }

        private void SetTerms()
        {
            Terms.Clear();
            for (int i = 1; i <= 10; i++)
            {
                Terms.Add($"{i} семестр");
            }

            CurrentTerm = Terms[0];
        }

        private void CreateRecordBook()
        {
            CreateRecordBookWindow w = new CreateRecordBookWindow(context);
            w.ShowDialog();

            UpdateRecordBooks();
        }
        private string _info;
        public string Info
        {
            get => _info;
            set {
                _info = CurrentRecordBook.Number + " " + CurrentRecordBook.FIO;
                OnPropertyChanged(nameof(Info));
            }
            
        }
        private void AddMark()
        {
            if (CurrentRecordBook==null)
            {
                MessageBox.Show("Выберите зачетку");
                return;
            }
            AddMark w = new AddMark(context, CurrentRecordBook);
            w.ShowDialog();

            if (CurrentRecordBook != null)
                UpdateDataGrid();
        }

        private void EditMark()
        {
            if (CurrentRecordBook == null)
            {
                MessageBox.Show("Выберите зачетку");
                return;
            }
            EditWindow w = new EditWindow(context, CurrentRecordBook);
            w.ShowDialog();

            if (CurrentRecordBook != null)
                UpdateDataGrid();
        }
        private string finder;
        public string Finder
        {
            get => finder;
            set
            {
                finder = value;
                OnPropertyChanged(nameof(Finder));
            }
        }
        private void FindRecordBook()
        {
            if (string.IsNullOrEmpty(Finder))
            {
                MessageBox.Show("Введите данные");
                return;
            }
            RecBook rez;
            var book = context.Recordbooks.FirstOrDefault(x => x.Name == Finder);
            if (book != null) rez =  new RecBook(book.ID, book.Name, book.Course, book.Group, book.University, book.Speciality, context); ;
            if (int.TryParse(Finder, out var number))
            {
                book = context.Recordbooks.FirstOrDefault(x => x.ID == number);
            }
            if (book != null)
                rez = new RecBook(book.ID, book.Name, book.Course, book.Group, book.University, book.Speciality, context);
            else
            {
                MessageBox.Show("Не найдено");
                return;
            }

            if (rez!=null)
            {
                MessageBox.Show($"Зачетка найдена {rez.FIO} {rez.Number}");

                CurrentRecordBook = rez;
                UpdateRecordBooks();
                
                
            }
            
        }
        public RelayCommand CreateRecordBookCommand { get => _createRecordBookCommand ?? (_createRecordBookCommand = new RelayCommand(obj => CreateRecordBook())); }
        public RelayCommand AddMarkCommand { get => _addMarkCommand ?? (_addMarkCommand = new RelayCommand(obj => AddMark())); }
        public RelayCommand EditCommand { get => _editCommand ?? (_editCommand = new RelayCommand(obj => EditMark())); }
        public RelayCommand CalculateProbabilityCommand { get => _calculateProbability ?? (_calculateProbability = new RelayCommand(obj => RedDiplomaCalculator.CalculateProbabilityRedDiploma(CurrentRecordBook))); }
        public RelayCommand FindCommand { get => _findCommand ?? (_findCommand = new RelayCommand(obj => FindRecordBook())) ; }
    }
}
