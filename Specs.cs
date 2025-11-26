using System.Management;
using NvAPIWrapper.GPU;

namespace Saratov
{
    public class Specs
    {
        ManagementObjectSearcher ProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");
        ManagementObjectSearcher MemoryObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

        PhysicalGPU[] gpus = PhysicalGPU.GetPhysicalGPUs();
        public int coresCPU()
        {
            uint cores = 0;
            foreach (ManagementObject obj in ProcessorObject.Get())
            {
                cores += (uint)obj["NumberOfCores"];
            }
            return (int)cores;
        }
        public int ThreadsCPU()
        {
            uint threads = 0;
            foreach (ManagementObject obj in ProcessorObject.Get())
            {
                threads += (uint)obj["NumberOfLogicalProcessors"];
            }
            return (int)threads;
        }
        public uint AvailableRAM()
        {
            uint availableRAM = 0;
            foreach (ManagementObject obj in MemoryObject.Get())
            {
                availableRAM = (uint.Parse(obj["FreePhysicalMemory"].ToString())) / 1024;
            }
            return availableRAM;
        }
        public uint TotalRAM()
        {
            uint totalRAM = 0;
            foreach (ManagementObject obj in MemoryObject.Get())
            {
                totalRAM = (uint.Parse(obj["TotalVisibleMemorySize"].ToString())) / 1024;
            }
            return totalRAM;
        }
        public uint TotalVRAM()
        {

            uint totalVRAM = gpus[0].MemoryInformation.AvailableDedicatedVideoMemoryInkB /1024 ;
            return totalVRAM;
        }
        public uint AvailableVRAM()
        {
            uint availableVRAM = gpus[0].MemoryInformation.CurrentAvailableDedicatedVideoMemoryInkB / 1024;
            return availableVRAM;
        }
    }
}
