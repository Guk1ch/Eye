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
using Eye.DataBase;

namespace Eye.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<Agent> Agents { get; set; }
        public List<Agent> FilteredAgents { get; set; }
        public List<AgentType> AgentTypes { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnEditPriority_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddAgent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AgentPage());
        }

        private void lvAgents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lvAgents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void cbAgentTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
