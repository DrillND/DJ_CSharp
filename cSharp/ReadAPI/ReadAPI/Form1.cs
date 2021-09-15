using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReadAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void readXML(string fileName)
        {
            string xmlFile = File.ReadAllText(fileName);
            XElement xml_Elemnt = XElement.Parse(xmlFile);
        }

        private void button1_Click(object sender, EventArgs e)
       
        {
            try
            {
                int ex = 100;
                string dollor = $"이렇게 {"변수나"} 값을 스트링 중간에 {123} 넣을 수 있는 것";

                string key = "tFfZ2QqQy1kBn84Ws41Pf7PdV4yf7POLXTZS%2B31nSKpofSAJpW2T6QEphSYhbfwkLEUvKsFoZprAdREtdeQKCQ%3D%3D";
                string pageNo = "1";
                string numOfRows = "10";
                string url = $"https://tour.daegu.go.kr/openapi-data/service/rest/getTourKorAttract/svTourKorAttract.do?serviceKey={key}&pageNo={pageNo}&numOfRows={numOfRows}10&SG_APIM=2ug8Dm9qNBfD32JLZGPN64f3EoTlkpD8kSOHWfXpyrY";

                XElement api = XElement.Load(url);

                List<Daegu> daegus = new List<Daegu>();

                foreach (var item in api.Descendants("item"))
                {
                    string address = item.Element("address").Value;
                    string attractname = item.Element("attractname").Value;
                    string tel = item.Element("tel").Value;
                    daegus.Add(new Daegu(address, attractname, tel));
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = daegus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
               
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //new Form2().Show(); //모달리스 : Modeless
            new Form2().ShowDialog();
        }
    }

    
}
