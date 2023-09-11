

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QrAmparoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : MasterDetailPage
    {
        public DetailView()
        {
            InitializeComponent();

            //Evento está sendo atribuído ao ListView da Masgter
            masterPage.ListView.ItemSelected += ListView_ItemSelected;
            IsPresented = true;

            //Pagina que aparecerá no Detail está sendo instanciada

            var navigationPage = new Xamarin.Forms.NavigationPage(new MainPage());

            //Pagina instanciada sendo enviada para propriedade Detail
            this.Detail = navigationPage;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Models.MenuItem;

            if (item == null)
                return;

            var page = (Xamarin.Forms.Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            // Detail = new Xamarin.Forms.NavigationPage(page);
            Detail.Navigation.PushAsync(page);

            IsPresented = false;
            masterPage.ListView.SelectedItem = null;
        }
    }
}