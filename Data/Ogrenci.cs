using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
     public class Ogrenci
        {
            [Key] //primary key olarak tanımlamak için ekleniyor.
            public int OgrenciId { get; set; }
            public string? OgrenciAd { get; set; }
            public string? OgrenciSoyad { get; set; }
        
            public string AdSoyad
            {
                get
                {
                    return this.OgrenciAd + " " + this.OgrenciSoyad;
                }
            }
            public string? Eposta { get; set; }
            public string? Telefon { get; set; }

            public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
            //öğrenciler indexinde de öğrencilerin kayıt olduğu kursları görecek şekilde dizayn etmek için kullanıyıyoruz.
            //öğrencielr birden fazla kursa kayıt olabileceği için list şeklinde muhafaza ediyoruz.
    }
    
}
