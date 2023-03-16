﻿using Errorreport_Assignment.MVVM.Models;
using Errorreport_Assignment.MVVM.ViewModels;
using Errorreport_Assignment.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Errorreport_Assignment.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ErrorReportDetailsView.xaml
    /// </summary>
    public partial class ErrorReportDetailsView : UserControl
    {
        public ErrorReportDetailsView(ErrorReportModel errorReport)
        {
            InitializeComponent();

            DataContext = new ErrorReportDetailsViewModel(errorReport, new DatabaseService());
        }
    }
}
