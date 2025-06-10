using EFCoreApp.Data;
using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Models
{
    //
    public class KursViewModel
    {
        public int KursId { get; set; }
        [Required]//uyarı mesajları veriyor.
        [StringLength(50)]
        [Display(Name = "Kurs Başlığı")]
        public string? Baslik { get; set; }
        public int OgretmenId { get; set; }
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }

}
