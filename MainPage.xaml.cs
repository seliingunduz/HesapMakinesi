using System;
using Microsoft.Maui.Controls;

namespace HesapMakinesi
{
    public partial class AnaSayfa: ContentPage
    {
        private string girdi = "0";
        private double birinciDeger = 0;
        private string islemTuru = "";
        private bool islemButonunaBasildi = false;

        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void SayıBasıldı(object sender, EventArgs e)
        {
            Button buton = (Button)sender;
            string basılanSayı = buton.Text;

            if (girdi == "0" || islemButonunaBasildi)
            {
                girdi = basılanSayı;
                islemButonunaBasildi = false;
            }
            else
            {
                girdi += basılanSayı;
            }

            EkranıGüncelle();
        }

        private void İşlemBasıldı(object sender, EventArgs e)
        {
            if (islemTuru != "")
            {
                EşittirBasıldı(this, null);
            }

            Button buton = (Button)sender;
            islemTuru = buton.Text;

            birinciDeger = double.Parse(girdi);
            islemButonunaBasildi = true;

            EkranEtiketi.Text = $"{birinciDeger} {islemTuru}";
            girdi = "0";
        }

        private void TemizleBasıldı(object sender, EventArgs e)
        {
            girdi = "0";
            birinciDeger = 0;
            islemTuru = "";
            islemButonunaBasildi = false;
            EkranEtiketi.Text = "0";
        }

        private void EşittirBasıldı(object sender, EventArgs e)
        {
            double ikinciDeger;
            if (!double.TryParse(girdi, out ikinciDeger))
            {
                EkranEtiketi.Text = "Hata";
                return;
            }

            double sonuç = 0;

            switch (islemTuru)
            {
                case "+":
                    sonuç = birinciDeger + ikinciDeger;
                    break;
                case "-":
                    sonuç = birinciDeger - ikinciDeger;
                    break;
                case "×":
                    sonuç = birinciDeger * ikinciDeger;
                    break;
                case "÷":
                    if (ikinciDeger != 0)
                    {
                        sonuç = birinciDeger / ikinciDeger;
                    }
                    else
                    {
                        EkranEtiketi.Text = "Hata";
                        return;
                    }
                    break;
                default:
                    return;
            }

            girdi = sonuç.ToString();
            EkranEtiketi.Text = girdi;
            islemTuru = "";
            islemButonunaBasildi = false;
        }

        private void EkranıGüncelle()
        {
            if (islemButonunaBasildi)
            {
                EkranEtiketi.Text = $"{birinciDeger} {islemTuru}";
            }
            else
            {
                EkranEtiketi.Text = girdi;
            }
        }
    }
}
