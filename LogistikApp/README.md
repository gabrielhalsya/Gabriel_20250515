# 🚚 Aplikasi Logistik Sederhana

Aplikasi Logistik berbasis ASP.NET Core MVC yang memungkinkan pengguna untuk:
- Membuat data pengiriman (Shipment)
- Melihat daftar pengiriman
- Mengupdate status pengiriman (Pickup, On Delivery, POD)
- Melihat detail lengkap shipment beserta histori statusnya
- Mendukung akses melalui UI dan API

## 📦 Fitur Utama

### 1. Create Shipment
Form untuk mengisi data pengiriman meliputi:
- **No Resi / AWB**
- **Sender Information** (Nama, Telepon, Alamat, Kode Pos)
- **Recipient Information** (Nama, Telepon, Alamat, Kode Pos)
- **Package Info** (Berat, Dimensi)

### 2. Update Status Pengiriman
Status pengiriman bisa diubah menjadi:
- **Shipment Pick Up**
- **On Delivery**
- **Proof of Delivery (POD)**

### 3. API Endpoint
- `GET /api/shipments/{noResi}` → Ambil data shipment
- `POST /api/shipments` → Tambah shipment baru
- `PUT /api/shipments/{noResi}` → Update status shipment

## 🛠️ Tools & Teknologi
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server LocalDB
- Bootstrap 5 (default template)
- Visual Studio 2022

## ▶️ Cara Menjalankan

1. **Clone Repository**
   ```bash
   git clone https://github.com/username/LogistikApp.git
