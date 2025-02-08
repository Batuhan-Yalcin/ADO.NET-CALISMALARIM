using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.NET_CONNECTİON_BAĞLANTISI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. Windows Authentication İle Bağlanma
            // Eğerki server name inizde \ tersh slash varsa data source un en başına çift tırnaktan öncesine @ koymanız lazım.
         SqlConnection windowsConnectionManuel = new SqlConnection("data source=BATUHAN;initial catalog=SQLDersleri;integrated security=true");



    // BU BAĞLANTIYI OTOMATİK OLARAK GETİRDİM. YAPILIŞI ŞU ŞEKİLDEDİR ;
    // 1- YUKARIDA Kİ DOSYA DÜZEN GÖRÜNÜM GİBİ KISIMLARIN OLDUĞU YERDEN PROJEYE BASIYORUZ.
    // 2- YENİ VERİ KAYNAĞI EKLEYE TIKLIYORUZ.
    // 3- VERİ TABANI VERİ KAYNAĞI YENİ BAĞLANTI YAZAN YERE TIKLIYORUZ
    // 4- VERİ KAYNAĞINI MİCROSOFT SQL SERVER I SEÇİYORUZ
    // 5- SUNUCU ADIMIZI YAZIYORUZ VE AŞŞAĞIDA TABLOLARIN OLDUĞU KISIM ÇIKIYOR ONU SEÇİYORUZ
    // DAHA SONRASINDA İLERİ DEDİĞİMİZDE Uygulamada kaydedilecek bağlantı dizesini göster seçeneğinin tikini aktif edince bağlantıyı veriyor kopyala yapıştır yapıyoruz.
    // KOPYALAYIP YAPIŞTIRIYORUZ SADECE..
    SqlConnection windowsConnectionAuto = new SqlConnection("Data Source=BATUHAN;Initial Catalog=SQLDersleri;Integrated Security=True;Trust Server Certificate=True");


            // 2. Sql Server Authentication ile bağlanma
            // User id ve pasword benim kendime ait kullanıcı ve şifremdir siz kendinizinkini girebilirsiniz.
     SqlConnection sqlServerConnectionManuel = new SqlConnection("Data Source=BATUHAN;Initial Catalog=SQLDersleri;user id=sa;password=1;Trust Server Certificate=True");

            // Sql Server Authentication ile otomatik bağlanma 
      SqlConnection sqlServerConnectionAuto = new SqlConnection("Data Source=BATUHAN;Initial Catalog=SQLDersleri;User ID=sa;Trust Server Certificate=True");

        }
    }
}
