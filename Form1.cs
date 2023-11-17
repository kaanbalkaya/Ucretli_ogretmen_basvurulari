using Microsoft.VisualBasic.ApplicationServices;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ücretli
{
    public partial class Form1 : Form
    {
        static bool isthreadrunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            if (isthreadrunning)
            {
                MessageBox.Show("Dosya okuma/yazma işlemi devam ediyor.");
                return;
            }
            Thread t = new Thread(read_basvuru_file);
            openFileDialog.ShowDialog();
            t.Start();
          


        }

        private void read_basvuru_file()
        {

            isthreadrunning = true;
            string path = openFileDialog.FileName;
            openFileDialog.FileName = string.Empty;
            DataTable dt = new DataTable();
            List<string> rowList = new List<string>();
            FileStream fs;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            catch
            {
                MessageBox.Show("Dosya açılamadı. \nDosya başka bir programda açık olabilir mi?");
                isthreadrunning = false;
                return;
            }
            IWorkbook workbook = WorkbookFactory.Create(fs);
            ISheet sheet = workbook.GetSheetAt(0);


            for (int row_num = 1; row_num <= sheet.LastRowNum; ++row_num)
            {
                Aday aday = new Aday();
                Basvuru basvuru = new Basvuru();
                IRow row = sheet.GetRow(row_num);


                for (int i = 0; i <= 22; i++)
                {
                    string strcellvalue = row.GetCell(i).ToString().ToUpper();

                    switch ((Input.Columns)i)
                    {
                        case Input.Columns.KIMLIK_NO:
                            aday.kimlikno = strcellvalue;
                            break;
                        case Input.Columns.AD:
                            aday.ad = strcellvalue;
                            break;
                        case Input.Columns.SOYAD:
                            aday.soyad = strcellvalue;
                            break;
                        case Input.Columns.TELEFON:
                            aday.telefon = strcellvalue;
                            break;
                        case Input.Columns.TERCIH:
                            basvuru.tercih = strcellvalue;
                            break;
                        case Input.Columns.MEZUNIYET:
                            aday.mezuniyet = strcellvalue;
                            break;
                        case Input.Columns.BASVURUBRANS:
                            basvuru.brans = strcellvalue;
                            break;
                        case Input.Columns.BASVURUIL:
                            basvuru.il = strcellvalue;
                            break;
                        case Input.Columns.BASVURUILCE:
                            basvuru.ilce = strcellvalue;
                            break;
                        case Input.Columns.KPSSYIL:
                            aday.kpssyil = strcellvalue;
                            break;
                        case Input.Columns.KPSSTUR:
                            aday.kpsstur = strcellvalue;
                            break;
                        case Input.Columns.KPSSPUAN:
                            try
                            {
                                aday.kpsspuan = double.Parse(strcellvalue, CultureInfo.GetCultureInfo("tr"));
                            }
                            catch
                            {
                                aday.kpsspuan = 0;
                            }
                            break;
                        case Input.Columns.FORMASYON:
                            aday.formasyon = strcellvalue;
                            break;
                        case Input.Columns.MEZUNIYETTARIH:
                            aday.mezuniyettarih = strcellvalue;
                            break;
                        case Input.Columns.MEZUNIYETUNIVERSITE:
                            aday.univerite = strcellvalue;
                            break;
                        case Input.Columns.MEZUNIYETFAKULTE:
                            aday.fakulte = strcellvalue;
                            break;
                        case Input.Columns.MEZUNIYETNOTU:
                            try
                            {
                                aday.mezuniyetnotu = double.Parse(strcellvalue, CultureInfo.GetCultureInfo("tr"));
                            }
                            catch
                            {
                                aday.mezuniyetnotu = 0;
                            }
                            break;
                        case Input.Columns.MEZUNIYETBOLUM:
                            aday.bolum = strcellvalue;
                            break;
                        case Input.Columns.GOREVLENDIRILDIGIKURUM:
                            aday.gorevlendirmekurum = strcellvalue;
                            break;
                        case Input.Columns.DURUM:
                            aday.durum = strcellvalue;
                            break;
                        case Input.Columns.BASVURUTARIHI:
                            basvuru.tarih = strcellvalue;
                            break;
                        case Input.Columns.ADRES:
                            aday.adres = strcellvalue;
                            break;
                        case Input.Columns.IKINCIDONEM:
                            aday.ikincidonem = strcellvalue;
                            break;

                    }

                }


                if (!Aday.adaylar.Keys.Contains(aday.kimlikno))
                {
                    Aday.adaylar[aday.kimlikno] = aday;
                }
                Aday.adaylar[aday.kimlikno].basvurular.Add(basvuru);

            }

            distribute();
            MessageBox.Show("Okuma tamamlandı.");
            isthreadrunning = false;


        }

        private void distribute()
        {
            foreach (string kimlikno in Aday.adaylar.Keys)
            {
                var aday = Aday.adaylar[kimlikno];
                var mezuniyet_bolum = aday.bolum;
                foreach (var basvuru in aday.basvurular)
                {
                    if (Basvuru.branslar_mezuniyetler[basvuru.brans].Contains(mezuniyet_bolum))
                    {
                        if (!Basvuru.ilceler_branslar_basvurular.Keys.Contains(basvuru.ilce))
                        {
                            Basvuru.ilceler_branslar_basvurular[basvuru.ilce] = new Dictionary<string, List<Aday>>();
                            Basvuru.ilceler_branslar_basvurular[basvuru.ilce][basvuru.brans] = new List<Aday>();
                        }
                        if(!Basvuru.ilceler_branslar_basvurular[basvuru.ilce].Keys.Contains(basvuru.brans))
                            Basvuru.ilceler_branslar_basvurular[basvuru.ilce][basvuru.brans]=new List<Aday>();
                        Basvuru.ilceler_branslar_basvurular[basvuru.ilce][basvuru.brans].Add(aday);
                        
                    }
                }

            }
        }

        private void bransBtn_Click(object sender, EventArgs e)
        {
            if (isthreadrunning)
            {
                MessageBox.Show("Dosya okuma/yazma işlemi devam ediyor.");
                return;
            }
            openFileDialog.ShowDialog();
            read_brans_file(openFileDialog.FileName);
            openFileDialog.FileName = string.Empty;
            openFileBtn.Enabled = true;
            openFileBtn.Visible = true;
        }

        private void read_brans_file(string path)
        {
            DataTable dt = new DataTable();
            List<string> rowList = new List<string>();
            FileStream fs;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            catch
            {
                MessageBox.Show("Dosya açılamadı. \nDosya başka bir programda açık olabilir mi?");
                return;
            }
            IWorkbook workbook = WorkbookFactory.Create(fs);
            ISheet sheet = workbook.GetSheetAt(0);


            for (int row_num = 1; row_num <= sheet.LastRowNum; ++row_num)
            {
                IRow row = sheet.GetRow(row_num);
                int i = 0;
                string brans = string.Empty;
                string strcellvalue = row.GetCell(i).ToString().ToUpper();
                while (strcellvalue != string.Empty)
                {
                    if (i == 0)
                    {
                        Basvuru.branslar_mezuniyetler[strcellvalue] = new List<string>();
                        brans = strcellvalue;

                    }
                    else
                    {
                        Basvuru.branslar_mezuniyetler[brans].Add(strcellvalue);
                    }
                    ++i;
                    strcellvalue = row.GetCell(i) != null ? row.GetCell(i).ToString().ToUpper() : string.Empty;
                }

            }
        }
       

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            if (isthreadrunning)
            {
                MessageBox.Show("Dosya okuma/yazma işlemi devam ediyor.");
                return;
            }
            folderBrowserDialog.ShowDialog();
            Thread t = new Thread(write_file);
            t.Start();
        }

        private void write_file()
        {
            isthreadrunning = true;
            string path = folderBrowserDialog.SelectedPath + "\\";
            
            foreach (string ilce in Basvuru.ilceler_branslar_basvurular.Keys)
            {

                var branslar = Basvuru.ilceler_branslar_basvurular[ilce];
                IWorkbook workbook = new HSSFWorkbook();

                foreach (string brans in branslar.Keys)
                {
                    var basvurular = branslar[brans];
                    basvurular.Sort(comparer: new Aday.AdayComparer());
                    string sheet_name = brans;
                    sheet_name=sheet_name.Replace('/',' ');
                    
                    if (sheet_name.Count()>25)
                        sheet_name=sheet_name.Substring(0,25);
                    ISheet sheet;
                    try { 
                        sheet = workbook.CreateSheet(sheet_name);
                    }
                    catch
                    {
                        sheet_name=sheet_name+((new Random().Next()%1000).ToString());
                        sheet = workbook.CreateSheet(sheet_name);
                    }
                    int rowindex = 0;
                    var row = sheet.CreateRow(rowindex++);

                    for (int i = 0; i < Aday.basliklar.Count; i++)
                    {
                        row.CreateCell(i).SetCellValue(Aday.basliklar[i]);

                    }

                    foreach (var aday in basvurular)
                    {
                        row = sheet.CreateRow(rowindex++);
                        for (int i = 0; i < aday.ToList().Count; i++)
                        {
                            row.CreateCell(i).SetCellValue(aday.ToList()[i]);
                        }
                    }

                }
                var fs = new FileStream(path + ilce + ".xls", FileMode.Create, FileAccess.Write);
                workbook.Write(fs);
                //MessageBox.Show(path + ilce + ".xls");

            }

            MessageBox.Show("İlçelere göre dağılım dosyları "+path+" klasöründe oluşturuldu.");
            isthreadrunning = false;
        }
    }
}