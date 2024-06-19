using Microsoft.Extensions.Configuration;

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
