using SffListViewGroupingTest.ViewModels;

using Syncfusion.Maui.DataSource;
using Syncfusion.Maui.ListView;


namespace SffListViewGroupingTest.Views;

public partial class MainPage : ContentPage
{
    private BookInfoRepository _bookInfoRepository;
    public MainPage()
    {
        _bookInfoRepository = Application.Current?.Handler.MauiContext?.Services.GetService<BookInfoRepository>();

        BindingContext = _bookInfoRepository;

        InitializeComponent();

    }

    protected override void OnAppearing()
    {
        BookInfoSfListView.Loaded += BookInfoSfListView_OnLoaded;
        base.OnAppearing();
    }

    private void BookInfoSfListView_OnLoaded(object? sender, ListViewLoadedEventArgs e)
    {
        var groups = BookInfoSfListView.DataSource.Groups;

        if (groups != null && groups.Count > 0)
        {
            BookInfoSfListView.CollapseGroup(groups[0]);
        }


    }
}

public class ListViewGroupingBehaviour : Behavior<SfListView>
{
    SfListView _listView;
    protected override void OnAttachedTo(SfListView bindable)
    {
        _listView = bindable;
        _listView.Loaded += Bindable_Loaded;
        base.OnAttachedTo(bindable);
    }

    private void Bindable_Loaded(object sender, ListViewLoadedEventArgs e)
    {

        if (_listView.DataSource != null)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {

                _listView.DataSource.LiveDataUpdateMode = LiveDataUpdateMode.AllowDataShaping;

                _listView.DataSource.GroupDescriptors.Add(
                    new GroupDescriptor()
                    {

                        PropertyName = "Category",
                        KeySelector = (object obj1) =>
                        {
                            var item = (obj1 as BookInfo);

                            return item.Category;
                        }
                    });

            });

        }
    }
    protected override void OnDetachingFrom(SfListView bindable)
    {
        _listView.Loaded -= Bindable_Loaded;
        _listView = null;
        base.OnDetachingFrom(bindable);
    }

}
