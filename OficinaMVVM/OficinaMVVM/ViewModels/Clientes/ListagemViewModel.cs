using OficinaMVVM.Models;
using OficinaMVVM.Services;
using OficinaMVVM.Services.Clientes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OficinaMVVM.ViewModels.Clientes
{
    public class ListagemViewModel : BaseViewModel
    {        
        private Cliente clienteSelecionado;
        

        private IClienteService cService = new ClienteService();
        public ObservableCollection<Cliente> Clientes
        {
            get; set;
        }

        public ListagemViewModel()
        {
            Clientes = new ObservableCollection<Cliente>();            
            RegistrarCommands();
        }


        public ICommand NovoCommand { get; set; }
        public ICommand EliminarCommand { get; set; }

        private void RegistrarCommands()
        {
            NovoCommand = new Command(() =>
            {
                MessagingCenter.Send<Cliente>(new Cliente(), "Mostrar");
            });
            EliminarCommand = new Command<Cliente>((cliente) =>
            {
                MessagingCenter.Send<Cliente>(cliente, "Confirmação");
            });
        }

        public async Task ObterClientesAsync()
        {
            Clientes = await cService.GetClientesAsync();
            OnPropertyChanged(nameof(Clientes));
        }

        public Cliente ClienteSelecionado
        {
            get { return clienteSelecionado; }
            set
            {
                if (value != null)
                {
                    clienteSelecionado = value;
                    MessagingCenter.Send<Cliente>(clienteSelecionado, "Mostrar");
                }
            }
        }

        public async Task EliminarCliente(int clienteID)
        {
            await cService.DeleteClienteAsync(clienteID);            
        }

    }
}
