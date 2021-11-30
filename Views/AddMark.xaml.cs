using RecordBook.DataBase;
using RecordBook.Models;
using RecordBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecordBook.Views
{
    /// <summary>
    /// Логика взаимодействия для AddMark.xaml
    /// </summary>
    public partial class AddMark : Window
    {
        public AddMark(RecordBkContext context,RecBook recordBook)
        {
            InitializeComponent();
            DataContext = new AddMarkViewModel(context, recordBook);
        }
    }
}
