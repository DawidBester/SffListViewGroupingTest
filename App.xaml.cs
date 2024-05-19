using Microsoft.Extensions.Configuration;
using SffListViewGroupingTest.ViewModels;

namespace SffListViewGroupingTest
{
    public partial class App : Application
    {
        public App(IConfiguration config)
        {
            InitializeComponent();
            
            MainPage = new AppShell();
        }
    }
}
