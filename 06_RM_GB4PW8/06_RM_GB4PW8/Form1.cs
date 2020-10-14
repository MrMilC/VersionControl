using _06_RM_GB4PW8.Entities;
using _06_RM_GB4PW8.MnbServiceReference;
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

namespace _06_RM_GB4PW8
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        public Form1()
        {
            InitializeComponent();

            string s;
            s=WebService();

            dataGridView1.DataSource = Rates;

            XMLprocessing(s);
        }
        private string WebService()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(i+"-"+result);
            }
            return result;
        }

        private void XMLprocessing(string result)
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);
        
            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);
        
                rate.Date = DateTime.Parse(element.GetAttribute("date"));
        
                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");
        
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }
    }
}
