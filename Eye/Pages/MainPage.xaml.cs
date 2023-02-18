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
        private int _page = 0;
        private int _countOnPage = 10;
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
            Agents = BDConnection.connection.Agent.ToList();
            DateStartSorter.SelectedIndex = 0;

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
        public void Filter(bool filtersChanged)
        {
            if (filtersChanged)
                _page = 0;

            var agentType = cbAgentTypes.SelectedItem as AgentType;
            var sort = cbSorting.SelectedItem as string;
            var searchText = tbSearch.Text.ToLower();

            DataAccess.RefreshList += DataAccess_RefreshList;

            if (agentType != null && sort != null)
            {
                FilteredAgents = agentType.Agent.Where(x =>
                    x.Title.ToLower().Contains(searchText) ||
                    x.Phone.ToLower().Contains(searchText) ||
                    x.Email.ToLower().Contains(searchText)).ToList();


                FilteredAgents = FilteredAgents.OrderBy(Sortings[sort]).ToList();
                if (sort.Contains("убыванию"))
                    FilteredAgents.Reverse();

                lvAgents.ItemsSource = FilteredAgents.Skip(_page * _countOnPage).Take(_countOnPage);
                lvAgents.Items.Refresh();
                SetPageNumbers();
            }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            _page = Convert.ToInt32((sender as Button).Content) - 1;

            Filter();
        }
        private void CreatePagingList()
        {
            
            PagingPanel.Children.RemoveRange(0, PagingPanel.Children.Count);

            for (var i = 1; i <= (int)Math.Round((double)Agents.Count / 20); i++)
            {
                var button = new Button
                {
                    Width = 30,
                    Height = 30,
                    Content = i.ToString()
                };
                button.Click += OnButtonClick;

                PagingPanel.Children.Add(button);
            }
        }
    }
}
