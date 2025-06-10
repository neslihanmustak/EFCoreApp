using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class KursKayit
    {
        [Key]//primarykey 
        public int KayitId { get; set; }

        public int OgrenciId { get; set; }
       public Ogrenci Ogrenci { get; set; } = null!;
        //oğrenci ıd değeri var ama o bizim işimize yaramadığı için öğrenciden öğrenci tablosuna ulaşmak istiyoruz. 
        //böylece öğrenci ad soyad gibi değerlere kurs kayıt sayfasında da erşim sağlarız..
        public int KursId { get; set; }
        public Kurs Kurs { get; set; } = null!;
        //kurs kayit tablosyunda kurs içindeki verileri kullanmak için yazılır.
        //tablolar arası join işlemi yapmış olduk.

        public DateTime KayitTarihi { get; set; }

    }
}
