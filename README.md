# VoltaCAR-Telemetry-Interface-2024

Bu proje, TEKNOFEST 2024 Efficiency Challenge Elektrikli Araç Yarışları'nda yarışan **VoltaCAR** takımının elektrikli aracı için geliştirilmiş **Masaüstü Telemetri Arayüzü** yazılımıdır. 

Araç içi sensörlerden ve Araç Kontrol Ünitesinden (VCU) gelen gerçek zamanlı verileri görselleştirmek, analiz etmek ve olası arızaları anlık olarak yer istasyonuna bildirmek amacıyla geliştirilmiştir.

## 🛠 Kullanılan Teknolojiler & Araçlar
- **Geliştirme Ortamı:** C# / .NET (Windows Forms)
- **IDE:** Visual Studio 2022
- **Haberleşme:** Seri Port (UART) üzerinden kablosuz LoRa modülü entegrasyonu

## 📊 İzlenen Parametreler (Telemetri Verileri)
Arayüz üzerinden aracın kritik sistemlerine ait şu veriler anlık ve grafiksel olarak takip edilmektedir:
- Tarih
- Batarya gerilimi, batarya sıcaklığı
- Araç hızı
- Batarya kalan enerji miktarı

## 📈 Sistem Mimarisi
<img width="1181" height="870" alt="image" src="https://github.com/user-attachments/assets/8384caa1-006c-4396-8dbd-a2ddcb97b9cf" />

Alt Sistemler -> Araç Kontrol Sistemi -> LoRa Verici (Araç) >>> Kablosuz İletişim >>> LoRa Alıcı (Yer İstasyonu) -> C# Telemetri Arayüzü

## 🚀 Öne Çıkan Özellikler
- **Gerçek Zamanlı Veri İşleme:** Gelen seri port verilerini asenkron olarak işleyerek arayüzde donma/kasma yaşanmasını engeller.
- **Veri Kayıt (Logging):** Yarış esnasındaki tüm verileri analiz için arka planda .txt formatında kaydeder.
