using System.Linq;
using System.Security.Principal;
using System.IO;

namespace Saratov
{
    class Checks
    {
        public string IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if (principal.IsInRole(WindowsBuiltInRole.Administrator) == false)
            {
                return "Elevation: User";
            }
            else return "Elevation: ADMINISTRATOR!!";
        }
        public int DirExists(string path)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(path);
            if (dirinfo.Exists == true)
                return 1;
            else
                return 0;
        }
        public int FileExists(string path)
        {
            FileInfo fileinfo = new FileInfo(path);
            if (fileinfo.Exists == true)
                return 1;
            else
                return 0;
        }
        public int DirOrFile(string path)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(path);
            FileInfo fileinfo = new FileInfo(path);
            if (dirinfo.Exists == true)
                return 1;
            else if (fileinfo.Exists == true)
                return 2;
            else return 0;
        }
        public int DirType(string path)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(path);
            FileInfo fileinfo = new FileInfo(path);
            if (dirinfo.Exists == true && fileinfo.Exists == false)
            {
                //string dirRoot = dirinfo.Root.ToString(); <- idk what this was for, probably some root lookup
                if (path.Length <= 3)
                    return 1; //Drive/Partition
                else return 2; //Folder
            }
            return -1; //Probably a File
        }
        public float Size(string path)
        {
            if (DirOrFile(path) == 2)
            {
                return FileSize(path);
            }
            if (DirType(path) == 2)
            {
                DirectoryInfo dirinfo = new DirectoryInfo(path);
                return dirinfo.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(Files => Files.Length) / 1024 / 1024;
            }
            else
                return -1;
        }
        public float FileSize(string path)
        {
            FileInfo fi = new FileInfo(path);
            return (fi.Length / 1024) / 1024;
        }
    }
}
