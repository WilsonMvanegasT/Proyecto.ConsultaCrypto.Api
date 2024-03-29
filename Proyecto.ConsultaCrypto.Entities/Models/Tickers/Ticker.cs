﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.ConsultaCrypto.Entities.Tickers
{
    public class Ticker
    {
        public List<Data> data { get; set; }
    }

    public class Data {
        public string id { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string nameid { get; set; }
        public int rank { get; set; }
        public string price_usd { get; set; }
        public string percent_change_24h { get; set; }
        public string percent_change_1h { get; set; }
        public string percent_change_7d { get; set; }
        public string price_btc { get; set; }
        public string market_cap_usd { get; set; }
        public string volume24 { get; set; }
        public string volume24a { get; set; }
        public string csupply { get; set; }
        public string tsupply { get; set; }
        public string msupply { get; set; }
    }
}
