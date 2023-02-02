using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_HIGHLIGHT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> satirlar = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            string filepath = Application.StartupPath + "deneme.txt";


            StreamReader _strRead = null;
            try
            {
                _strRead = new StreamReader(filepath);
                string _line = _strRead.ReadLine();

                while (_line != null)
                {
                    satirlar.Add(_line);
                    _line = _strRead.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _strRead.Close();
                _strRead = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aranan = textBox1.Text;
            richTextBox1.Text = "";

            foreach (string satir in satirlar)
            {
                if (satir.Contains(aranan,StringComparison.CurrentCultureIgnoreCase))
                {
                    //var regex = @"\b(" + aranan + @")\b";
                    //satirlarlist.Add(Regex.Replace(satir, regex, @"**$1**"));
                    richTextBox1.Text += satir + "\n";
                }
            }

            var regexPattern = @"(" + aranan + @")";
            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            foreach (Match match in regex.Matches(richTextBox1.Text))
            {
                richTextBox1.Select(match.Index, match.Length);
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                richTextBox1.SelectionColor = Color.Red;
            }


        }


    }
}
