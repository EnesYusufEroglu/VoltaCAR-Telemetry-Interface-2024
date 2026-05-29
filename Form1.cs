using Elektro_Arayuz.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Elektro_Arayuz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string data;
        Image imgConnected = Properties.Resources.connected;
        Image imgDisconnected = Properties.Resources.disconnected;
        Image imgReset = Properties.Resources.reset;
        Image imgGrayReset = Properties.Resources.grayReset;
        Image imgSave = Properties.Resources.save;
        Image imgGraySave = Properties.Resources.graySave;

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var seriPort in SerialPort.GetPortNames())
            {
                cBoxPorts.Items.Add(seriPort);
            }
            cBoxPorts.SelectedIndex = -1;
            cBoxBaudRate.SelectedIndex = 1;
            btnReset.Enabled = false;
            btnReset.BackgroundImage = imgGrayReset;
            btnSave.Enabled = false;
            btnSave.BackgroundImage = imgGraySave;            
        }


        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            this.Invoke(new EventHandler(ShowData));

            
        }

        public void ShowData(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            int ms = time.Millisecond;

            string[] parts = data.Split(';');
            textBox6.Text += time.ToString() + /*"\n" + ms.ToString() + */ ";" + parts[0] + ";" + parts[1] + ";" + parts[2] + ";" + parts[3] + ";" + parts[4] + " " + "\n";
            try
            {
                textBox1.Text = Convert.ToString(DateTime.Now) + ";" /*+ ms.ToString()*/ + parts[0] + "\n";
                textBox2.Text = parts[1] + "\n";
                textBox3.Text = parts[2] + "\n";
                textBox4.Text = parts[3] + "\n";
                textBox5.Text = parts[4] + "\n";
            }
            //textBox6.Text += time.ToString() + ":" + ms.ToString() + ";" /*+ parts[0] */+ ";" + parts[1] + ";" + parts[2] + ";" + parts[3] + ";" + parts[4] + " " + "\n";
            //try
            //{
            //    textBox1.Text = Convert.ToString(DateTime.Now) + ":" + ms.ToString() + /*parts[0] + */"\n";
            //    textBox2.Text = parts[0] + "\n";
            //    textBox3.Text = parts[1] + "\n";
            //    textBox4.Text = parts[2] + "\n";
            //    textBox5.Text = parts[3] + "\n";
            //}
            catch(Exception ex)
            {
                MessageBox.Show($"Veri akışı sağlanamadı\n Hata:{ex.Message}", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //for (int i = 0; i <= 4; i++)
            //{
            //    dizi[i] += parcalar[i];
            //}

            // Metin kutularına değerleri yazdırın
            //for (int i1 = 0; i1 < parcalar.Length; i1++)
            //{
            //    string ad = parcalar[i1];
            //    textBox1.Text = parcalar[0];
            //}


            //for (int i = 0; i <= 4; i++)
            //{
            //    TextBox textBox = Controls.Find("textBox" + (i + 1), true)[0] as TextBox;
            //    if (textBox != null)
            //    {
            //        textBox.Text += parcalar[i] + Environment.NewLine;
            //    }
            //}
            
            //boxReceived.Text += data;
            if (/*boxReceived.Text != null*/ textBox1.Text != null || textBox2.Text != null || textBox3.Text != null || textBox4.Text != null || textBox5.Text != null)
            {
                //lblReset.ForeColor = Color.Aqua;
                btnReset.Enabled = true;
                btnReset.BackgroundImage = imgReset;
                btnSave.Enabled = true;
                btnSave.BackgroundImage = imgSave;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxPorts.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.DataBits = 8;
                serialPort1.Handshake = Handshake.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seri port bağlantısı yapılamadı \n Hata:{ex.Message}", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if (!serialPort1.IsOpen)
            //{
            //    serialPort1.PortName = cBoxPorts.Text;
            //    serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
            //    serialPort1.Parity = Parity.None;
            //    serialPort1.StopBits = StopBits.One;
            //    serialPort1.DataBits = 8;
            //    serialPort1.Handshake = Handshake.None;

            //    try
            //    {
            //        serialPort1.Open();
            //        btnConnect.BackgroundImage = imgConnected;
            //        lblConnection.ForeColor = Color.Aqua;
            //        lblConnection.Text = "Bağlantı Kuruldu";
            //        progressBar1.Value = 100;
            //        progressBar1.ForeColor = Color.Aqua;
            //        progressBar1.BackColor = Color.Aqua;     


            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Seri port bağlantısı yapılamadı \n Hata:{ex.Message}", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    serialPort1.Close();
            //    btnConnect.BackgroundImage = imgDisconnected;
            //    lblConnection.ForeColor = Color.Maroon;
            //    lblConnection.Text = "Bağlantı Kapalı";
            //    progressBar1.Value = 0;
            //    progressBar1.ForeColor = Color.Maroon;
            //    progressBar1.BackColor = Color.Maroon;
            //}

            try
            {
                serialPort1.Open();
                progressBar1.Value = 100;
                progressBar1.ForeColor = Color.Aqua;
                progressBar1.BackColor = Color.Aqua;

                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seri Port Bağlantısı Yapılamadı \n hata:{ex.Message}", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (serialPort1.IsOpen)
            {
                btnConnect.Enabled = false;
                btnConnect.Hide();
                btnDisconnect.Show();                
                btnDisconnect.Enabled = true;
                //btnconnect.backgroundımage = imggrayconnect;
                //btndisconnect.backgroundımage = imgdisconnect;
                lblConnection.ForeColor = Color.Aqua;
                //lblconnect.forecolor = color.gray;
                //lbldisconnect.forecolor = color.aqua;
                lblConnection.Text = "Bağlantı Kuruldu";
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                btnConnect.BackColor = Color.Transparent;
                btnDisconnect.BackColor = Color.Transparent;
                btnDisconnect.Enabled = false;
                btnDisconnect.Hide();
                btnConnect.Show();
                btnConnect.Enabled = true;
                //btnConnect.BackgroundImage = imgConnect;
                //btnDisconnect.BackgroundImage = imgGrayDisconnect;
                progressBar1.Value = 0;
                lblConnection.ForeColor = Color.DarkRed;
                //lblConnect.ForeColor = Color.Aqua;
                //lblDisconnect.ForeColor = Color.Gray;
                lblConnection.Text = "Bağlantı Kapalı";
                progressBar1.ForeColor = Color.Maroon;
                progressBar1.BackColor = Color.Maroon;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            textBox6.Text = "Zaman_ms;Hiz_kmh;T_bat_C;V_bat_C;Kalan_enerji_Wh \n";

            btnReset.Enabled = false;
            btnReset.BackgroundImage = imgGrayReset;
            //lblReset.ForeColor = Color.Gray;
            btnSave.Enabled = false;
            btnSave.BackgroundImage = imgGraySave;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw;
            string fileName = "Volta Veriler " + DateTime.Now.ToString("dd/MM/yyyy HH.mm.ss") + ".txt";

            try
            {
                sw = new StreamWriter(fileName, true);
                sw.WriteLine(textBox6.Text);
                sw.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            MessageBox.Show("Veriler başarıyla kaydedildi.");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}