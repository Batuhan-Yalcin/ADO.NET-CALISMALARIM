using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_İLE_VERİ_TABANINA_KAYIT_EKLEME_SİLME_GÜNCELLEME_KAYIT_GETİRME
{
    internal class Program
    {
        static SqlConnection connection = new SqlConnection("Data Source=BATUHAN;Initial Catalog=adonet;User ID=sa; password =1");
        static void Main(string[] args)
        {

            //   kayitGetir(1,"A","2","3");
            // kayitEkle("Yusuf", "Yusuf123", "normal üye");
            //  kayitGuncelle(6, "Sezai");
          //  kayitSil(17);
        }

        public static void kayitSil(int id)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("delete from loginTable where id=@id", connection); // @ koyma sebebimiz parametreden gelen idyi belirtmek.
            cmd.Parameters.AddWithValue("@id", id);
            int donenDeger = cmd.ExecuteNonQuery();
            if (donenDeger == 1)
            {
                Console.WriteLine("Kayıt Silindi");
            }
            else
            {
                Console.WriteLine("Kayıt silinirken bir hata oluştu.");
            }
            Console.ReadLine();
            connection.Close();
        }
        public static void kayitGuncelle(int id, string kullaniciAdi)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("update loginTable set kullaniciAdi=@kulad where id = @id", connection);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi);
            cmd.Parameters.AddWithValue("@id", id);
            int donenDeger = cmd.ExecuteNonQuery();

            if (donenDeger == 1)
            {
                Console.WriteLine("Kayıt Güncellendi");
            }
            else
            {
                Console.WriteLine("Güncellenirken Hata oluştu.");
            }
            Console.ReadLine();
            connection.Close();

        }

        public static void kayitEkle(string kullaniciAdi, string sifre, string yetki)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("insert into loginTable(kullaniciAdi,sifre,yetki)values(@kulad,@sifre,@yetki)", connection);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            cmd.Parameters.AddWithValue("@yetki", yetki);
            int donenDeger = cmd.ExecuteNonQuery();

            if (donenDeger == 1)
            {
                Console.WriteLine("Kayıt Eklendi.");
            }
            else
            {
                Console.WriteLine("Kayıt Eklenirken hata oluştu..");
            }

        }

        public static void kayitGetir(int id, string kullaniciAdi, string sifre, string yetki)
        {
            List<Musteri> musteriList = new List<Musteri>();
            connection.Open();
            string query = "select * from loginTable";
            SqlCommand cmd = new SqlCommand(query, connection); // Sorguyu oluşturduk.
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Musteri musteri = new Musteri();
                    musteri.id = int.Parse(rdr["id"].ToString());
                    musteri.kullaniciAdi = rdr["kullaniciAdi"].ToString();
                    musteri.sifre = rdr["sifre"].ToString();
                    musteri.yetki = rdr["yetki"].ToString();
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

        }

    }
}
