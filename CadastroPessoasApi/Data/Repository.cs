using CadastroPessoasApi.ViewModel;
using Dapper;
using System.Data.SqlClient;

namespace CadastroPessoasApi.Data
{
    public class Repository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CADASTROPESSOAS;Trusted_Connection=True;MultipleActiveResultSets=True";
        public IEnumerable<PessoaViewModel> GetAll()
        {
            string query = "SELECT TOP 1000 * FROM PESSOA";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PessoaViewModel>(query);
            }
        }

        public PessoaViewModel GetById(int pessoaId)
        {
            string query = "SELECT * FROM PESSOA WHERE pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { pessoaId = pessoaId });
            }
        }
        public PessoaViewModel GetByprimeiroNome(string primeiroNome)
        {
            string query = "SELECT * FROM PESSOA WHERE primeiroNome = @primeiroNome";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { primeiroNome = primeiroNome });
            }
        }
        public void Update(int pessoaId, string novoNome)
        {
            string query = "UPDATE PESSOA SET primeiroNome = @novoNome WHERE pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                con.QueryFirstOrDefault<PessoaViewModel>(query, new { novoNome = novoNome, pessoaId = pessoaId });
            }
        }
        public string Create(PessoaViewModel pessoa)
        {
            string query = @"INSERT INTO PESSOA(PrimeiroNome, NomeMeio, UltimoNome, CPF) Values(@primeiroNome, @nomeMeio, @ultimoNome, @CPF)";
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
    }
}
