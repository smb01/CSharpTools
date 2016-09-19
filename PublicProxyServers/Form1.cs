using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace PublicProxyServers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        bool bBusy = false;

        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshToolStripMenuItem_Click(sender, e);
        }

        private void GetProxyServersList(string url)
        {
            WebClient webclient = new WebClient();
            string str = webclient.DownloadString(url);
            var trs = Regex.Matches(str, @"<tr>([\s\S]*?)</tr>").OfType<Match>().Select(x => x.Groups[1].Value);
            foreach (string tr in trs)
            {
                try
                {
                    var tds = Regex.Matches(tr, "<td.*?>(.+?)</td>").OfType<Match>().Select(x => x.Groups[1].Value).ToArray();
                    string domain = Regex.Matches(tds[1], "<a.+?>(.+?)</a>").OfType<Match>().Select(x => x.Groups[1].Value).ToArray()[0];

                    string features = "-";
                    var select = Regex.Matches(tds[8], "<div class=\"(.+?)\">(.+?)</div>").OfType<Match>();
                    var divs = select.Select(x => x.Groups[1].Value).ToArray();
                    if (divs[0] == "on")
                        features = select.Select(x => x.Groups[2].Value).ToArray()[0];

                    bool ssl = false;
                    select = Regex.Matches(tds[9], "<div class=\"(.+?)\">(.+?)</div>").OfType<Match>();
                    divs = select.Select(x => x.Groups[1].Value).ToArray();
                    if (divs[0] == "on")
                    {
                        features += " | " + select.Select(x => x.Groups[2].Value).ToArray()[0];
                        ssl = true;
                    }

                    ListViewItem item = new ListViewItem(domain);
                    item.SubItems.AddRange(new string[] { tds[2], tds[3], tds[4], tds[5], tds[6], tds[7], features });
                    item.Tag = ssl;
                    listView1.Items.Add(item);
                }
                catch (Exception ex) { }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (bBusy)
                refreshToolStripMenuItem.Enabled = false;
            else
                refreshToolStripMenuItem.Enabled = true;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            bBusy = true;
            toolStripStatusLabel1.Text = "Downloading servers list...";
            Thread thread = new Thread(delegate ()
            {
                try
                {
                    for (int i = 1; i < 7; i++)
                        GetProxyServersList("http://www.publicproxyservers.com/proxy/list" + i.ToString() + ".html");
                    bBusy = false;
                    toolStripStatusLabel1.Text = "Total " + listView1.Items.Count.ToString() + " servers";
                }
                catch(Exception ex)
                {
                    toolStripStatusLabel1.Text = ex.Message;
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Export();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == listView1.CurrentColumn)
            {
                if (listView1.asc)
                    listView1.asc = false;
                else
                    listView1.asc = true;
                if(e.Column == 1 || e.Column == 4)
                    listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.asc, 0, 10);
                else
                    listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.asc, 1, 0);
            }
            else
            {
                listView1.asc = false;
                if (e.Column == 1 || e.Column == 4)
                    listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.asc, 0, 10);
                else
                    listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.asc, 1, 0);
                listView1.CurrentColumn = e.Column;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach(ListViewItem item in listView1.SelectedItems)
            {
                string url = "";
                if((bool)item.Tag)
                    url = "https://" + item.Text;
                else
                    url = "http://" + item.Text;
                Process.Start(url);
            }
        }
    }
}