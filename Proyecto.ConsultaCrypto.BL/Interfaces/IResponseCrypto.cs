using Proyecto.ConsultaCrypto.Entities.Tickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.ConsultaCrypto.BL.Interfaces
{
    public interface IResponseCrypto
    {
        Task<Ticker> ConsultarCryptos();
        Task<object> ConsultarSpecificCryptoData(string id);
    }
}
