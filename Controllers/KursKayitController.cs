using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly DataContext _context; 
        public KursKayitController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kursKayitlari = await _context //kurs kayıtları ile ilişkili olan derğerlere erişim.
                                .KursKayitlari
                                .Include(x => x.Ogrenci) 
                                .Include(x => x.Kurs)
                                .ToListAsync(); //join işlemi çalışmış olur.
            return View(kursKayitlari);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad"); //await _context.Ogrenciler.ToListAsync(), ile kullanıcı bilgilerine erişim sağladık.
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Baslik");
                                                                                 //(value, alınacak veri)    

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KursKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            _context.KursKayitlari.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}