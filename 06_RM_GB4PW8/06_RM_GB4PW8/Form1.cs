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
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace _06_RM_GB4PW8
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();

        BindingList<string> Currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();

            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetCurrenciesRequestBody();
            var response = mnbService.GetCurrencies(request);
            var result = response.GetCurrenciesResult;

            var xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement.ChildNodes[0])
            {
                var currency = element.InnerText;
                Currencies.Add(currency);
            }

            comboBox1.DataSource = Currencies;

            Console.WriteLine(result);

            RefreshData();
        }
        private void RefreshData()
        {
            Rates.Clear();
            string s = WebService();
            XMLprocessing(s);

            dataGridView1.DataSource = Rates;
            DataDiagram();
        }
        private string WebService()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBox1.SelectedItem.ToString(),
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString()
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
                if (childElement == null)
                    continue;
                rate.Currency = childElement.GetAttribute("curr");
        
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }
        private void DataDiagram()
        {
            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
