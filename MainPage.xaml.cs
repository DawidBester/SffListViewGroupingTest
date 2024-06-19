using SffListViewGroupingTest.ViewModels;

using Syncfusion.Maui.DataSource;


namespace SffListViewGroupingTest
{
    public partial class MainPage : ContentPage
    {
        private BookInfoRepository _bookInfoRepository;
        public MainPage()
        {
            _bookInfoRepository = Application.Current.Handler.MauiContext.Services.GetService<BookInfoRepository>();
            BindingContext = _bookInfoRepository;

            InitializeComponent();

            BookInfoSfListView.DataSource?.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "Category",
                KeySelector = (object obj1) =>
                {
                    var item = ((BookInfo)obj1);
                    return item.Category; //.Category;
                }

            });
        }


        private void Button_OnClicked(object? sender, EventArgs e)
        {
            var key = (sender as Button)?.CommandParameter;

            var book = (BookInfo)key;

            var group = _bookInfoRepository.BookInfoCollection.FirstOrDefault(x => x == book);

            if (group != null) group.IsExpanded = !group.IsExpanded;
        }
    }

}
