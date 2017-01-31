using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Collections;


namespace WeatherApplication
{
    interface IObserwowany
    {
        void dodajObserwatora(IObserwator o);
        void usunObserwatora(IObserwator o);
        void powiadomObserwatorow(XmlDocument xmlDok);
    }

    interface IObserwator
    {
        void aktualizujPogode(XmlDocument xmlDok);
    }

    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();

            miastoCB.Items.Add("Dzialdowo");
            miastoCB.Items.Add("Wroclaw");
            miastoCB.Items.Add("Warszawa");    
			//miastoCB.Items.Add("");
        }

        private void miastoCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pogodynka pogodynka = new Pogodynka(); 
            Aplikacja aplikacja = new Aplikacja(pogodynka); 
            XmlDocument xmlPogoda = new XmlDocument();

            pogodynka.dodajObserwatora(aplikacja);

            pogodynka.odczytajPogode(miastoCB.SelectedItem.ToString());
            xmlPogoda = aplikacja.xmlPogoda;

            pogodaTC.TabPages.Clear();

            XmlNodeList xmlNodeList = xmlPogoda.GetElementsByTagName("forecastday");
            int i = 0;
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                pogodaTC.TabPages.Add(xmlNode.SelectSingleNode("date/weekday").InnerText);

                Label data = new Label();
                data.Text = xmlNode.SelectSingleNode("date/day").InnerText + "." +
                             xmlNode.SelectSingleNode("date/month").InnerText + "." +
                             xmlNode.SelectSingleNode("date/year").InnerText;
                pogodaTC.TabPages[i].Controls.Add(data);
                pogodaTC.TabPages[i].Controls[0].Location = new Point(10, 10);

                Label warunki = new Label();
                warunki.Text = "warunki: " + xmlNode.SelectSingleNode("conditions").InnerText;
                warunki.Width = 200;
                warunki.Height = 20;
                pogodaTC.TabPages[i].Controls.Add(warunki);
                pogodaTC.TabPages[i].Controls[1].Location = new Point(10, 40);

                Label temperatura = new Label();
                temperatura.Text = "temp. (min/max): " +
                                   xmlNode.SelectSingleNode("low/celsius").InnerText + @" / " +
                                   xmlNode.SelectSingleNode("high/celsius").InnerText + @" C";
                temperatura.Width = 200;
                temperatura.Height = 20;
                pogodaTC.TabPages[i].Controls.Add(temperatura);
                pogodaTC.TabPages[i].Controls[2].Location = new Point(10, 60);

                Label wiatr = new Label();
                wiatr.Text = "wiatr: do " +
                             xmlNode.SelectSingleNode("maxwind/kph").InnerText + @" km/h, " +
                             xmlNode.SelectSingleNode("maxwind/dir").InnerText;
                wiatr.Width = 200;
                wiatr.Height = 20;
                pogodaTC.TabPages[i].Controls.Add(wiatr);
                pogodaTC.TabPages[i].Controls[3].Location = new Point(10, 80);

                PictureBox picture = new PictureBox();
                picture.ImageLocation = xmlNode.SelectSingleNode("icon_url").InnerText;
                pogodaTC.TabPages[i].Controls.Add(picture);
                pogodaTC.TabPages[i].Controls[4].Location = new Point(220, 10);

                i++;
            }
            pogodaTC.Visible = true;
        }

        
    }

    
    class Pogodynka : IObserwowany
    {
        private ArrayList obserwatorzy;
        private XmlDocument xmlDok;

        public Pogodynka()
        {
            obserwatorzy = new ArrayList();
            xmlDok = new XmlDocument();
        }

        public void dodajObserwatora(IObserwator o)
        {
            obserwatorzy.Add(o);
        }

        public void usunObserwatora(IObserwator o)
        {
            int indeks = obserwatorzy.IndexOf(o);
            obserwatorzy.RemoveAt(indeks);
        }

        public void powiadomObserwatorow(XmlDocument xmlDok)
        {
            IObserwator[] tab = (IObserwator[])obserwatorzy.ToArray(typeof(IObserwator));
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i].aktualizujPogode(xmlDok);
            }
        }

        public void odczytajPogode(string miasto)
        {
            
            string url = @"http://api.wunderground.com/api/c72e58c3896a0ba8/forecast/lang:PL/q/Poland/" + miasto + ".xml";
            xmlDok.Load(url);
            powiadomObserwatorow(xmlDok);
        }

        public XmlDocument getResult()
        {
            return xmlDok;
        }
    }

    
    class Aplikacja: IObserwator
    {
        public XmlDocument xmlPogoda;
        private Pogodynka pogodynka;

        public Aplikacja(Pogodynka pogodynka)
        {
            xmlPogoda = new XmlDocument();
            this.pogodynka = pogodynka;
        }

        public void aktualizujPogode(XmlDocument xmlDok)
        {
            xmlPogoda.LoadXml("<xmlPogoda></xmlPogoda>");
            XmlNode node = xmlPogoda.ImportNode(xmlDok.SelectSingleNode("/response/forecast/simpleforecast/forecastdays"), true);
            xmlPogoda.DocumentElement.AppendChild(node);
        }


        public void przestanObserwowac()
        {
            pogodynka.usunObserwatora(this);
        }
    }

}
