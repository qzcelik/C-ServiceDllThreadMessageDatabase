using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace veritabaniDll
{
    public class Class1
    {

        OleDbCommand komut;
        OleDbConnection baglanti;
        OleDbDataAdapter adaptor;
        OleDbDataReader oku;
        // veritabanı yeni kişi ekleme------------------------------------------------------------------------------------------------------
        public void ekle(String kulAd, String kulSifre , String kulAdSoyad, String kulYas,String kulBoy,String kulKilo, String kulCinsiyet)
        {
             
            String sqlCumle = "insert into kisi(kullaniciAdi,sifre,kulAdSoyad,yas,kulBoy,kulKilo,kulCinsiyet) values (@kulAd,@kulSifre,@kulAdSoyad,@kulYas,@kulBoy,@kulKilo,@kulCinsiyet)";
            komut = new OleDbCommand(sqlCumle, connection());
            komut.Parameters.Add("@kulAd",kulAd);
            komut.Parameters.Add("@kulSifre", kulSifre);
            komut.Parameters.Add("@kulAdSoyad", kulAdSoyad);
            komut.Parameters.Add("@kulYas", kulYas);
            komut.Parameters.Add("@kulBoy",kulBoy);
            komut.Parameters.Add("@kulKilo",kulKilo);
            komut.Parameters.Add("@kulCinsiyet",kulCinsiyet);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        //kullanıcı var mı yok mu konrolü------------------------------------------------------------------------------------------------------
        public bool kulAdKontrol(String kulAd)
        {
            String sqlCumle = "select * from kisi where kullaniciAdi='" + kulAd + "' ";
            bool kontrol = false;
            komut = new OleDbCommand(sqlCumle,connection());
            baglanti.Open();
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku["kullaniciAdi"].ToString().Equals(kulAd)) 
                {
                    kontrol = true;
                    break;
                }
            }

            if(kontrol==true)
            {
                return true;
            }
            else
            {
               return false;
            }
          
            komut.ExecuteNonQuery();
            baglanti.Close();
        }


        public bool girisKontrol(String kulAd,String sifre)
        {
            bool kontrol = false;
            String sqlCumle = "select * from kisi where kullaniciAdi='"+kulAd+"' and sifre='"+sifre+"'";
            komut = new OleDbCommand(sqlCumle,connection());
            baglanti.Open();
            oku= komut.ExecuteReader();
            while(oku.Read())
            {
                if (oku["kullaniciAdi"].Equals(kulAd) && oku["sifre"].Equals(sifre)) 
                {
                    kontrol = true;
                    break;
                }
            }

            if(kontrol==true)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        //veritabanı bağlantısı------------------------------------------------------------------------------------------------------
        private OleDbConnection connection()
        {
            baglanti= new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporSalon.accdb");
            return baglanti;
        }
    }
}
