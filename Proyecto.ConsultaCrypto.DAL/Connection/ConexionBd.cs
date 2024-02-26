using Proyecto.ConsultaCrypto;
using Proyecto.ConsultaCrypto.Utility;

namespace Proyecto.ConsultaCrypto.DAL
{
    public class ConexionBd
    {
        public string ConexionDao(string baseDatos)
        {
            string cadenaConexion = Kriptar.DesCifrar(GetAppsettings.GetVarDataBase(baseDatos));
            return cadenaConexion;
        }
    }
}
