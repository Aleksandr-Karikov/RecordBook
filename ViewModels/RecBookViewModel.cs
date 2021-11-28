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

namespace RecordBook.ViewModels
{
    internal class RecBookViewModel :Shared
    {

        public RecBookViewModel(RecordBkContext context):base(context)
        {
            UpdateRecordBooks(); }
        // private AgreeWindow _agreeWindow;
        private RecBook _current;
        private string _currentTerm = "1 семестр";
        private int _termNumber = 1;
        private RelayCommand _createRecordBookCommand;
        private RelayCommand _addMarkCommand;
        private RelayCommand _editCommand;
        private RelayCommand _calculateProbability;
        private RelayCommand _openNextTermCommand;
        private RelayCommand _openPrevTermCommand;
    //    private RelayCommand _toNextCourseCommand;

        private RelayCommand _agreeCommand;
        private RelayCommand _notAgreeCommand;
        public ObservableCollection<DataTable> RBTable { get; set; } =
           new ObservableCollection<DataTable> { };
        public RecBook CurrentRecordBook
        {
            get => _current;
            set
            {
                _current = value;

                //CurrentTerm = "1 семестр";

                CurrentRecordBook.UpdateRecords();
                UpdateDataGrid();
                SetTerms();

                OnPropertyChanged(nameof(CurrentRecordBook));
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

                string command = $"select [Subject], [Hours], [mark], [Date], [Type], [Teacher] from Marks where [RecordBkID] = N'{CurrentRecordBook.Number}' and [Term] = N'{CurrentTerm}'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command, _sqlConnection);
                dataAdapter.Fill(table);

                RBTable.Clear();
                RBTable.Add(table);
            }
            catch (Exception e ) { }
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

        private void AddMark()
        {
            AddMark w = new AddMark(context,RecordBooks);
            w.ShowDialog();

            if (CurrentRecordBook != null)
                UpdateDataGrid();
        }

        private void EditMark()
        {
            EditWindow w = new EditWindow(context,RecordBooks);
            w.ShowDialog();

            if (CurrentRecordBook != null)
                UpdateDataGrid();
        }
        public RelayCommand CreateRecordBookCommand { get => _createRecordBookCommand ?? (_createRecordBookCommand = new RelayCommand(obj => CreateRecordBook())); }
        public RelayCommand AddMarkCommand { get => _addMarkCommand ?? (_addMarkCommand = new RelayCommand(obj => AddMark())); }
        public RelayCommand EditCommand { get => _editCommand ?? (_editCommand = new RelayCommand(obj => EditMark())); }
        public RelayCommand CalculateProbabilityCommand { get => _calculateProbability ?? (_calculateProbability = new RelayCommand(obj => RedDiplomaCalculator.CalculateProbabilityRedDiploma(CurrentRecordBook))); }
        //public RelayCommand OpenNextTermCommand { get => _openNextTermCommand ?? (_openNextTermCommand = new RelayCommand(obj => OpenNextTerm())); }
        //public RelayCommand OpenPrevTermCommand { get => _openPrevTermCommand ?? (_openPrevTermCommand = new RelayCommand(obj => OpenPrevTerm())); }
        //public RelayCommand ToNextCourseCommand { get => _toNextCourseCommand ?? (_toNextCourseCommand = new RelayCommand(obj => ToNextCourse())); }

        //public RelayCommand AgreeCommand { get => _agreeCommand ?? (_agreeCommand = new RelayCommand(obj => Agree())); }
        //public RelayCommand NotAgreeCommand { get => _notAgreeCommand ?? (_notAgreeCommand = new RelayCommand(obj => NotAgree())); }
    }
}
