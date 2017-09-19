using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Collections;

namespace kisiVeriDll
{
    public class Class1
    {
        OleDbConnection baglanti;
        OleDbDataReader bilgiOku;
        OleDbCommand komut;
        //kullanıcı bilgilerini alma-------------------------------------------------------------------------------------------
        String kulAd, kulAdSoyad, kulYas, kulBoy, kulKilo, kulCinsiyet;
        
        public String kisiGenelVeri(String kulAdi)
        {
            String sqlCumle = "select * from kisi where kullaniciAdi='"+kulAdi+"' ";
            komut = new OleDbCommand(sqlCumle,connection());
            baglanti.Open();
            bilgiOku = komut.ExecuteReader();
            bilgiOku.Read();
            kulAd = bilgiOku["kullaniciAdi"].ToString();
            kulAdSoyad = bilgiOku["kulAdSoyad"].ToString();
            kulYas = bilgiOku["yas"].ToString();
            kulBoy = bilgiOku["kulBoy"].ToString();
            kulKilo = bilgiOku["kulKilo"].ToString();
            kulCinsiyet = bilgiOku["kulCinsiyet"].ToString();
      
            baglanti.Close();
            return kulAd + "#" + kulAdSoyad + "#" + kulYas + "#" + kulBoy + "#" + kulKilo + "#" + kulCinsiyet;
        }
        //servis için gerekli bilgiler sağlanıyor--------------------------------------------------------
        String kulAdi, tumVucut, bacak, karin, kol, adimSayisi, baldir,tarih,servisVerisi;
        public String servisVeri(String kulAdi)
        {
            String sqlCumle = "select * from skorTablosu where kullaniciAdi='" + kulAdi + "' ";
            komut = new OleDbCommand(sqlCumle, connection());
            baglanti.Open();
            bilgiOku = komut.ExecuteReader();
            while( bilgiOku.Read())
            {
                kulAdi = "0"+bilgiOku["kullaniciAdi"].ToString();
                tumVucut = "0"+bilgiOku["tumVucut"].ToString();
                bacak = "0"+bilgiOku["bacak"].ToString();
                karin = "0"+bilgiOku["karin"].ToString();
                kol = "0"+bilgiOku["kol"].ToString();
                adimSayisi ="0" +bilgiOku["adimSayisi"].ToString();
                baldir ="0"+ bilgiOku["baldir"].ToString();
            }

            baglanti.Close();


            servisVerisi = tumVucut + "#" + bacak + "#" + karin + "#" + kol + "#" + adimSayisi + "#" + baldir;
            StreamWriter yaz = new StreamWriter(@"C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\servisGonder.txt");
            yaz.WriteLine(servisVerisi);
            yaz.Close();


            return kulAdi + "#" + tumVucut + "#" + bacak + "#" + karin + "#" + kol + "#" + adimSayisi + "#" + baldir;
            
           
        }
      
