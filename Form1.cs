using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Ace_Stream_File_Launcher
{
    public partial class Form1 : Form
    {
        public string parseMagnet(string magnet)
        {
            magnet = Regex.Replace(magnet, @"(.*?magnet:\?xt=urn:btih:)", "", RegexOptions.IgnoreCase);
            //magnet = magnet.Replace("magnet:?xt=urn:btih:", "");
            int cutIndex = magnet.IndexOf("&dn=");
            if (cutIndex > 0)
                magnet = magnet.Substring(0, cutIndex);

            return magnet;
        }
        public string parseLink(string url)
        {
            url = url.Trim('"');
            url = Regex.Replace(url, @"(.+?:)(?=.+:\/\/)", "", RegexOptions.IgnoreCase);

            bool isUrl = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        
            if (!isUrl)
            {
                if (url.IndexOf(":\\") > -1)
                {
                    if (Path.GetExtension(url) == ".url")
                    {
                        string urlFile = url;
                        url = File.ReadLines(url).Skip(1).Take(1).First().Replace("URL=", "");
                        File.Delete(urlFile);
                    }
                    else
                    {
                        url = "file:///" + url;
                    }
                }
                else
                {
                    url = "http://" + url;
                }

            }
            
            return url;
        }
        public bool PlayTorrent(string url)
        {
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["method"] = "open_in_player";

                if(url.IndexOf("magnet:") != -1)
                {                    
                    data["infohash"] = parseMagnet(url);                    
                }
                else
                {
                    data["url"] = parseLink(url);                    
                }                

                var response = wb.UploadValues("http://127.0.0.1:6878/server/api", "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);                
                
                System.Diagnostics.Debug.WriteLine(responseInString);
                System.Diagnostics.Debug.WriteLine(url);

                if ( responseInString == "{\"result\": \"ok\", \"error\": null}")
                {
                    this.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Server response:\n\n" + responseInString, "Error!");
                    return false;
                }            
            }
        }

        public void redrawControls()
        {
            textBox1.Location = dashedLabel1.Location = new Point(0, 0);
            dashedLabel1.MinimumSize = new Size(Convert.ToInt32(this.ClientSize.Width), Convert.ToInt32(this.ClientSize.Height));
            textBox1.Width = Convert.ToInt32(this.Width);
            textBox1.Height = Convert.ToInt32(this.Height);

            dashedLabel1.Location = new Point(Convert.ToInt32(this.ClientSize.Width / 2 - dashedLabel1.Size.Width / 2), Convert.ToInt32(this.ClientSize.Height / 2 - dashedLabel1.Size.Height / 2));
        }
        public Form1()
        {
            InitializeComponent();       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {    
            if(textBox1.Text != string.Empty)
            {
                PlayTorrent(textBox1.Text);
            }            
            textBox1.Text = string.Empty;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                textBox1.Text = e.Data.GetData(DataFormats.Text).ToString();

            }else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                textBox1.Text = fileList[0];
            }            
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.Control && (e.KeyCode == Keys.V))
            {                
                IDataObject data_object = Clipboard.GetDataObject();
                
                if (data_object.GetDataPresent(DataFormats.FileDrop))
                {
                    textBox1.Text = ((string[])data_object.GetData(DataFormats.FileDrop))[0];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs(); 

            if ( !(args.Length > 1 && PlayTorrent(args[1])) )
            {
                redrawControls();
                this.Opacity = 100;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            redrawControls();
        }

        private void dashedLabel1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "torrent files (*.torrent)|*.torrent|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    filePath = openFileDialog.FileName;
                    textBox1.Text = filePath;
                }
            }
            
        }

       
    }
}
