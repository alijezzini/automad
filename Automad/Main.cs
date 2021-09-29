using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Automad
{
    public partial class Main : Form
    {
        public List<String> nums;
        public int tested;
        public delegate void increment();
        public increment myDelegate;
        public delegate void SuccessInc();
        public SuccessInc incrementSucc;

        public String dest = "";
        public int appnum;
        public int execapp;
        public int count;
        String path;
        public bool pause = false;

        public delegate void connec();
        public connec connected;
        public delegate void noconnec();
        public noconnec notconnected;
        public delegate void autoImp();
        public autoImp atImport;

        public delegate void autoreset();
        public autoreset atReset;

        public string currentStatus = "Up";
        public bool testing = false;
        public bool connectionstatus = true;
        public bool cache = true;
        public Queue<int> profiles;
        public Queue<Object> ObjectQueue;
        public String proxyport = "null";
        public bool handling = false;
        Thread checkingconn;
        Thread driverCh;
        Thread CTrun;
        connection cxn;

        public int MaxParallelThreads;

        public Main()
        {
            InitializeComponent();
            cxn = new connection();
            nums = new List<string>();
            MaxParallelThreads = 3;
            ObjectQueue = new Queue<object>();

            succounter.Text = Properties.Settings.Default.successCount.ToString();
            statuslabel.Text = "";
            count = 0;
            tested = 0;
            this.Refresh();
            myDelegate = new increment(incrementnum);
            incrementSucc = new SuccessInc(IncrementSuccess);
            connected = new connec(conn);
            notconnected = new noconnec(noconn);
            atReset = new autoreset(resetaction);
            appnum = 0;
            execapp = 0;
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            profiles = new Queue<int>();
            profiles.Enqueue(1);
            profiles.Enqueue(2);
            profiles.Enqueue(3);
            profiles.Enqueue(4);
            profiles.Enqueue(5);
            profiles.Enqueue(6);

        }

        public void conn()
        {
            connectionstatus = true;
        }
        public void noconn()
        {
            connectionstatus = false;
        }
        public void incrementnum()
        {
            MaxParallelThreads++;
            tested++;
            double percent = (tested * 100) / (count * execapp);
            percentage.Text = percent.ToString() + " %";
            if (tested == (execapp * count))
            {
                testing = false;
                CTrun.Abort();
                checkingconn.Abort();
                driverCh.Abort();

                statuslabel.Text = "Finished!";
                testfinish.Text = "Test finished at " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                runButton.Enabled = true;
                pause = false;
                testing = false;

                foreach (var process in Process.GetProcessesByName("chrome"))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {

                    }
                }
                foreach (var process in Process.GetProcessesByName("chromedriver"))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {

                    }
                }
                this.Refresh();
                Thread.Sleep(1000);
                if (replay.Checked)
                {
                    runButton.PerformClick();
                }
                pausebtn.Enabled = false;
                stopbtn.Enabled = false;
            }

            this.Refresh();
        }

        private void run_Click(object sender, EventArgs e)
        {
            if (appnum > 0)
            {
                
                testing = true;
                MaxParallelThreads = 3;
                CheckConnection co = new CheckConnection(this);
                checkingconn = new Thread(new ThreadStart(co.Check));
                checkingconn.Start();

                DriverCheck drCh = new DriverCheck();
                driverCh = new Thread(new ThreadStart(drCh.run));
                driverCh.Start();

                runButton.Enabled = false;
                tested = 0;
                execapp = appnum;
                List<string> testingnums = new List<string>();
                testingnums = nums;

                String number = "";
                if (radioButton1.Checked)
                {
                    count = 1;
                }
                else if (radioButton2.Checked)
                {
                    count = testingnums.Count();
                }

                statuslabel.Text = "Testing...";
                teststart.Text = "Test started at " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                testfinish.Text = "";
                percentage.Text = "";
                this.Refresh();
                for (int i = 0; i < count; i++)
                {
                    if (radioButton1.Checked)
                    {
                        number = numberbox.Text;
                    }
                    else if (radioButton2.Checked)
                    {
                        number = testingnums.ElementAt(i);
                    }
                    if (!number[0].Equals('+'))
                    {
                        number = "+" + number;
                    }
                    String[] res = new String[2];
                    res = mymethods.detectnum(number);
                    String code = res[0];
                    String num = res[1];

                    if (Microsoftch.Checked)
                    {
                        Microsoft microsoft = new Microsoft(code, num, this);
                        ObjectQueue.Enqueue(microsoft);
                    }
                    if (Googlech.Checked)
                    {
                        Google google = new Google(code, num, this);
                        ObjectQueue.Enqueue(google);
                    }
                    if (Transferch.Checked)
                    {
                        Transfergo transfer = new Transfergo(code, num, this);
                        ObjectQueue.Enqueue(transfer);
                    }

                    if (Instagramch.Checked)
                    {
                        Instagram instagram = new Instagram(code, num, this);
                        ObjectQueue.Enqueue(instagram);
                    }

                    if (Larkch.Checked)
                    {
                        Lark Lark = new Lark(code, num, this);
                        ObjectQueue.Enqueue(Lark);
                    }
                }
                ControllerThread CT = new ControllerThread(this);
                CTrun = new Thread(new ThreadStart(CT.run));
                CTrun.Start();
                pausebtn.Enabled = true;
                stopbtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please select an App ", "No Apps Selected ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void OpenFile(String path)
        {
            importlabel.Text = "";
            importlabel.Text = "Importing...";
            try
            {
                Excel excel = new Excel(@path, 1);
                importlabel.Refresh();
                nums.Clear();
                nums = excel.numlist();
                count = nums.Count;
                if (nums.Count == 1)
                    importlabel.Text = "1 number imported";
                else
                    importlabel.Text = nums.Count + " numbers imported";
                runButton.Enabled = true;
            }
            catch
            {
                MessageBox.Show("An error occured while trying to import the excel sheet", "Can't Import Excel Sheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pathlabel.Text = "";
                importlabel.Text = "";
            }

        }

        public void ReleaseProfile(int id)
        {
            profiles.Enqueue(id);
        }

        public void IncrementSuccess()
        {
            Properties.Settings.Default.successCount++;
            Properties.Settings.Default.Save();
            succounter.Text = Properties.Settings.Default.successCount.ToString();
        }

        public int getProfile()
        {
            int pp = 0;
            lock (this)
            {
                if (profiles.Count > 0)
                {
                    pp = profiles.Dequeue();
                }
                else
                {
                    if (!handling)
                    {
                        handling = true;
                        profiles.Clear();
                        foreach (var process in Process.GetProcessesByName("chrome"))
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch
                            {

                            }
                        }
                        profiles.Enqueue(1);
                        profiles.Enqueue(2);
                        profiles.Enqueue(3);
                        profiles.Enqueue(4);
                        profiles.Enqueue(5);
                        profiles.Enqueue(6);

                        pp = profiles.Dequeue();
                        handling = false;
                    }
                }
            }

            return pp;
        }

        public void ReleaseMem()
        {
            foreach (var process in Process.GetProcessesByName("chrome"))
            {
                try
                {
                    process.Kill();
                }
                catch
                {

                }
            }
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                try
                {
                    process.Kill();
                }
                catch
                {

                }
            }
        }


        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select Number List";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "(*.xlsx)|*.xlsx";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                path = @fdlg.FileName;
                pathlabel.Text = Path.GetFileName(path);
                OpenFile(path);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numberbox.Enabled = true;
            ImportButton.Enabled = false;
            if (numberbox.Text.Length == 0)
            {
                runButton.Enabled = false;
            }
            else
            {
                runButton.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numberbox.Enabled = false;
            ImportButton.Enabled = true;
            if (nums.Count == 0)
            {
                runButton.Enabled = false;
            }
            else
            {
                runButton.Enabled = true;
            }
        }

        private void numberbox_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (!numberbox.Text.Equals(""))
                {
                    runButton.Enabled = true;
                }
                else
                {
                    runButton.Enabled = false;
                }
            }
        }
        private void Ch_OnChange(object sender, EventArgs e)
        {
            CheckBox Ch = (CheckBox)sender;
            if (Ch.Checked)
            {
                appnum++;
            }
            else
            {
                appnum--;
            }

        }


        private void Pause_Click(object sender, EventArgs e)
        {
            if (!pause)
            {
                pause = true;
                MaxParallelThreads = 0;
                statuslabel.Text = "Paused";
                pausebtn.Text = "Resume";

            }
            else
            {
                pause = false;
                pausebtn.Text = "Pause";
                statuslabel.Text = "Testing...";
            }
        }


        public void OnProcessExit(object sender, EventArgs e)
        {
            ReleaseMem();
        }

        public void resetaction()
        {
            runButton.Enabled = true;
            pause = false;
            testing = false;
            ObjectQueue.Clear();
            runButton.PerformClick();
        }

        private void succounter_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset success counter", "Success Reset", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Properties.Settings.Default.successCount = 0;
                Properties.Settings.Default.Save();
                succounter.Text = "0";
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            MaxParallelThreads = 0;
            runButton.Enabled = true;
            pause = false;
            testing = false;
            pausebtn.Enabled = false;
            stopbtn.Enabled = false;
            tested = 0;

            ObjectQueue.Clear();
            ReleaseMem();
            statuslabel.Text = "Stopped!!";
            pausebtn.Text = "Pause";
            percentage.Text = "";
            this.Refresh();
        }

        private void logout_button(object sender, EventArgs e)
        {

        }
    }
}
