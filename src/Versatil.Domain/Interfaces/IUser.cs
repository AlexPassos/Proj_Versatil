namespace Versatil.Domain.Interfaces
{
    public interface IUser
    {
        string Nome { get; }
        string Matricula { get; }
        string CodigoUnidadeFisica { get; }
        string CodigoUnidadeAdministrativa { get; }
        public bool IsAdministrador { get; }

        bool IsAuthenticated();
    }
}