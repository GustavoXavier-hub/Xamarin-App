using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OficinaMVVM.Models;

namespace OficinaMVVM.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IRequest _request;
        private const string ApiUrlBase = "http://lzsouza.somee.com/api/Clientes";


        public async Task<Cliente> UpdateAsync(Cliente c, int? clienteID)
        {
            if (clienteID != null)
            {
                await this.PutClienteAsync(c);
            }
            else
            {
                await this.PostClienteAsync(c);
            }
            
            return c;
        }

        public ClienteService()
        {
            _request = new Request();
        }


        public async Task<ObservableCollection<Cliente>> GetClientesByNomeAsync(string value)
        {
            ObservableCollection<Models.Cliente> clientes =
             await _request.GetAsync<ObservableCollection<Models.Cliente>>(ApiUrlBase);

            var ClientesFiltrados = clientes.Where(c => c.Nome.Contains(value));
            return new ObservableCollection<Cliente>(ClientesFiltrados);
        }

        public async Task<ObservableCollection<Cliente>> GetClientesAsync()
        {

            ObservableCollection<Models.Cliente> clientes =  await 
                _request.GetAsync<ObservableCollection<Models.Cliente>>(ApiUrlBase);

            return clientes;
        }

        public async Task<Cliente> PostClienteAsync(Cliente c)
        {
            if(c.Id == 0)
                return await _request.PostAsync(ApiUrlBase, c);
            else
                return await _request.PutAsync(ApiUrlBase, c);
        }

        public async Task<Cliente> PutClienteAsync(Cliente c)
        {
            var result = await _request.PutAsync(ApiUrlBase, c);
            return result;            
        }

        public async Task<Cliente> DeleteClienteAsync(int clienteID)
        {
            string urlComplementar = string.Format("/{0}", clienteID); 
            await _request.DeleteAsync(ApiUrlBase + urlComplementar);
            return new Cliente() { Id = clienteID };
        }


    }
}
