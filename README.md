# LogistikApp

Aplikasi Logistik Sederhana berbasis ASP.NET Core MVC menggunakan Entity Framework dan SQL Server (LocalDB). Aplikasi ini memungkinkan pengguna untuk mencatat pengiriman barang, melihat status, serta memperbarui status pengiriman.

## 🧭 Fitur

- ✅ Membuat data pengiriman (shipment)
  - Nomor Resi / AWB
  - Informasi Pengirim
  - Informasi Penerima
  - Informasi Paket (berat & dimensi)
- ✅ Melihat daftar semua pengiriman
- ✅ Melihat detail pengiriman
- ✅ Update status pengiriman:
  - Shipment Pick Up
  - On Delivery
  - POD (Proof of Delivery)
- ✅ API endpoint (opsional) untuk integrasi eksternal

## 🚀 Cara Menjalankan Proyek

### 1. Clone Repository

```bash
git clone https://github.com/gabrielhalsya/LogistikApp.git
cd LogistikApp
```

### 2. Buka dengan Visual Studio 2022

- Buka file solusi `.sln` di Visual Studio 2022
- Pastikan kamu menggunakan `.NET 6` atau `.NET 7`
- Pastikan koneksi database menggunakan `(localdb)\MSSQLLocalDB`

### 3. Jalankan Migrasi & Update Database

Buka **Package Manager Console** di Visual Studio:

```powershell
Update-Database
```

> Perintah ini akan membuat database dan tabel berdasarkan `ApplicationDbContext`.

### 4. Jalankan Aplikasi

Tekan `F5` atau klik tombol **Run** di Visual Studio.

## 📁 Struktur Folder

```
LogistikApp/
├── Controllers/
│   └── ShipmentsController.cs
├── Models/
│   ├── Shipment.cs
│   ├── SenderInfo.cs
│   ├── RecipientInfo.cs
│   ├── PackageInfo.cs
│   └── ShipmentStatusHistory.cs
├── Views/
│   └── Shipments/
│       ├── Create.cshtml
│       ├── Index.cshtml
│       └── Details.cshtml
├── Data/
│   └── ApplicationDbContext.cs
├── Program.cs
└── LogistikApp.csproj
```

## 🧠 Catatan Tambahan

- Bootstrap 5 sudah terintegrasi otomatis melalui template default Visual Studio.
- Data tersimpan di SQL Server LocalDB (`(localdb)\MSSQLLocalDB`).
- File migrasi dapat ditemukan di folder `Migrations/`.

## 🛠 Teknologi yang Digunakan

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server LocalDB
- Bootstrap 5
- Visual Studio 2022

## 📦 Backup Database

Jika ingin melakukan backup ke `.sql` atau `.bak`, kamu bisa menggunakan **SQL Server Management Studio (SSMS)**:

- Right click database → **Tasks > Generate Scripts** → Simpan sebagai `.sql`
- Atau **Tasks > Back Up...** → Simpan sebagai `.bak`

## 📬 Kontak

Untuk pertanyaan atau laporan bug, silakan hubungi melalui [gabrielhalsya@gmail.com] atau buat issue di repository ini.
