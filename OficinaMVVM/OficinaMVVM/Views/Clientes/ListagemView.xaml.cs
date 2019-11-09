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
	public partial class ListagemView : ContentPage
	{
        private ListagemViewModel viewModel;
        public ListagemView()
        {
            InitializeComponent();
            viewModel = new ListagemViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.ObterClientesAsync();
            });

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;

            MessagingCenter.Subscribe<Cliente>(this, "Mostrar", async (cliente) =>
            {
                await Navigation.PushAsync(new CRUDView(cliente, (cliente.Id == 0) ? "Novo Cliente" : "Alterar Cliente"));
            });           

            MessagingCenter.Subscribe<Cliente>(this, "Confirmação", async (cliente) => {

                if (await DisplayAlert("Confirmação", $"Confirma remoção de {cliente.Nome.ToUpper()}?", "Yes", "No"))
                {
                    await this.viewModel.EliminarCliente(cliente.Id);
                    await DisplayAlert("Informação", "Cliente removido com sucesso", "Ok");
                    await viewModel.ObterClientesAsync();
                }
            });          
        }
                
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Cliente>(this, "Mostrar");
            MessagingCenter.Unsubscribe<Cliente>(this, "Confirmação");
        }

    }
}