namespace Proyecto.ConsultaCrypto.Utility
{
    public class AppSettings
    {
        public string SecretLogin { get; set; }
        public int ExpireTimeSession { get; set; }
        public string Audience { get; set; }
        public string IssuerLogin { get; set; }
        public string LoginUsuario { get; set; }
        public string PasswordUsuario { get; set; }
        public int EstadoUsuario { get; set; }
        public int TipoSesion { get; set; }
    }
    public class ConnectionStrings {

        public string Api_Crypto { get; set; }
    }
}
