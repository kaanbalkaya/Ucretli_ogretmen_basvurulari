using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ücretli
{
    internal class Basvuru
    {
        /// <summary>
        /// branslara atanabilecek mezuniyetler branslar[brans]?=list_mezuniyetler 
        /// </summary>
        static public Dictionary<string, List<string>> branslar_mezuniyetler=new Dictionary<string, List<string>>();
        
        /// <summary>
        /// ilceler_branslar_basvurular[ilce][brans]=list<Aday>()
        /// </summary>
        static public Dictionary<string , Dictionary<string,List<Aday>>> ilceler_branslar_basvurular=new Dictionary<string,Dictionary<string,List<Aday>>>();
        
        
        public string tercih {  get; set; }
        public string tarih {  get; set; }
        public string brans {  get; set; }
        public string il {  get; set; }
        public string ilce {  get; set; }

        public Basvuru( string tercih, string tarih, string brans, string il, string ilce)
        {
          
            this.tercih = tercih;
            this.tarih = tarih;
            this.brans = brans;
            this.il = il;
            this.ilce = ilce;
        }
        public Basvuru() { }    
    }
}
