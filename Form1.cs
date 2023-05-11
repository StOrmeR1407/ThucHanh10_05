using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThucHanh10_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exe(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(); 
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false; 
            startInfo.FileName = "D:\\jdk\\bin\\java.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            startInfo.WorkingDirectory = "D:\\jdk\\bin"; 
            startInfo.Arguments = $"duycop {textBox1.Text} {textBox2.Text}";
            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    while (!exeProcess.StandardOutput.EndOfStream)
{
                        string line = exeProcess.StandardOutput.ReadLine();
                        richTextBox1.AppendText(line + "\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"ERROR: {ex.Message}");
            }
        }
    }
}
