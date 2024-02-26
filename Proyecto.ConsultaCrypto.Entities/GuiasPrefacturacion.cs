using System.Collections.Generic;

namespace Proyecto.ConsultaCrypto.Entities
{
    public class InfoGuia
    {
        public string IdCliente { get; set; }
        public string IdProducto { get; set; }
        public string FechaEnvio { get; set; }
        public string IdFacturado { get; set; }
        public string CargoContable { get; set; }
        public string IdPrefactura { get; set; }
        public string IdNegociacion { get; set; }
        public string PeriodoPendienteCobrar { get; set; }
        public string ReportadoPendiente { get; set; }
        public string ValorGuia { get; set; }
    }

    public class ResponseEntity
    {
        public bool Respuesta { get; set; }
        public string Mensaje { get; set; }

        List<InfoGuia> _Guias = new List<InfoGuia>();

        public List<InfoGuia> Guias
        {
            get
            {
                if (_Guias == null)
                    return new List<InfoGuia>();
                else
                    return _Guias;
            }
            set { _Guias = value; }
        }
    }

}
