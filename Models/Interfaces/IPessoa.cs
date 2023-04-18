namespace PrimeiraApiConsulta.Models.Interfaces
{
    public interface IPessoa
    {
        Pessoa? ObterPessoaById(int? idPessoa);
        List<Pessoa> ObterPessoas();
    }
}
