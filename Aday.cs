using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ücretli
{
    internal class Aday
    {
        /// <summary>
        /// adaylar[tc_no]=aday
        /// </summary>
        public static Dictionary<string,Aday> adaylar = new Dictionary<string, Aday>();

        public static readonly List<string> basliklar = new List<string>(){
            "T.C. Kimlik No",
            "Ad",
            "Soyad",
            "Telefon",
            "KPSS Yıl",
            "KPSS Tür",
            "KPSS Puanı",
            "Mezuniyet",
            "Mezuniyet Tarihi",
            "Üniverite",
            "Fakülte",
            "Bölüm",
            "Mezuniyet Notu",
            "Formasyon",
            "Görevlendirildiği Kurum",
            "Durum",
            "Adres",
            "İkinci Dönem"
        };
        //private class EqualityAdayComparer : EqualityComparer<Aday>
        //{
        //    public override bool Equals(Aday? x, Aday? y)
        //    {
        //        return x.kimlikno == y.kimlikno;
        //    }

        //    public override int GetHashCode([DisallowNull] Aday obj)
        //    {
        //        return obj.kimlikno.GetHashCode();
        //    }
        //}

        public class AdayComparer : IComparer<Aday>
        {
            public int Compare(Aday? x, Aday? y)
            {
                return x.kpsspuan <= y.kpsspuan ? 1 : -1;
            }
        }

        public static bool operator <(Aday aday1, Aday aday2) => aday1.kpsspuan < aday2.kpsspuan;
        public static bool operator >(Aday aday1, Aday aday2) => aday1.kpsspuan > aday2.kpsspuan;

        public string kimlikno { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telefon { get; set; }
        public string kpssyil { get; set; }
        public string kpsstur { get; set; }
        public double kpsspuan { get; set; }
        public List<Basvuru> basvurular { get; set; }
        public string mezuniyet { get; set; }
        public string mezuniyettarih { get; set; }
        public string univerite { get; set; }
        public string fakulte { get; set; }
        public string bolum { get; set; }
        public double mezuniyetnotu { get; set; }
        public string formasyon { get; set; }
        public string gorevlendirmekurum { get; set; }
        public string durum { get; set; }
        public string adres { get; set; }
        public string ikincidonem { get; set; }


        public Aday(string kimlikno, string ad, string soyad,
            string telefon, string kpssyil, string kpsstur, double kpsspuan,
            Basvuru basvuru,
            string mezuniyet, string tarih,
            string univerite, string fakulte, string bolum,
            double mezuniyetnotu, string formasyon,
            string gorevlendirmekurum, string durum, string adres, string ikincidonem)
        {
            this.kimlikno = kimlikno;
            this.ad = ad;
            this.soyad = soyad;
            this.telefon = telefon;
            this.kpssyil = kpssyil;
            this.kpsstur = kpsstur;
            this.kpsspuan = kpsspuan;
            this.mezuniyet = mezuniyet;
            this.mezuniyettarih = tarih;
            this.univerite = univerite;
            this.fakulte = fakulte;
            this.bolum = bolum;
            this.mezuniyetnotu = mezuniyetnotu;
            this.formasyon = formasyon;
            this.gorevlendirmekurum = gorevlendirmekurum;
            this.durum = durum;
            this.adres = adres;
            this.ikincidonem = ikincidonem;
            if (this.basvurular == null)
            {
                this.basvurular = new List<Basvuru>();
            }
            this.basvurular.Add(basvuru);
        }

        public Aday()
        {
            this.basvurular = new List<Basvuru>();
        }
        public List<string> ToList()
        {
            List<string> list = new List<string>(){
                this.kimlikno,
                this.ad,
                this.soyad,
                this.telefon,
                this.kpssyil,
                this.kpsstur,
                this.kpsspuan.ToString(),
                this.mezuniyet,
                this.mezuniyettarih,
                this.univerite,
                this.fakulte,
                this.bolum,
                this.mezuniyetnotu.ToString(),
                this.formasyon,
                this.gorevlendirmekurum,
                this.durum,
                this.adres,
                this.ikincidonem
            };

            return list;
        }

    }
}
