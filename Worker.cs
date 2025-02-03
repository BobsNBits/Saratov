using System.Diagnostics;

namespace Saratov
{
    class Worker
    {
        public void Start(JobClass job, string args, bool silent, int program)
        {
            Process Worker = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            Worker.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            switch (program)
            {
                case 1: { Worker.StartInfo.FileName = "7z.exe"; break; }
                case 4: { Worker.StartInfo.FileName = "bsc.exe"; break; }
            }

            Worker.StartInfo.Arguments = args;

            if (silent == true)
            {
                Worker.StartInfo.RedirectStandardOutput = true;
                Worker.StartInfo.UseShellExecute = false;
                Worker.StartInfo.CreateNoWindow = true;
            }

            //Worker.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            Worker.Start();
            Worker.WaitForExit();
        }
    }
}
