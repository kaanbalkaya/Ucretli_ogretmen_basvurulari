namespace Ücretli
{
    namespace Input
    {
        enum Columns
        {
            KIMLIK_NO = 0,
            AD = 1,
            SOYAD = 2,
            TELEFON = 3,
            TERCIH = 4,
            MEZUNIYET = 5,
            BASVURUBRANS = 6,
            BASVURUIL = 7,
            BASVURUILCE = 8,
            KPSSYIL = 9,
            KPSSTUR = 10,
            KPSSPUAN = 11,
            FORMASYON = 12,
            MEZUNIYETTARIH = 13,
            MEZUNIYETUNIVERSITE = 14,
            MEZUNIYETFAKULTE = 15,
            MEZUNIYETNOTU = 16,
            MEZUNIYETBOLUM = 17,
            GOREVLENDIRILDIGIKURUM = 18,
            DURUM = 19,
            BASVURUTARIHI = 20,
            ADRES = 21,
            IKINCIDONEM = 22
        }
    }

    namespace Output
    {
        enum Columns
        {
            KIMLIKNO,
            AD,
            SOYAD,
            TELEFON,
            MEZUNIYET,
            KPSSPUAN,
            FORMASYON,
            ADRES
        }
    }
}