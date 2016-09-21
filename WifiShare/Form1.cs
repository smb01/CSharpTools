using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WifiShare
{
    public partial class Form1 : Form
    {
        WlanManager wlanManager = new WlanManager();
        IcsManager icsManager = new IcsManager();

        bool isStarted;

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshConnection()
        {
            txtConns.Items.Clear();
            foreach (var connection in icsManager.Connections)
            {
                if (connection.IsConnected && connection.IsSupported)
                {
                    txtConns.Items.Add(connection);
                }
            }
            if (txtConns.Items.Count > 0)
                txtConns.SelectedIndex = 0;
        }

        private void wlanManager_StationJoin(object sender, EventArgs e)
        {
            linkLabel1.Text = wlanManager.Stations.Count.ToString();
        }

        private void wlanManager_StationLeave(object sender, EventArgs e)
        {
            linkLabel1.Text = wlanManager.Stations.Count.ToString();
        }

        private void wlanManager_HostedNetworkAvailable(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                linkLabel1.Text = "";
                wlanManager.HostedNetworkAvailable += wlanManager_HostedNetworkAvailable;
                wlanManager.StationJoin += wlanManager_StationJoin;
                wlanManager.StationLeave += wlanManager_StationLeave;
                RefreshConnection();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            btnStart.Text = "Working......";
            if (isStarted)
            {
                if (Stop())
                {
                    isStarted = false;
                }
                else
                {
                    MessageBox.Show("WifiShare could not be stopped.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (txtSSID.Text.Length == 0 || txtSSID.Text.Length > 32)
                {
                    txtSSID.Focus();
                    return;
                }

                if (txtPass.Text.Length < 8 || txtPass.Text.Length > 64)
                {
                    txtPass.Focus();
                    return;
                }

                if (txtMaxClients.Text.Length == 0)
                {
                    txtMaxClients.Focus();
                    return;
                }

                if (Start(txtSSID.Text, txtPass.Text, (IcsConnection)txtConns.SelectedItem, int.Parse(txtMaxClients.Text)))
                {
                    isStarted = true;
                    Hide();
                }
                else
                {
                    MessageBox.Show("WifiShare could not be started.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            btnStart.Text = isStarted ? "Stop" : "Start";        
            txtSSID.Enabled = !isStarted;
            txtPass.Enabled = !isStarted;
            txtConns.Enabled = !isStarted;
            txtMaxClients.Enabled = !isStarted;
            btnStart.Enabled = true;
            linkLabel1.Text = "0";
        }

        private bool Start(string ssid, string password, IcsConnection connection, int maxClients)
        {
            try
            {
                Stop();
                wlanManager.SetConnectionSettings(ssid, maxClients);
                wlanManager.SetSecondaryKey(password);
                wlanManager.StartHostedNetwork();
                var privateConnectionGuid = wlanManager.HostedNetworkInterfaceGuid;
                icsManager.EnableIcs(connection.Guid, privateConnectionGuid);               
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool Stop()
        {
            try
            {
                if (this.icsManager.SharingInstalled)
                    this.icsManager.DisableIcsOnAll();
                this.wlanManager.StopHostedNetwork();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string str = "";
            for(int i = 0; i < wlanManager.Stations.Count; i++)
            {
                WlanStation station = wlanManager.Stations.Values.ElementAt(i);
                if (str != "")
                    str += "\n" + i.ToString() + "\t" + station.MacAddress;
                else
                    str = i.ToString() + "\t" + station.MacAddress;
            }
            if (str != "")
                MessageBox.Show(str);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(isStarted)
                Stop();
            Environment.Exit(-1);
        }
    }
}
