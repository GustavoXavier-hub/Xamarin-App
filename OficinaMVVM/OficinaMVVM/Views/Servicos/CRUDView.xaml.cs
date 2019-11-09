using OficinaMVVM.Models;
using OficinaMVVM.ViewModels.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OficinaMVVM.Views.Servicos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRUDView : ContentPage
	{
        
        public CRUDView ()
		{
			InitializeComponent ();
		}


        CRUDViewModel crudViewModel;
        public CRUDView(Servico servico, ObservableCollection<Servico> servicos) : this()
        {
            this.crudViewModel = new CRUDViewModel(servico, servicos);
            this.BindingContext = this.crudViewModel;
            this.Title = "Consulta Serviço";
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