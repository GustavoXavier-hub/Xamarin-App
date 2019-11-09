using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using OficinaMVVM.Models;

namespace OficinaMVVM.Services.Atendimentos
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IRequest _request;
        private const string ApiUrlBase = "http://lzsouza.somee.com/api/Atendimentos";

        public AtendimentoService()
        {
            _request = new Request();
        }

        public async Task<ObservableCollection<Atendimento>> GetAtendimentosAsync()
        {
            ObservableCollection<Models.Atendimento> atendimentos = await
                _request.GetAsync<ObservableCollection<Models.Atendimento>>(ApiUrlBase);

            return atendimentos;
        }

        public async Task<Atendimento> PostAtendimentoAsync(Atendimento a)
        {
            if (a.AtendimentoID == 0)
                return await _request.PostAsync(ApiUrlBase, a);
            else
                return await _request.PutAsync(ApiUrlBase, a);
        }

        public async Task<Atendimento> PutAtendimentoAsync(Atendimento a)
        {
            var result = await _request.PutAsync(ApiUrlBase, a);
            return result;
        }

        public async Task<Atendimento> DeleteAtendimentoAsync(int atendimentoId)
        {
            string urlComplementar = string.Format("/{0}", atendimentoId);
            await _request.DeleteAsync(ApiUrlBase + urlComplementar);
            return new Atendimento() { AtendimentoID = atendimentoId };
        }
        
    }
}
