using CadastroPessoasAPI.ViewModel;
using Dapper;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace CadastroPessoasAPI.Data
{
    public class Repository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CadastroPessoas;Trusted_Connection=True;MultipleActiveResultSets=True";
        public IEnumerable<PessoaViewModel> GetAll()
        {
            string query = "SELECT TOP 1000 * From Pessoas";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PessoaViewModel>(query);
            }
        }
        public PessoaViewModel GetById(int pessoaId)
        {
            string query = "Select * From Pessoas Where pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { pessoaId = pessoaId });
            }

        }
        public PessoaViewModel GetByName(string primeiroNome)
        {
            string query = "Select * From Pessoas Where primeiroNome = @primeiroNome";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { primeiroNome = primeiroNome });
            }
        }
        public void UpdatePeopleName(int pessoaId, string primeiroNome, string segundoNome, string ultimoNome, string CPF)
        {
            string query = "Update Pessoas set primeiroNome=@primeiroNome Where pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                con.QueryFirstOrDefault<PessoaViewModel>(query, new { primeiroNome = primeiroNome, pessoaId = pessoaId, segundoNome = segundoNome, ultimoNome = ultimoNome, CPF = CPF});
            }
        }
        public string Create(PessoaViewModel pessoa)
        {
            try
            {
                string query = @"Insert into Pessoas(primeiroNome, nomeMeio, ultimoNome, CPF)
            Values(@primeiroNome, @nomeMeio, @ultimoNome, @CPF)";
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Execute(query, new
                    {
                        primeiroNome = pessoa.primeiroNome,
                        nomeMeio = pessoa.nomeMeio,
                        CPF = pessoa.CPF,
                        ultimoNome = pessoa.ultimoNome,
                    });
                }
                return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

