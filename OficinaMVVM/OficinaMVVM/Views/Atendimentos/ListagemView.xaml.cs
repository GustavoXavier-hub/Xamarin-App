using OficinaMVVM.Models;
using OficinaMVVM.ViewModels.Atendimentos;
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
                await viewModel.ObterAtendimentosAsync();
            });

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;

            MessagingCenter.Subscribe<Atendimento>(this, "Mostrar", async (atendimento) =>
            {
                await Navigation.PushAsync(new CRUDView(atendimento, (atendimento.AtendimentoID == 0) ? "Novo Cliente" : "Alterar Cliente"));
            });
            MessagingCenter.Subscribe<Atendimento>(this, "Confirmação", async (atendimento) => {

                if (await DisplayAlert("Confirmação", $"Confirma remoção do atendimento para {atendimento.Veiculo.ToUpper()}?", "Yes", "No"))
                {
                    await this.viewModel.EliminarAtendimento(atendimento.AtendimentoID.Value);
                    await DisplayAlert("Informação", "Atendimento removido com sucesso", "Ok");
                    await viewModel.ObterAtendimentosAsync();
                }
            });


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Cliente>(this, "Mostrar");
            MessagingCenter.Unsubscribe<Cliente>(this, "Confirmação");
        }
        private async Task ExibirOpcoesAsync(Atendimento atendimento)
        {
            viewModel.AtendimentoSelecionado = null;
            string result;
            if (atendimento.EstaFinalizado)
                result = await DisplayActionSheet("Opções para o Atendimento " +
                atendimento.AtendimentoID, "Cancelar", "Consultar");
            else
                result = await DisplayActionSheet("Opções para o Atendimento " +
                atendimento.AtendimentoID, "Cancelar", "Alterar", "Registrar Entrega", "Remover OS");
            if (result != null)
                ProcessarOpcaoRespondidaAsync(atendimento, result);//Método a ser Inserido
        }


        private async void ProcessarOpcaoRespondidaAsync(Atendimento atendimento, string result)
        {
            if (result.Equals("Consultar") || result.Equals("Alterar"))
            {
                var title = result + " Atendimento " + atendimento.AtendimentoID;
                await Navigation.PushAsync(new CRUDView(atendimento, title));
            }
            else if (result.Equals("Registrar Entrega"))
            {
                //await viewModel.RegistrarEntregaAsync(atendimento);//TODO: Programação futura
                await DisplayAlert("Informação", "Entrega registrada comsucesso.", "Ok");
                listView.SelectedItem = null;
            }
            else if (result.Equals("Remover OS"))
            {
                if (await DisplayAlert("Confirmação",
                $"Confirma remoção da OS {atendimento.AtendimentoID}?", "Yes", "No"))
                {
                    await viewModel.EliminarAtendimento(atendimento.AtendimentoID.Value);
                    await DisplayAlert("Informação", "Atendimento removido com sucesso", "Ok");
                }
            }

        }
    }


}