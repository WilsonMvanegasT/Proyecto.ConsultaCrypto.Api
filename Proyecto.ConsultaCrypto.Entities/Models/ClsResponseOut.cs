using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.ConsultaCrypto.Entities.Models
{
    public class ClsResponseOut<T>
    {
        public bool StatusCode { set; get; }
        public string StatusMessage { set; get; }
        public T Result { set; get; }
    }
}
