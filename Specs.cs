using System.Management;

namespace Saratov
{
    public class Specs
    {
        ManagementObjectSearcher ProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");
        ManagementObjectSearcher MemoryObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
        ManagementObjectSearcher VideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

        public uint coresCPU()
        {
            uint cores = 0;
            foreach (ManagementObject obj in ProcessorObject.Get())
            {
                cores += (uint)obj["NumberOfCores"];
            }
            return cores;
        }
        public uint threadsCPU()
        {
            uint threads = 0;
            foreach (ManagementObject obj in ProcessorObject.Get())
            {
                threads += (uint)obj["NumberOfLogicalProcessors"];
            }
            return threads;
        }
        public uint availableRAM()
        {
            uint availableram = 0;
            foreach (ManagementObject obj in MemoryObject.Get())
            {
                availableram = (uint.Parse(obj["FreePhysicalMemory"].ToString())) / 1024;
            }
            return availableram;
        }
        public uint totalRAM()
        {
            uint totalram = 0;
            foreach (ManagementObject obj in MemoryObject.Get())
            {
                totalram = (uint.Parse(obj["TotalVisibleMemorySize"].ToString())) / 1024;
            }
            return totalram;
        }
        public uint totalVRAM()
        {
            uint totalVram = 0;
            foreach (ManagementObject obj in VideoObject.Get())
            {
                totalVram = (uint.Parse(obj["AdapterRAM"].ToString())) / (1024 * 1024);
            }
            return totalVram;
        }
    }
}
