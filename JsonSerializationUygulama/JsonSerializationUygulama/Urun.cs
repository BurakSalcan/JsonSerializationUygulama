using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerializationUygulama
{
    [Serializable]
    public class Urun
    {
        public int ID { get; set; }

        public string Isim { get; set; }

        public double Fiyat { get; set; }

        public int Adet { get; set; }
    }
}
