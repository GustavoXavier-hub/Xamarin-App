using OficinaMVVM.Models;
using OficinaMVVM.Services.Clientes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OficinaMVVM.ViewModels.Clientes
{
    public class PesquisaViewModel : BaseViewModel
    {
        private IClienteService cService = new ClienteService();
        public ObservableCollection<Cliente> ClientesEncontrados{ get; set; }
        public ICommand PesquisarCommand { get; set; }

        public PesquisaViewModel()
        {
            ClientesEncontrados = new ObservableCollection<Cliente>();
            RegistrarCommands();
        }

        private void RegistrarCommands()
        {
            PesquisarCommand = new Command<string>(async (cliente) =>
            {
                ClientesEncontrados.Clear();
                var clientesEncontrados = await cService.GetClientesByNomeAsync(cliente);
                foreach (var c in clientesEncontrados)
                {
                    ClientesEncontrados.Add(c);
                }
            });
        }

        private Cliente clienteLocalizadoSelecionado;
        public Cliente ClienteLocalizadoSelecionado
        {
            get { return clienteLocalizadoSelecionado; }
            set
            {
                if (value != null)
                {
                    clienteLocalizadoSelecionado = value;
                    MessagingCenter.Send<Cliente>(clienteLocalizadoSelecionado, "ClienteSelecionado");
                }
            }
        }


        
    }
}
