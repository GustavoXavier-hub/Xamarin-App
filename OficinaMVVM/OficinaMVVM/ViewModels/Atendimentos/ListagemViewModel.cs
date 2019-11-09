using OficinaMVVM.Models;
using OficinaMVVM.Services.Atendimentos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OficinaMVVM.ViewModels.Atendimentos
{
    public class ListagemViewModel : BaseViewModel
    {
        private IAtendimentoService aService = new AtendimentoService();
        private Atendimento atendimentoSelecionado;

        private Atendimento atendimentoSelecionado2;
        public Atendimento AtendimentoSelecionado2
        {
            get => atendimentoSelecionado2;
            set
            {
                if (value != null)
                {
                    atendimentoSelecionado2 = value;
                    MessagingCenter.Send<Atendimento>(atendimentoSelecionado2, "MostrarOpcoes");
                }
            }
        }

        public ICommand NovoCommand { get; set; }
        public ICommand EliminarCommand { get; set; }

        public ObservableCollection<Atendimento> Atendimentos
        {
            get; set;
        }
        public ListagemViewModel()
        {
            Atendimentos = new ObservableCollection<Atendimento>();
            RegistrarCommands();
        }

        private void RegistrarCommands()
        {
            NovoCommand = new Command(() =>
            {
                MessagingCenter.Send<Atendimento>(new Atendimento(), "Mostrar");
            });
            EliminarCommand = new Command<Atendimento>((atendimento) =>
            {
                MessagingCenter.Send<Atendimento>(atendimento, "Confirmação");
            });
        }


        public async Task ObterAtendimentosAsync()
        {
            Atendimentos = await aService.GetAtendimentosAsync();
            OnPropertyChanged(nameof(Atendimentos));
        }



        public async Task EliminarAtendimento(int atendimentoID)
        {
            await aService.DeleteAtendimentoAsync(atendimentoID);
        }

        public Atendimento AtendimentoSelecionado
        {
            get { return atendimentoSelecionado; }
            set
            {
                if (value != null)
                {
                    atendimentoSelecionado = value;
                    MessagingCenter.Send<Atendimento>(atendimentoSelecionado, "Mostrar");
                }
            }
        }

        public async Task RegistrarEntregaAsync(Atendimento atendimento)
        {
            atendimento.DataHoraEntrega = DateTime.Now;
            var indiceAtendimento = Atendimentos.IndexOf(await aService.PostAtendimentoAsync(atendimento));
            Atendimentos.RemoveAt(indiceAtendimento);
            Atendimentos.Insert(indiceAtendimento, atendimento);
        }

    }
}
