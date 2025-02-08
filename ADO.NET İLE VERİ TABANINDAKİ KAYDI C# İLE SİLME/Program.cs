using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_İLE_VERİ_TABANINDAKİ_KAYDI_C__İLE_SİLME
{
    internal class Program
    {
        static SqlConnection connection = new SqlConnection("Data Source=BATUHAN;Initial Catalog=adonet;User ID=sa; password =1");
        static void Main(string[] args)
        {

            kayitSil(14); // id'si 14 olan kayıdı sildi.
             
          
        }
        // insert,update,delete işlemleri için = executeNoneQuery(); kayıtları getireceksek select işlemi = ExecuteReader();
        public static void kayitSil(int id)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("delete from loginTable where id=@id",connection); // @ koyma sebebimiz parametreden gelen idyi belirtmek.
            cmd.Parameters.AddWithValue("@id", id);
           int donenDeger = cmd.ExecuteNonQuery();
            if(donenDeger ==1)
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
     
    }
}
