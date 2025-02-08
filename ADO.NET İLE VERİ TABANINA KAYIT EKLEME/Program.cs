using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_İLE_VERİ_TABANINA_KAYIT_EKLEME
{
    internal class Program
    {
        static SqlConnection connection = new SqlConnection("Data Source=Batuhan;Initial Catalog=adonet;Integrated Security=True");
        static void Main(string[] args)
        {

           // kayitlariGetir();
            kayitEkle("Mustafa", "Mustafa23", "Sekreter");

        }

        public static void kayitEkle(string kullaniciAdi,string sifre, string yetki)
        {
           
            connection.Open();

            SqlCommand cmd = new SqlCommand("insert into loginTable (kullaniciAdi,sifre,yetki)values (@kulad,@sifre,@yetki)",connection);
            cmd.Parameters.AddWithValue("@kulad",kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre",sifre);
            cmd.Parameters.AddWithValue("@yetki",yetki);
         int donenDeger = cmd.ExecuteNonQuery(); //  Hazırlamış Olduğum sorguyu çalıştır. başarılı ise deger =1 değilse =0

            if (donenDeger ==1)
            {
                Console.WriteLine("Kayıt Eklenmiştir !");
            }
            else
            {
                Console.WriteLine("Kayıt Eklenemedi !");
            }
            Console.ReadLine();
            connection.Close();
        }
        public static void kayitlariGetir()
        {
            List<Musteri> musteriList = new List<Musteri>();

            // Login table tablosunda ki kayıtları çekip burada konsola yazdıracağız..

            // Veri tabanı bağlantısını aktif ettik.
            SqlConnection connection = new SqlConnection("Data Source=BATUHAN;Initial Catalog=adonet;Integrated Security=True");
            try
            {
                connection.Open();
                Console.WriteLine("Veritabanına bağlantı başarılı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bağlantı hatası: " + ex.Message);
            }



            // Sql Command = Bizim SQL de Yazdığımız sorguların aynısıdır. Yani sorgulama işlemi görür..
            // Logintable tablosunu seç connection yazma sebebimiz hangi bağlantıya select atacağını göstermiş olduk
            SqlCommand cmd = new SqlCommand("select * from dbo.loginTable", connection);
            SqlDataReader dr = cmd.ExecuteReader(); // ExecuteReader methodu Sorguyu Çalıştırır. dr Değişkeni içerisinde kayıtları tuttuk.

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Musteri musteri = new Musteri();
                    musteri.id = int.Parse(dr["id"].ToString());
                    musteri.kullaniciAdi = dr["kullaniciAdi"].ToString();
                    musteri.sifre = dr["sifre"].ToString();
                    musteri.yetki = dr["yetki"].ToString();
                    musteriList.Add(musteri);
                }
            }
            else
            {
                Console.WriteLine("Tabloda hiç veri yok.");
            }
            connection.Close();

            foreach (Musteri musteri in musteriList)
            {
                Console.WriteLine("ID DEĞERİ: " + musteri.id + ", Kullanıcı Adı: " + musteri.kullaniciAdi + ", Şifre: " + musteri.sifre + ", Yetki: " + musteri.yetki);
            }


            Console.ReadLine();
        }

    }
}
