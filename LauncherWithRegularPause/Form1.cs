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

        private void button1_Click(object sender, EventArgs e)
        {
            command = @"taskkill /F /IM xmrig.exe";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            process = Process.Start(processInfo);
            process.WaitForExit();

            command = @"C:\tmp\githubprojects\xmrig\build\Release\xmrig.exe -o stratum+tcp://bcn.pool.minergate.com:45550 -u investdatasystems@yahoo.com -p x --safe --cpu-priority 5 --donate-level=1 --av=0 --threads=4";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            process = Process.Start(processInfo);

            command = @"taskkill /F /IM xmrMiner_0.2.1.exe";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            process = Process.Start(processInfo);
            process.WaitForExit();

            command = @"C:\tmp\githubprojects\xmrMiner\xmrMiner_0.2.1.exe -o stratum+tcp://bcn.pool.minergate.com:45550 -u investdatasystems@yahoo.com -p x";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            process = Process.Start(processInfo);

            Thread thread = new Thread(this.DoWork);
            thread.Start();

            //Application.Exit();
        }

        DateTime dt;
        public void DoWork(object data)
        {
            while (true)
            {
                dt = DateTime.Now;
                if (dt.Minute >= 13 && dt.Minute <= 14)
                {
                    command = @"taskkill /F /IM xmrig.exe";
                    processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                    processInfo.CreateNoWindow = true;
                    processInfo.UseShellExecute = false;
                    processInfo.RedirectStandardError = false;
                    processInfo.RedirectStandardOutput = false;
                    process = Process.Start(processInfo);
                    process.WaitForExit();

                    command = @"taskkill /F /IM xmrMiner_0.2.1.exe";
                    processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                    processInfo.CreateNoWindow = true;
                    processInfo.UseShellExecute = false;
                    processInfo.RedirectStandardError = false;
                    processInfo.RedirectStandardOutput = false;
                    process = Process.Start(processInfo);
                    process.WaitForExit();
                }
                else
                {
                    Boolean found = false;
                    Process[] allProcs = Process.GetProcesses();
                    foreach (Process proc in allProcs)
                    {
                        ProcessThreadCollection myThreads = proc.Threads;
                        if (proc.ProcessName.ToLower().Contains("xmrig"))
                        {
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        command = @"taskkill /F /IM xmrig.exe";
                        processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                        processInfo.CreateNoWindow = true;
                        processInfo.UseShellExecute = false;
                        processInfo.RedirectStandardError = false;
                        processInfo.RedirectStandardOutput = false;
                        process = Process.Start(processInfo);
                        process.WaitForExit();

                        command = @"C:\tmp\githubprojects\xmrig\build\Release\xmrig.exe -o stratum+tcp://bcn.pool.minergate.com:45550 -u investdatasystems@yahoo.com -p x --safe --cpu-priority 5 --donate-level=1 --av=0 --threads=4";
                        processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                        processInfo.CreateNoWindow = true;
                        processInfo.UseShellExecute = false;
                        processInfo.RedirectStandardError = false;
                        processInfo.RedirectStandardOutput = false;
                        process = Process.Start(processInfo);

                        command = @"taskkill /F /IM xmrMiner_0.2.1.exe";
                        processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                        processInfo.CreateNoWindow = true;
                        processInfo.UseShellExecute = false;
                        processInfo.RedirectStandardError = false;
                        processInfo.RedirectStandardOutput = false;
                        process = Process.Start(processInfo);
                        process.WaitForExit();

                        command = @"C:\tmp\githubprojects\xmrMiner\xmrMiner_0.2.1.exe -o stratum+tcp://bcn.pool.minergate.com:45550 -u investdatasystems@yahoo.com -p x";
                        processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                        processInfo.CreateNoWindow = true;
                        processInfo.UseShellExecute = false;
                        processInfo.RedirectStandardError = false;
                        processInfo.RedirectStandardOutput = false;
                        process = Process.Start(processInfo);
                    }
                }

                Thread.Sleep(1000);
            } // fin while true thread
        
        }
    }
}
