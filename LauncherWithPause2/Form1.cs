using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiningLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProcessStartInfo processInfo;
        Process process;
        String command = "";

        private void stopXmrig()
        {
            command = @"taskkill /F /IM xmrig.exe";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            process = Process.Start(processInfo);
            process.WaitForExit();
        }

        private void startXmrig()
        {
            command = @"C:\tmp\githubprojects\xmrig\build\Release\xmrig.exe -o stratum+tcp://bcn.pool.minergate.com:45550 -u investdatasystems@yahoo.com -p x --safe --cpu-priority 5 --donate-level=1 --av=0 --threads=4";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            process = Process.Start(processInfo);
        }

        private void stopXmrminer()
        {
            command = @"taskkill /F /IM xmrMiner_0.2.1.exe";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            process = Process.Start(processInfo);
            process.WaitForExit();
        }

        private void startXmrminer()
        {
            command = @"C:\tmp\githubprojects\xmrMiner\xmrMiner_0.2.1.exe -o stratum+tcp://bcn.pool.minergate.com:45550 -u investdatasystems@yahoo.com -p x";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            process = Process.Start(processInfo);
        }

        private Boolean MinersAreRunning()
        {
            Process[] allProcs = Process.GetProcesses();
            foreach (Process proc in allProcs)
            {
                ProcessThreadCollection myThreads = proc.Threads;
                if (proc.ProcessName.ToLower().Contains("xmrig") || proc.ProcessName.ToLower().Contains("xmrminer"))
                {
                    return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopXmrig();
            startXmrig();
            stopXmrminer();
            startXmrminer();

            Thread thread = new Thread(this.DoWork);
            thread.Start();

            this.Visible = false;
        }

        DateTime dt;
        public void DoWork(object data)
        {
            while (true)
            {
                dt = DateTime.Now;
                if (    (dt.Minute >= 50 && dt.Minute <= 59) || (dt.Hour>=7 && dt.Hour<=20) )
                {
                    if (MinersAreRunning() == true)
                    {
                        stopXmrig();
                        stopXmrminer();
                    }
                }
                else
                {
                    if (MinersAreRunning() == false)
                    {
                        stopXmrig();
                        startXmrig();
                        stopXmrminer();
                        startXmrminer();
                    }
                }

                Thread.Sleep(1000);
            } // fin while true thread
        
        }
    }
}
