using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerializationUygulama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Urun urn = new Urun();
            urn.ID = 1;
            urn.Isim = "Kalem";
            urn.Fiyat = 29.90;
            urn.Adet = 3;

            Urun urn2 = new Urun();
            urn2.ID = 2;
            urn2.Isim = "Silgi";
            urn2.Fiyat = 39.90;
            urn2.Adet = 5;

            Urun[] urunler = new Urun[2];
            urunler[0] = urn;
            urunler[1] = urn2;

            //string serilestirilmis = JsonSerialize(urn);
            //string serilestirilmis = JsonSerialize(urunler);
            //string serilestirilmis = JsonSerializeWithType(urn);

            string serilestirilmis = JsonSerializeWithTypeArry(urunler);

            Console.WriteLine(serilestirilmis);

            Urun[] urunler2 = JsonDeserializeArry(serilestirilmis);
            foreach (Urun item in urunler2)
            {
                Console.WriteLine(item.ID + ") " + item.Isim + " " + item.Fiyat + " TL");
            }

            //Urun urn2 = JsonDeserialize(serilestirilmis);
            //Console.WriteLine(urn2.ID + ") " + urn2.Isim + " " + urn2.Fiyat + " TL");

        }

        //public static string JsonSerialize(Urun urn)
        //{
        //    return JsonConvert.SerializeObject(urn, Formatting.None);
        //}

        public static string JsonSerialize(object urn)
        {
            return JsonConvert.SerializeObject(urn, Formatting.Indented);
            //none yazarsak tek satırda verir.
            //intended yazarsak nesnelere göre ayırır.
        }

        public static string JsonSerializeWithType(Urun urn)
        {
            return JsonConvert.SerializeObject(urn, Formatting.None, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
        }

        public static Urun JsonDeserialize (string serialized)
        {
            return JsonConvert.DeserializeObject(serialized, new JsonSerializerSettings
                {
                TypeNameHandling = TypeNameHandling.Objects
            }) as Urun;
        }

        public static string JsonSerializeWithTypeArry(Urun[] urn)
        {
            return JsonConvert.SerializeObject(urn, Formatting.None, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Arrays });
        }

        public static Urun[] JsonDeserializeArry(string serialized)
        {
            return JsonConvert.DeserializeObject(serialized, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Arrays
            }) as Urun[];
        }
    }
}
