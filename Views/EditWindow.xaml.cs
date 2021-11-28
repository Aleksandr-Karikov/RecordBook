﻿using RecordBook.DataBase;
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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow(RecordBkContext context,ICollection<RecBook> recordBooks)
        {
            InitializeComponent();
            DataContext = new EditViewModel(context,recordBooks);
        }
    }
}