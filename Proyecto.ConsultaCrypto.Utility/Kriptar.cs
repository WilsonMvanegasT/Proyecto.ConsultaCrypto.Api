using CommonVB.Servientrega.SOA.CommonVB;
using System;

namespace Proyecto.ConsultaCrypto.Utility
{
    public class Kriptar
    {
        public static string Cifrar(string cadena)
        {
            cmpUtilitario objcmp = new cmpUtilitario();
            string CadenaCodificada;
            try
            {
                CadenaCodificada = objcmp.mEncriptar(cadena);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentNullException("Error" + ex.Message);
            }
            return CadenaCodificada;
        }
        public static string DesCifrar(string cadena)
        {

            cmpUtilitario objcmp = new cmpUtilitario();
            string objDeCodifica;
            try
            {
                objDeCodifica = objcmp.mDesencriptar(cadena);
            }
            catch (System.Exception ex)
            {
                throw new ArgumentNullException("Error" + ex.Message);
            }
            return objDeCodifica;
        }
    }
}
