using OficinaMVVM.Models;
using OficinaMVVM.Services.Clientes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OficinaMVVM.ViewModels.Clientes
{
    public class CRUDViewModel : BaseViewModel
    {
        private IClienteService cService = new ClienteService();
        private Cliente Cliente { get; set; }
        public ICommand GravarCommand { get; set; }
        public CRUDViewModel(Cliente cliente)
        {
            RegistrarCommands();
            this.Cliente = cliente;
        }

    
        
        public string Nome
        {
            get { return this.Cliente.Nome; }
            set
            {
                //Atribuirá valor para a propridade
                this.Cliente.Nome = value;

                //Atualizará a propriedade ligada a View. 
                //Método presente na classe herdada
                OnPropertyChanged();
            }
        }
        public string Telefone
        {
            get { return this.Cliente.Telefone; }
            set
            {
                this.Cliente.Telefone = value;
                OnPropertyChanged();
            }
        }

        public string EMail
        {
            get { return this.Cliente.EMail; }
            set
            {
                this.Cliente.EMail = value;                
                OnPropertyChanged();
            }
        }

        private void RegistrarCommands()
        {
            GravarCommand = new Command(async () =>
            {
                await GravarAsync();
                MessagingCenter.Send<string>("Dado salvo com sucesso.", "InformacaoCRUD");
            });
        }


        private async Task GravarAsync()
        {
            //IsBusy = true;

            var ehNovoCliente = (Cliente.Id == 0 ? true : false);
            await cService.PostClienteAsync(Cliente);

            //IsBusy = false;

            AtualizarPropriedadesParaVisao(ehNovoCliente);
           
        }

        private void AtualizarPropriedadesParaVisao(bool ehNovoObjeto)
        {
            if (ehNovoObjeto)
            {
                this.Nome = string.Empty;
                this.EMail = string.Empty;
                this.Telefone = string.Empty;
                this.Cliente = new Cliente();
            }
        }


    }

}



