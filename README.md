# Deepseek ve Semantic Kernel ile Telegram Anime Bot
Bu proje, Deepseek yapay zeka modeli, Microsoft Semantic Kernel ve Jikan API kullanarak geliştirilmiş bir Telegram botudur. Bot, kullanıcıların anime ve anime karakterleri hakkında sorular sormasına olanak tanır ve zengin, formatlanmış yanıtlar sunar.

## 📋 Özellikler
-   **Doğal Dil İşleme**: Deepseek AI kullanarak kullanıcı mesajlarının anime veya karakter sorgusu olup olmadığını anlama
-   **Anime Bilgisi**: Jikan API üzerinden anime verileri sorgulama
-   **Karakter Bilgisi**: Anime karakterleri hakkında detaylı bilgiler sunma
-   **Zengin İçerik**: Emojilerle zenginleştirilmiş, görsel açıdan çekici yanıtlar
-   **Telegram Entegrasyonu**: Webhook temelli hızlı yanıt mekanizması

## 🛠️ Kullanılan Teknolojiler

-   **.NET 8**
-   **ASP.NET Core Web API**
-   **Microsoft Semantic Kernel**
-   **Telegram.Bot**
-   **Deepseek AI**
-   **Jikan API**  (MyAnimeList unofficial API)

## 🚀 Kurulum
1.  Bu repository'yi klonlayın:
        
    ```
    git clone https://github.com/ensardev/AI-Telegram-Bot.git
    ```
    
2.  Gerekli NuGet paketlerini yükleyin:
    
    ```
    dotnet restore
    ```
    
3.  `appsettings.json`  dosyasını açın ve aşağıdaki değerleri kendi API anahtarlarınız ve URL'lerinizle güncelleyin:
    
    json
    
    ```json
    {
      "Deepseek": {
        "ApiKey": "YOUR_DEEPSEEK_API_KEY",
        "ApiUrl": "https://api.deepseek.com/v1"
      },
      "Telegram": {
        "BotToken": "YOUR_TELEGRAM_BOT_TOKEN",
        "BotHostUrl": "https://your-url.ngrok-free.app"
      },
      "Jikan": {
        "BaseUrl": "https://api.jikan.moe/v4/"
      }
    }
    ```
    
4.  Projeyi derleyin ve başlatın:
    
    ```
    dotnet run
    ```
   
## 💬 Kullanım

Telegram'da botunuzu ekleyin ve aşağıdakine benzer sorular sorabilirsiniz:

-   "Attack on Titan hakkında bilgi ver"
-   "Naruto karakteri kimdir?"
-   "One Piece anime bilgileri"
-   "Levi Ackerman kimdir?"

## 📝 Servis Yapısı

-   **DeepseekService**: Kullanıcı mesajlarını analiz eder ve API yanıtlarını formatlar
-   **JikanService**: Jikan API'ye istekler göndererek anime ve karakter verilerini getirir
-   **TelegramService**: Telegram API ile iletişim kurarak gelen mesajları işler ve yanıtlar

## ✨ Medium Yazısı

Bu projenin detaylı anlatımını ve yapım aşamalarını [Medium yazımda](https://ensardev.medium.com/deepseek-ve-semantic-kernel-ile-telegram-botu-geli%C5%9Ftirelim-4a3a9feb4b59) bulabilirsiniz.
