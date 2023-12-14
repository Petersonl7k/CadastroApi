using CadastroPessoasAPI.Data;
using CadastroPessoasAPI.ViewModel;

namespace CadastroPessoasAPI.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll() 
        {
            var repository = new Repository();
            return repository.GetAll().ToList();
        }
        public PessoaViewModel GetById(int pessoaId) 
        {
            var repository = new Repository();
            return repository.GetById(pessoaId);
        }
        public PessoaViewModel GetByName(string primeiroNome) 
        {
            var repository = new Repository();
            return repository.GetByName(primeiroNome);
        }
        public void UpdatePeopleName(int pessoaId, string primeiroNome, string segundoNome, string ultimoNome, string CPF) 
        {
            var repository = new Repository();
            repository.UpdatePeopleName(pessoaId, primeiroNome, segundoNome, ultimoNome, CPF);
        }
        public dynamic Create(PessoaViewModel pessoa) 
        {
            if (pessoa == null)
                return "Os Dados são obrigatórios";


            if (pessoa != null && string.IsNullOrEmpty(pessoa.nomeMeio))
                return "O Sobrenome é obrigatório";



            if (pessoa != null && string.IsNullOrEmpty(pessoa.ultimoNome))
                return "O Último Nome é obrigatório";



            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return "O CPF é obrigatório";

            var repository = new Repository();
            return repository.Create(pessoa);

        }
    }
}
 