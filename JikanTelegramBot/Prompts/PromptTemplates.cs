namespace JikanTelegramBot.Prompts;

public static class PromptTemplates
{
    public const string IntentDetectionPrompt = @"
Kullanıcıdan gelen mesajı analiz et. Bu mesaj bir anime araması mı, anime karakteri araması mı, yoksa alakasız bir şey mi?

Yalnızca şu JSON formatında yanıt ver:
{""type"": ""anime"" | ""character"" | ""none"", ""query"": ""sorgu kelimesi""}

Kullanıcı mesajı:
""{{input}}""
";


    public const string FormatResponsePrompt = @"
Aşağıdaki JSON verisini anime/karakter bilgisi olarak Türkçe dilinde ve Telegram HTML formatında yanıt oluştur:
{{json}}

Telegram HTML etiketleri:
<b>kalın</b> veya <strong>kalın</strong>
<i>italik</i> veya <em>italik</em>
<u>altı çizili</u>
<s>üstü çizili</s>
<a href='URL'>link</a>
<blockquote>alıntı</blockquote>

Anime için:
- <b>Başlık ve yıl</b> ile etkileyici bir giriş yap
- ⭐ Puan bilgisi ve 🔥 popülerlik durumunu vurgulu göster
- 📝 Detaylı ve çekici bir özet yaz (3-5 cümle)
- 🎭 Türleri liste halinde göster ve her türe uygun emoji ekle
- 📊 İstatistiksel bilgileri (izlenme sayısı, favori sayısı) öne çıkar
- 🏢 Stüdyo, 📅 yayın tarihi, ⏱️ bölüm süresi ve 📺 bölüm sayısı bilgilerini görsel emoji ile zenginleştir
- 💬 Varsa ünlü bir alıntı/replik ekle

Karakter için:
- <b>İsim</b> ile etkileyici bir giriş yap
- 🎬 Yer aldığı anime(ler)i öne çıkar
- 👤 Kişiliğini ve fiziksel özelliklerini detaylı anlat
- ⚔️ Özel yeteneklerini ve güçlerini vurgula
- 📊 Popülerlik bilgisini ve fanların neden sevdiğini anlat
- 💭 Karakterin ünlü bir repliğini <blockquote> içinde göster

Genel kurallar:
- Her bölüm için uygun emojiler kullan
- Akıcı ve heyecan verici bir dil kullan
- Yanıt 250-300 kelime arasında olsun
- Liste için '- ' kullan ve her liste maddesini emoji ile başlat
- Satır aralarında boşluk bırak
";
}
