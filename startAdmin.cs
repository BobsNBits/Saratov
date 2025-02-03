using System.Diagnostics;

namespace Saratov
{
    class StartAdmin
    {
        public void ExecuteAsAdmin(string filename)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = filename;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }
    }
}
