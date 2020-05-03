using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CokluDbDestegi
{
    class MySqlKisiIslemleri : IKisi
    {
        public int KisiEkle(Kisi yeniKisi)
        {
            MySqlConnection sqlConnection = new MySqlConnection("server=localhost;user id=root;database=egitim;pwd=123456qaZ.");
            MySqlCommand sqlCommand = new MySqlCommand("INSERT INTO Kisiler(isim, soyisim, telefon) values(@i, @s, @t)", sqlConnection);

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
            List<Kisi> kisiler = new List<Kisi>();
            MySqlConnection sqlConnection = new MySqlConnection("server=localhost;user id=root;database=egitim;pwd=123456qaZ.");
            MySqlCommand sqlCommand = new MySqlCommand("select id, isim, soyisim, telefon from Kisiler", sqlConnection);

            sqlConnection.Open();
            MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

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
