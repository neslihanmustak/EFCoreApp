
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Data
{
    public class DataContext : DbContext //DataContext üzerinden veri tabanı ile senkronize bir yapı oluşturmuş olduk.
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Kurs> Kurslar => Set<Kurs>(); //Set<Kurs>(); sayesinde nullable olma ihtimalini kabul etmiş oluruz.
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();//Set<Ogrenci>(); sayesinde nullable olma ihtimalini kabul etmiş oluruz.
        public DbSet<KursKayit> KursKayitlari => Set<KursKayit>();
        public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();
    }
}
