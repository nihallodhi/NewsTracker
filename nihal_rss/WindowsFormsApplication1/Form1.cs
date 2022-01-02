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
using System.ServiceModel.Syndication;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SyndicationFeed feed;
        String []links = new String[100];

        
        
       // char[] ch = 'url';


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void loadlistview(object sender, EventArgs e)
        {
            String option = listBox1.SelectedItem.ToString();
            String url = "";

            if(option.Equals("Google News"))
            {
                listBox2.Items.Clear();
                url = "https://news.google.co.in/news?cf=all&hl=en&pz=1&ned=in&output=rss";
                parseurl(url);

            }
            else if(option.Equals("The Times of India"))
            {
                listBox2.Items.Clear();
                url = "http://timesofindia.indiatimes.com/rssfeedstopstories.cms";
                parseurl(url);
            }
            else if (option.Equals("The Times of India(World)"))
            {
                listBox2.Items.Clear();
                url = "http://timesofindia.indiatimes.com/rssfeeds/296589292.cms";
                parseurl(url);
            }
            else if (option.Equals("The Hindu"))
            {
                listBox2.Items.Clear();
                url = "http://www.thehindubusinessline.com/?service=rss";
                parseurl(url);
            }        
            else if (option.Equals("ESPNCRICINFO(Scores)"))
            {
                listBox2.Items.Clear();
                url = "http://static.cricinfo.com/rss/livescores.xml";
                parseurl(url);            
            }
            else if (option.Equals("DAILYMAIL"))
            {
                listBox2.Items.Clear();
                url = "http://www.dailymail.co.uk/articles.rss";
                parseurl(url);
            }
            else if(option.Equals("ESPNCRICINFO(News)"))
            {
                listBox2.Items.Clear();
                url = "http://www.espncricinfo.com/rss/content/story/feeds/0.xml";
                parseurl(url);            
            }
            else if(option.Equals("MoneyControl"))
            {
                listBox2.Items.Clear();
                url = "http://www.moneycontrol.com/rss/MCtopnews.xml";
                parseurl(url);
            }
            else if (option.Equals("IndiaToday"))
            {
                listBox2.Items.Clear();
                url = "http://indiatoday.intoday.in/rss/homepage-topstories.jsp";
                parseurl(url);
            }
        
        }

        public void parseurl(String url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                feed = SyndicationFeed.Load(reader);
                int i = 0;
                foreach(SyndicationItem item in feed.Items)
                {
                   
                    listBox2.Items.Add(item.Title.Text);
                    links[i++] = item.Links[0].Uri.ToString();

                    //listBox3.Items.Add(item.Categories.ToString());
                    //link = item.Links[0].Uri.ToString();
                    //listBox3.Items.Add(item.Links[0].Uri);

                    if (i == 99)
                        break;
                }

            }

        }

        private void loadbrowser(object sender, EventArgs e)
        {
            int ind = listBox2.SelectedIndex;

            //listBox3.Items.Add(links[ind]);
            //parsestring(ind); 
            
            webBrowser1.Navigate(links[ind]);
        }

        private void parsestring(int i)
        {
            String web = links[i];

            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            //int width = sender
            //this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
