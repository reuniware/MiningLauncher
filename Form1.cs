using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processInfo;
            Process process;

            String command = "";

            command = @"taskkill /F /IM xmrig.exe";
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            process = Process.Start(processInfo);
            process.WaitForExit();

            command = @"C:\tmp\githubprojects\xmrig\build\Release\xmrig.exe -o stratum+tcp://bcn.pool.minergate.com:45550 -u investdatasystems@yahoo.com -p x";
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

            Application.Exit();
        }
    }
}
