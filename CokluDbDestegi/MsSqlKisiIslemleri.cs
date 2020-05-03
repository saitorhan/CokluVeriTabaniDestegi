using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokluDbDestegi
{
    class MsSqlKisiIslemleri : IKisi
    {
        public int KisiEkle(Kisi yeniKisi)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\egitim;Initial Catalog=OgretmenBilgi;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Kisiler([Isim], [Soyisim], [Telefon]) values(@i, @s, @t)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@i", yeniKisi.Isim);
            sqlCommand.Parameters.AddWithValue("@s", yeniKisi.Soyisim);
            sqlCommand.Parameters.AddWithValue("@t", yeniKisi.Telefon);


            sqlConnection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return i;
        }

        public List<Kisi> KisileriGetir()
        {
            List<Kisi> kisiler  = new List<Kisi>();
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\egitim;Initial Catalog=OgretmenBilgi;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select Id, Isim, Soyisim, Telefon from Kisiler", sqlConnection);
            
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Kisi kisi = new Kisi();
                kisi.Id = sqlDataReader.GetInt32(0);
                kisi.Isim = sqlDataReader.GetString(1);
                kisi.Soyisim = sqlDataReader.GetString(2);
                kisi.Telefon = sqlDataReader.GetString(3);
                kisiler.Add(kisi);
            }


            sqlConnection.Close();
            return kisiler;
        }
    }
}
