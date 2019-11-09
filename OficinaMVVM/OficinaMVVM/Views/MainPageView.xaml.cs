using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace OficinaMVVM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPageView : MasterDetailPage
    {
        public MainPageView()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += ListView_ItemSelected;
            IsPresented = true;

            //Página de Detail está sendo atribuída no Constutor da View
            var navigationPage = new Xamarin.Forms.NavigationPage(new Views.Clientes.ListagemView());

            navigationPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

            this.Detail = navigationPage;//Atribuição sendo enviada para Tag Detail
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Models.MenuItem;

            if (item == null)
                return;

            var page = (Xamarin.Forms.Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            Detail = new Xamarin.Forms.NavigationPage(page);
            (Detail as Xamarin.Forms.NavigationPage).On < Xamarin.Forms.PlatformConfiguration.iOS > ().SetPrefersLargeTitles(true);

            IsPresented = false;
            masterPage.ListView.SelectedItem = null;
        }
    }
}
