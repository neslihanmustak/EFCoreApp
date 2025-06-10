using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly DataContext _context;//Injection
        
        public OgrenciController(DataContext context) { //construction
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Ogrenciler.ToListAsync());
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //asenkron şekilde kullanma sebebimiz server daha optimize çalışması için.
        //asenkronda yemek siparişiş verildiğinde bize yemek sırası verilip diğerlerinin de sıraya geçmesi yani diğer kullanıcıların bloklanmasını engelleme durumudur.

        public async Task<IActionResult> Create(Ogrenci model)
        {
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();//asenkron olduğu için await ile bekletilmeli.
            return RedirectToAction("Index");
        }
        









        [HttpGet]
        public async Task<IActionResult> Edit(int? id)//id değerini alıyor.
        {
            if (id == null)
            {
                return NotFound();
            }


            //kurs verilerini görebilmek için yazdık.
            var ogr = await _context
                                .Ogrenciler
                              .Include(o => o.KursKayitlari)//kurskayit modeline gittik
                              .ThenInclude(o => o.Kurs)//kurskayit içindeki kurs verilerine gitmek için
                               .FirstOrDefaultAsync(o => o.OgrenciId == id);
                                //bulduğu ilk değeri alır.


            if (ogr == null)
            {
                return NotFound();//404 hatası döner.
            }

            return View(ogr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ogrenci model)//id değerlerine göre değişen değerleri yazarak ilgili id değerine ait verileri güncelliyor.
        {
            if (id != model.OgrenciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)//modelin gerektirdiği tüm alanlar mevcut.
            {
                try //
                {
                    _context.Update(model); //ilgili modeli güncellenecek olarak işaretler
                    await _context.SaveChangesAsync();//işaretlenen veri güncellenir
                }
                catch (DbUpdateConcurrencyException) //try bloğunda sorun varsa buraya girer. ve 
                {
                    if (!_context.Ogrenciler.Any(o => o.OgrenciId == model.OgrenciId))//herhangi bir kaydın veri tabanında var mı yok mu bakıyoruz.
                    {
                        return NotFound(); //404 hatası
                         
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        [HttpGet]//id değereine ait veriler alınır.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler.FindAsync(id);//gönderilen ıd ile eşleşen değerler alınır.

            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id) //from form dersek form içindeki id al ddemek. URL deki id değerini önemssemez.
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci); 
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}
