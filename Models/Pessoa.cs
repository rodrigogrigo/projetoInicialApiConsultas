using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PrimeiraApiConsulta.Data;
using PrimeiraApiConsulta.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeiraApiConsulta.Models
{
    [Table("Pessoa")]
    public class Pessoa : IPessoa
    {
        private readonly AppDbContext _context;

        public Pessoa(AppDbContext context)
        {
            _context = context;
        }

        [Column("id")]
        private int Id { get; set; }

        [Column("nome")]
        [StringLength(80)]
        private string Nome { get; set; }

        [Column("endereco")]
        [StringLength(80)]
        private string Endereco { get; set; }

        [Column("cep")]
        [StringLength(8)]
        private string Cep { get; set; }

        [Column("cpf")]
        [StringLength(11)]
        private string Cpf { get; set; }

        public Pessoa? ObterPessoaById(int? idPessoa)
        {
            return _context.Pessoas.Find(idPessoa);
        }

        public List<Pessoa> ObterPessoaByNome(string nome)
        {
            return _context.Pessoas.Where(p => p.Nome.Contains(nome)).ToList();
        }

        public List<Pessoa> ObterPessoas()
        {
            return _context.Pessoas.FromSqlRaw("SELECT * from Pessoa").ToList();
        }

        public List<Pessoa> ObterPessoasEF()
        {
            return _context.Pessoas.ToList();
        }

        public int InserirPessoaEF(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return pessoa.Id;
        }

        public int InserirPessoa(Pessoa pessoa)
        {
            string sql = ($"INSERT INTO Pessoa (nome, endereco, cep, cpf) " +
                $"VALUES ('{pessoa.Nome}','{pessoa.Endereco}','{pessoa.Cep}','{pessoa.Cpf}');" +
                $"SELECT LAST_INSERT_ROWID();");
            return _context.Database.ExecuteSqlRaw(sql);
        }

        public Pessoa? AtualizarPessoa(Pessoa pessoa)
        {
            string sql = ($"UPDATE Pessoa SET nome='{pessoa.Nome}', " +
                $"cpf='{pessoa.Cpf}'," +
                $"cep='{pessoa.Cep}'," +
                $"endereco='{pessoa.Endereco}';" +
                $"SELECT * FROM Products WHERE Id = {pessoa.Id};");
            return _context.Pessoas.FromSqlRaw(sql).FirstOrDefault();
        }

        public Pessoa AtualizarPessoaEF(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
            return pessoa;
        }

        public void ExcluirPessoaEF(int idPessoa)
        {
            var pessoa = ObterPessoaById(idPessoa);
            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                _context.SaveChanges();
            }
        }

        public void ExcluirPessoa(int idPessoa)
        {
            string sql = $"DELETE from Pessoa WHERE id={idPessoa}";
            //string sql = $"DELETE from Pessoa WHERE id={0}";
            _context.Database.ExecuteSqlRaw(sql);
            //_context.Database.ExecuteSqlRaw(sql, idPessoa);
        }
    }
}
