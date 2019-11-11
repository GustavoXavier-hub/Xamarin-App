using OficinaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace OficinaMVVM.Services.Clientes
{
    public interface IClienteService
    {
        Task<ObservableCollection<Cliente>> GetClientesAsync();

        Task<Cliente> GetClienteAsync(int clienteId);

        Task<Cliente> PostClienteAsync(Cliente c);

        Task<Cliente> PutClienteAsync(Cliente c);

        Task<Cliente> DeleteClienteAsync(int clienteId);

        Task<ObservableCollection<Cliente>> GetClientesByNomeAsync(string value);

        //Task<ObservableCollection<Cliente>> GetClientesByNomeAsync(string field, string value);

    }
}
