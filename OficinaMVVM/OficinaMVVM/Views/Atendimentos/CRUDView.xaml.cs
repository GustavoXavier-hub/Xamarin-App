using OficinaMVVM.Models;
using OficinaMVVM.ViewModels.Atendimentos;
using OficinaMVVM.Views.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OficinaMVVM.Views.Atendimentos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDView : ContentPage
    {
        public CRUDView()
        {
            InitializeComponent();
        }

        private CRUDViewModel crudViewModel;
        public CRUDView(Atendimento atendimento, string title) : this()
        {
            this.crudViewModel = new CRUDViewModel(atendimento);
            this.BindingContext = this.crudViewModel;
            this.Title = title;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (PesquisaView.ClienteSelecionado != null)
                crudViewModel.Cliente = PesquisaView.ClienteSelecionado;

            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD", async (msg) =>
            { await DisplayAlert("Informação", msg, "OK"); });

            MessagingCenter.Subscribe<Atendimento>(this, "MostrarPesquisaCliente", async (atendimento) =>
            {
                await Navigation.PushAsync(new PesquisaView());
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            PesquisaView.ClienteSelecionado = null;

            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
            MessagingCenter.Unsubscribe<Atendimento>(this, "MostrarPesquisaCliente");
        }





    }
}