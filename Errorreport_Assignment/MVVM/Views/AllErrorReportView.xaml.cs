using Errorreport_Assignment.MVVM.Models;
using Errorreport_Assignment.Services;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AllErrorReportView.xaml
    /// </summary>
    public partial class AllErrorReportView : UserControl
    {
        public static ErrorReportModel clickedErrorReport = null!;

        public AllErrorReportView()
        {
            InitializeComponent();
        }

        private void ClickedListViewItem(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            var ErrorReportObject = item!.DataContext as ErrorReportModel;
            clickedErrorReport = ErrorReportObject!;
        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            //I have trouble with the ListView not updating correctly when removing a case, frontend.
            //This is the best way I can do with my current knowledge. 

            var button = sender as Button;
            var _clickedErrorReport = button!.DataContext as ErrorReportModel;

            if (MessageBox.Show("Är du säker på att du vill ta bort ärendet?",
                "Ta bort ärende",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Task.Run(async () => await DatabaseService.RemoveCaseAsync(_clickedErrorReport));
                clickedErrorReport = null!;
            }
        }
    }
}
