# EFCoreApp

ASP.NET Core MVC uygulamasi. Entity Framework Core ve SQL Server kullanir.

## Proje Amaci

Bu proje, bir kurs otomasyonu / ogrenci takip sistemi ornegidir. Temel amac, ogrenci, ogretmen, kurs ve kurs kayitlari uzerinde CRUD islemlerini gostermek ve EF Core iliskilerini pratik etmektir.

## Alan Modeli

- Ogrenci: ad, soyad, eposta, telefon ve kurs kayitlari
- Ogretmen: ad, soyad, eposta, telefon, baslama tarihi ve kurslar
- Kurs: baslik ve ogretmen
- KursKayit: ogrenci, kurs ve kayit tarihi

## Gereksinimler

- .NET SDK (6.0+)
- SQL Server (LocalDB, SQL Express veya tam kurulum)
- LibMan CLI (frontend kutuphanelerini indirmek icin)

## Kurulum

1. Baglanti metnini ayarla (onerilen):

```
# project klasorunde
DOTNET_ENVIRONMENT=Development

# User Secrets ile
# Windows (PowerShell)
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=YOUR_SERVER;Database=efCoreTestDb;Trusted_Connection=True;TrustServerCertificate=True;"
```

Alternatif olarak ortam degiskeni ile:

```
# Windows (PowerShell)
$env:ConnectionStrings__DefaultConnection="Server=YOUR_SERVER;Database=efCoreTestDb;Trusted_Connection=True;TrustServerCertificate=True;"
```

2. Frontend kutuphanelerini indir:

```
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
libman restore
```

3. Veritabani olustur (migrations varsa):

```
dotnet ef database update
```

4. Uygulamayi calistir:

```
dotnet run
```

## Notlar

- `appsettings.Development.json` repoya dahil edilmez. Gizli bilgiler icin User Secrets veya ortam degiskenleri kullanin.
- Varsayilan rota: `/Home/Index`

