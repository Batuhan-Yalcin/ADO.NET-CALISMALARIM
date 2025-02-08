using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_İLE_KAYIT_GÜNCELLEME_İŞLEMLERİ
{
    internal class Program
    {
      static  SqlConnection connection = new SqlConnection("Data Source=BATUHAN;Initial Catalog=adonet;User ID=sa; password =1");
        static void Main(string[] args)
        {

            kayitGuncelle(15, "desturÇek"); // İd'si 15 olanın kullanıcı adını desturÇek yap ve güncelle..

        }


        public static void kayitGuncelle(int id, string kullaniciAdi)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("update loginTable set kullaniciAdi =@kulad where id=@id", connection);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi);
            cmd.Parameters.AddWithValue("@id", id);
            int donenDeger = cmd.ExecuteNonQuery();

            if (donenDeger == 1)
            {
                Console.WriteLine("Kayıt başarılı");
            }
            else
            {
                Console.WriteLine("Kayıt başarısız.");
            }
            Console.ReadLine(); 
            connection.Close();
        }
        public static void kayitEkle(string kullaniciAdi, string sifre, string yetki)
        {

            connection.Open();

            SqlCommand cmd = new SqlCommand("insert into loginTable (kullaniciAdi,sifre,yetki)values (@kulad,@sifre,@yetki)", connection);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            cmd.Parameters.AddWithValue("@yetki", yetki);
            int donenDeger = cmd.ExecuteNonQuery(); //  Hazırlamış Olduğum sorguyu çalıştır. başarılı ise deger =1 değilse =0

            if (donenDeger == 1)
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
    }
}
