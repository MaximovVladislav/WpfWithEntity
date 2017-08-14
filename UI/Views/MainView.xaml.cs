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
using Model;
using UI.ViewModels.Base;

namespace UI.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private async void MainView_OnLoaded(object sender, RoutedEventArgs e)
        {
            var dc = DataContext as IInitializable;

            if (dc != null)
            {
                await dc.InitializeAsync();
            }
        }

        private void UserGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var dc = DataContext as IEditable<User>;

            dc?.Edit(e.Row.DataContext as User);
        }
    }
}
