using OficinaMVVM.Models;
using OficinaMVVM.ViewModels.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OficinaMVVM.Views.Clientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDView : ContentPage
    {
        public CRUDView()
        {
            InitializeComponent();
        }

        private CRUDViewModel crudViewModel;
        public CRUDView(Cliente cliente, string title) : this()
        {
            this.crudViewModel = new CRUDViewModel(cliente);
            this.BindingContext = this.crudViewModel;
            this.Title = title;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            

            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD", async (msg) =>
            { await DisplayAlert("Informação", msg, "OK"); });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }



    }
}