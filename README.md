# 📦 TicariOtomasyon-EF6-DevExpress

> Entity Framework 6 (Database-First) ve DevExpress WinForms kullanılarak geliştirilmiş  
> akademik amaçlı, modüler bir Ticari Otomasyon Sistemi

---

## 🇹🇷 Türkçe Dokümantasyon

### 📌 Proje Tanımı

TicariOtomasyon-EF6-DevExpress,  
işletmelerin temel ticari süreçlerini (stok, satış, fatura, cari, yetkilendirme ve raporlama)  
yönetebilmesini sağlayan masaüstü tabanlı bir ticari otomasyon uygulamasıdır.

Bu proje akademik / final projesi olarak geliştirilmiş olup,  
gerçek hayattaki kurumsal otomasyon sistemleri örnek alınarak tasarlanmıştır.

---

### 🧱 Kullanılan Teknolojiler

- Platform: Windows Desktop (WinForms)
- UI: DevExpress WinForms Components
- Framework: .NET Framework 4.7.2
- ORM: Entity Framework 6 (Database-First)
- Veritabanı: Microsoft SQL Server
- Raporlama: DevExpress XtraReport (PDF & Yazdırma)
- Mail: SMTP üzerinden HTML tasarımlı mail gönderimi
- AI Entegrasyonu: GROK (satış analizi ve yorumlama)

---

### 🧩 Sistem Modülleri

- Kullanıcı, Rol ve Yetkilendirme Sistemi
- Ürün & Stok Yönetimi
- Fatura Yönetimi  
  - Fatura başlık / detay yapısı  
  - Otomatik KDV hesaplama  
  - PDF önizleme ve yazdırma
- Cari / Müşteri Yönetimi
- Satış ve Performans Analizleri  
  - SQL View tabanlı özet raporlar  
  - Grid destekli analiz ekranları  
  - AI (GROK) destekli yorumlama
- HTML tasarımlı mail gönderimi
- Raporlama ve grafik ekranları

---

### 🗄️ Veritabanı Yapısı

- Database-First yaklaşımı kullanılmıştır.
- Proje ile birlikte .bak veritabanı yedeği paylaşılmaktadır.
- SQL View’lar ile performanslı veri okuma sağlanmıştır.
- Trigger, foreign key ve ilişkisel yapı aktif olarak kullanılmaktadır.

---

### ⚙️ Kurulum

1. Repository’yi klonlayın:
   ```bash
   git clone https://github.com/kullaniciadi/TicariOtomasyon-EF6-DevExpress.git
