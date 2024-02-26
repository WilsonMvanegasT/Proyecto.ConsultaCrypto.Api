using Proyecto.ConsultaCrypto.BL.Interfaces;
using Proyecto.ConsultaCrypto.DAL;
using Proyecto.ConsultaCrypto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.ConsultaCrypto.Entities.Tickers;

namespace Proyecto.ConsultaCrypto.BL
{
    public class ResponseCrypto : IResponseCrypto
    {       
        public Task<Ticker> ConsultarCryptos()
        {
            ResponseCryptoIDAL ResponseCryptoIDAL = new ResponseCryptoIDAL();
            return ResponseCryptoIDAL.GetCryptoData();
        }

        public Task<object> ConsultarSpecificCryptoData(string id)
        {
            ResponseCryptoIDAL ResponseCryptoIDAL = new ResponseCryptoIDAL();
            return ResponseCryptoIDAL.GetSpecificCryptoData(id);
        }
    }
}
