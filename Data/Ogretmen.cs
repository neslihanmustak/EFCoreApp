using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string AdSoyad
        {
            get
            {
                return this.Ad + " " + this.Soyad;
            }
        }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //tarihi formatlarız.  true dersek tarih yüklenince yazdığımız formatta edit edilmesine izin vermiş olduk.
        public DateTime BaslamaTarihi { get; set; }
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();
        //bir öğretmenin bir çok kursu olabilri.
        //ama kurs içinde biz onu bir öğretmen sadece bir kursu olabilir olarak düzenledik.
    }
}
