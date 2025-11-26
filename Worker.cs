using System;
using System.Diagnostics;
using System.Drawing;

namespace Saratov
{
    class Worker
    {
        public void Start(JobClass job, string args, Color silent, string program)
        {
            Process Worker = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            
            Worker.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory.ToString();
            switch (program)
            {
                case "7zip": { Worker.StartInfo.FileName = "7z.exe"; break; }
                case "BSC": { Worker.StartInfo.FileName = "bsc.exe"; break; }
            }    
            
            Worker.StartInfo.Arguments = args;
            
            if (silent == Color.Green) {
            Worker.StartInfo.RedirectStandardOutput = true;
            Worker.StartInfo.UseShellExecute = false;
            Worker.StartInfo.CreateNoWindow = true;}
            
            //TODO: BROKEY! CAUSES DEFOCUS!
            //Worker.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            

            Worker.Start();
            Worker.WaitForExit();
        }
    }
}