        public ArrayList tumVeri(String kulAdi)
        {
            int a, b, c, d, e, f;
            String sqlCumle = "select * from skorTablosu where kullaniciAdi='" + kulAdi + "' ";
            ArrayList liste = new ArrayList();
            int i = 0;
            String []dizi = new String[10];
            komut = new OleDbCommand(sqlCumle, connection());
            baglanti.Open();
            bilgiOku = komut.ExecuteReader();
            while (bilgiOku.Read())
            {
                i++;
                kulAdi = bilgiOku["kullaniciAdi"].ToString();
                tumVucut = bilgiOku["tumVucut"].ToString();
                bacak = bilgiOku["bacak"].ToString();
                karin = bilgiOku["karin"].ToString();
                kol = bilgiOku["kol"].ToString();
                adimSayisi = bilgiOku["adimSayisi"].ToString();
                baldir = bilgiOku["baldir"].ToString();
                tarih = bilgiOku["tarih"].ToString();

                a = (Convert.ToInt32(0+tumVucut) + 1);
                b = (Convert.ToInt32(0+bacak) + 1);
                c = (Convert.ToInt32(0+karin) + 1);
                d = (Convert.ToInt32(0+kol) + 1);
                e = (Convert.ToInt32(0+adimSayisi)+1);
                f = (Convert.ToInt32(0+baldir) + 1);

                    liste.Add(kulAdi + "#" + (a) + "#" + (b) + "#" + (c) + "#" + (d) + "#" + (e) + "#" + (f) + "#" + tarih);
            }

            baglanti.Close();
            return liste;
          
        }
        //veritabanı yeni yapılan skor ekleme(farklı gün için)------------------------------------------------------------------------------------------------------
        public void skorEkle(String kullaniciAdi, String tumVucut, String bacak, String karin, String baldir, String kol, String adimSayisi, String tarih)
        {
            if(tumVucut!=null)
            {
                String sqlCumle = "insert into skorTablosu(kullaniciAdi,tumVucut,tarih) values(@kullaniciAdi,@tumVucut,@tarih)";
                komut = new OleDbCommand(sqlCumle, connection());
                komut.Parameters.Add("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.Add("@tumVucut", tumVucut);
                komut.Parameters.Add("@tarih", tarih);
            }
            if (kol != null)
            {
                String sqlCumle = "insert into skorTablosu(kullaniciAdi,kol,tarih) values(@kullaniciAdi,@kol,@tarih)";
                komut = new OleDbCommand(sqlCumle, connection());
                komut.Parameters.Add("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.Add("@kol", kol);
                komut.Parameters.Add("@tarih", tarih);
            }
            if (bacak != null)
            {
                String sqlCumle = "insert into skorTablosu(kullaniciAdi,kol,tarih) values(@kullaniciAdi,@bacak,@tarih)";
                komut = new OleDbCommand(sqlCumle, connection());
                komut.Parameters.Add("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.Add("@bacak", bacak);
                komut.Parameters.Add("@tarih", tarih);
            }

            if (karin != null)
            {
                String sqlCumle = "insert into skorTablosu(kullaniciAdi,karin,tarih) values(@kullaniciAdi,@karin,@tarih)";
                komut = new OleDbCommand(sqlCumle, connection());
                komut.Parameters.Add("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.Add("@karin", karin);
                komut.Parameters.Add("@tarih", tarih);
            }

            if (baldir != null)
            {
                String sqlCumle = "insert into skorTablosu(kullaniciAdi,baldir,tarih) values(@kullaniciAdi,@baldir,@tarih)";
                komut = new OleDbCommand(sqlCumle, connection());
                komut.Parameters.Add("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.Add("@baldir", baldir);
                komut.Parameters.Add("@tarih", tarih);
            }
            if (adimSayisi != null)
            {
                String sqlCumle = "insert into skorTablosu(kullaniciAdi,adimSayisi,tarih) values(@kullaniciAdi,@adimSayisi,@tarih)";
                komut = new OleDbCommand(sqlCumle, connection());
                komut.Parameters.Add("@kullaniciAdi", kullaniciAdi);
                komut.Parameters.Add("@adimSayisi", adimSayisi);
                komut.Parameters.Add("@tarih", tarih);
            }
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        //veritabanı skoru güncelleme------------------------------------------------------------------------------------------------------
        public void skorGuncelle(String guncellenecekAlan,String skor,String sira)
        {
            String sqlCumle = null;
            if (guncellenecekAlan.Equals("tumVucut"))
            {
               sqlCumle = "update skorTablosu set tumVucut='" + skor + "'  where Kimlik = " + sira + "";
            }
            if (guncellenecekAlan.Equals("kol"))
            {
                sqlCumle = "update skorTablosu set kol='" + skor + "'  where Kimlik = " + sira + "";
            }
            if (guncellenecekAlan.Equals("bacak"))
            {
                sqlCumle = "update skorTablosu set bacak='" + skor + "'  where Kimlik = " + sira + "";
            }
            if (guncellenecekAlan.Equals("karin"))
            {
                sqlCumle = "update skorTablosu set karin='" + skor + "'  where Kimlik = " + sira + "";
            }
            if (guncellenecekAlan.Equals("baldir"))
            {
                sqlCumle = "update skorTablosu set baldir='" + skor + "'  where Kimlik = " + sira + "";
            }
            if (guncellenecekAlan.Equals("adimSayisi"))
            {
                sqlCumle = "update skorTablosu set adimSayisi='" + skor + "'  where Kimlik = " + sira + "";
            }
            komut = new OleDbCommand(sqlCumle,connection());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public String alanGetir(String alan,String sira)
        {
            String sqlCumle = null,oncekiSkor=null;

            if(alan.Equals("tumVucut"))
            {
                sqlCumle = "select *from skorTablosu where Kimlik="+sira+"";
                komut = new OleDbCommand(sqlCumle,connection());
                baglanti.Open();
                bilgiOku = komut.ExecuteReader();
                bilgiOku.Read();
                oncekiSkor= bilgiOku["tumVucut"].ToString();
                baglanti.Close();
               
            }

            if (alan.Equals("kol"))
            {
                sqlCumle = "select *from skorTablosu where Kimlik=" + sira + "";
                komut = new OleDbCommand(sqlCumle, connection());
                baglanti.Open();
                bilgiOku = komut.ExecuteReader();
                bilgiOku.Read();
                oncekiSkor = bilgiOku["kol"].ToString();
                baglanti.Close();

            }
            if (alan.Equals("bacak"))
            {
                sqlCumle = "select *from skorTablosu where Kimlik=" + sira + "";
                komut = new OleDbCommand(sqlCumle, connection());
                baglanti.Open();
                bilgiOku = komut.ExecuteReader();
                bilgiOku.Read();
                oncekiSkor = bilgiOku["bacak"].ToString();
                baglanti.Close();

            }
            if (alan.Equals("karin"))
            {
                sqlCumle = "select *from skorTablosu where Kimlik=" + sira + "";
                komut = new OleDbCommand(sqlCumle, connection());
                baglanti.Open();
                bilgiOku = komut.ExecuteReader();
                bilgiOku.Read();
                oncekiSkor = bilgiOku["karin"].ToString();
                baglanti.Close();

            }
            if (alan.Equals("baldir"))
            {
                sqlCumle = "select *from skorTablosu where Kimlik=" + sira + "";
                komut = new OleDbCommand(sqlCumle, connection());
                baglanti.Open();
                bilgiOku = komut.ExecuteReader();
                bilgiOku.Read();
                oncekiSkor = bilgiOku["baldir"].ToString();
                baglanti.Close();

            }
            if (alan.Equals("adimSayisi"))
            {
                sqlCumle = "select *from skorTablosu where Kimlik=" + sira + "";
                komut = new OleDbCommand(sqlCumle, connection());
                baglanti.Open();
                bilgiOku = komut.ExecuteReader();
                bilgiOku.Read();
                oncekiSkor = bilgiOku["adimSayisi"].ToString();
                baglanti.Close();

            }
            return oncekiSkor;
        }

        //veritabanında ki tarihi getirme------------------------------------------------------------------------------------------------------
        public String tarihGetir(String kulAd)
        {
            String donenTarih = null;
            String sqlCumle = "select * from skorTablosu where kullaniciAdi='" + kulAd+"'";
            komut = new OleDbCommand(sqlCumle,connection());
            baglanti.Open();
            bilgiOku = komut.ExecuteReader();
            while(bilgiOku.Read())
            {
                donenTarih = bilgiOku["tarih"].ToString()+"#"+bilgiOku["Kimlik"];
            }
            baglanti.Close();
            return donenTarih;
        }

        //veritabanı sil------------------------------------------------------------------------------------------------------
        public void veriSil()
        {
            String sqlCumle = "delete from skorTablosu";
            komut = new OleDbCommand(sqlCumle,connection());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        //veritabanı bağlantı------------------------------------------------------------------------------------------------------
        private OleDbConnection connection()
        {
            baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Acer\Desktop\ileriProgramlamaFinalProje\sporSalon.accdb");
            return baglanti;
        }
    }
}
