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
    public partial class PesquisaView : ContentPage
    {
        private PesquisaViewModel viewModel;

        public static Cliente ClienteSelecionado { get; set;} 

       

        public PesquisaView()
        {
            InitializeComponent();
            viewModel = new PesquisaViewModel();
            BindingContext = viewModel;
            ClienteSelecionado = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Cliente>(this, "ClienteSelecionado", (Cliente) =>
             {
                 ClienteSelecionado = Cliente;
                 Navigation.PopAsync();
             });
        
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "ClienteSelecionado");
        }

    }
}