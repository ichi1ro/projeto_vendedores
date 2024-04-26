namespace Projeto_Vendedores.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException (string message) : base(message)
        {
        }
    }
}
