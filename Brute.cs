using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Saratov
{
    class Brute //Not So Evil Best Compression Brute Forcer
    {
        public void Start(JobClass job, Color silent)
        {
            Checks check = new Checks();
            Worker worker = new Worker();

            Process brute = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            Specs specs = new Specs();

            string[] programs = { "7zip", "BSC" };
            List<string> outputFiles = new List<string>();

            if (silent == Color.Green)
            {
                brute.StartInfo.RedirectStandardOutput = true;
                brute.StartInfo.UseShellExecute = false;
                brute.StartInfo.CreateNoWindow = true;
            }

            brute.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory.ToString();

            foreach (string program in programs)
            {
                switch (program)
                {
                    case "7zip":
                        {
                            brute.StartInfo.FileName = "7z.exe";

                            #region Determine Ram
                            int currentlyAvailableRam = (int)specs.AvailableRAM();
                            int[] memoryOptions = { 64, 96, 128, 192, 256, 384, 512, 768, 1024, 2048, 3072, 3840 };
                            int memorySelector = memoryOptions.Length - 1;
                            int expectedMemoryUtilization;
                            do
                            {
                                expectedMemoryUtilization = memoryOptions[memorySelector] * 11;
                                //MessageBox.Show("Will Use: " + expectedMemoryUtilization.ToString() + " MB" , "Debug");
                                memorySelector--;
                            }
                            while (expectedMemoryUtilization > currentlyAvailableRam);
                            #endregion

                            #region Command Generation
                            brute.StartInfo.Arguments = "a "; //Add to archvie

                            switch (check.DirOrFile(job.Address))
                            {
                                // Logic for edge case for folders with '.'
                                case 2:
                                    {
                                        brute.StartInfo.Arguments += "\"" + Path.ChangeExtension(job.Address, null) + "\"" + ".7z ";
                                        //Name of archive (file) with output location
                                        break;
                                    }
                                default:
                                    {
                                        brute.StartInfo.Arguments += "\"" + job.Address + "\"" + ".7z ";
                                        //Name of archive (folder) with output location
                                        break;
                                    }
                            }
                            
                            brute.StartInfo.Arguments +=
                                            "\"" + job.Address + "\"" + // Files to add
                                            " -m0=LZMA2" + //Algorythm
                                            " -mmt2" + //Threads
                                            " -mx9" + //Level
                                            " -md" + memoryOptions[memorySelector] + "m" + //Dictionary size
                                            " -mfb273"; //Word size

                            #endregion

                            brute.Start(); brute.WaitForExit();

                            #region Result listing
                            outputFiles.Add(Path.ChangeExtension(job.Address, null) + ".7z");
                            //if (check.FileExists(outputFiles[outputFiles.Count - 1]) == 0) { }
                            //TODO: Error handling when a file isnt made
                            //outputFiles.Remove[outputFiles.Count - 1]; - Remove what we added
                            #endregion

                            break;
                        }
                    case "BSC":
                        {
                            bool taredFolder = false;
                            brute.StartInfo.FileName = "bsc.exe";

                            #region Determine Video Ram (Block Size)
                            int currentlyAvailableVram = (int)specs.AvailableVRAM();
                            int dictionarySize = (int)((currentlyAvailableVram / 20) * 0.9);
                            #region BSC Memory Consumption Explanation
                            /*
                            Memory usage:
                            -------------
                            bsc compresses large files in blocks. Multiple blocks can be processed in
                            parallel on multiple-core CPU. At decompression time, the block size used
                            for compression is read from the header of the compressed file. The block
                            size and number of blocks processed in parallel affects both the compression
                            ratio achieved, and the amount of memory needed for compression and decompression.
                            Compression and decompression requirements are the same and in bytes, can
                            be estimated as 16Mb + 5 x block size x number of blocks processed in parallel.

                            GPU memory usage for NVIDIA CUDA technology is different from CPU memory usage
                            and can be estimated as 
                            -> 20 x block size for ST, 
                            21 x block size for forward BWT and 
                            7 x block size for inverse BWT.
                            */
                            #endregion
                            #endregion

                            #region Check if task is a folder, tar it, if so and run.
                            if (check.DirExists(job.Address.ToString()) == 1)
                            {
                                //If the process dosen't complete, data loss may occur, opt for file size comparison.
                                //If (file.tar >= job.SizeBefore)
                                if (check.FileExists(job.Address + ".tar") == 0)
                                {
                                    string tarcommand = "a " + @"""" + job.Address + ".tar" + @"""" + " \"" + job.Address + "\"";

                                    worker.Start(job, tarcommand, Color.Firebrick, "7zip");
                                    taredFolder = true;
                                }
                                brute.StartInfo.Arguments = "e" + //Action
                                            " \"" + job.Address + ".tar" + "\" " + // File(s) location
                                            " \"" + job.Address + ".tar" + "\"" + ".bsc" + // Output Name
                                            " -G -P -cp -e2"; //Use GPU + 2MB Pages
                            }
                            #endregion

                            #region Run normally for one file
                            else
                            {
                                brute.StartInfo.Arguments = "e" + //Action
                                            " \"" + job.Address + "\" " + // File(s) location
                                            " \"" + job.Address + "\"" + ".bsc" + // Output Name
                                            " -G -P -cp -e2"; //Use GPU + 2MB Pages
                            }
                            #endregion

                            brute.Start(); brute.WaitForExit();

                            #region Cleanup and result listing
                            if (taredFolder == true)
                            {
                                outputFiles.Add(job.Address + ".tar.bsc");
                                File.Delete(job.Address + ".tar");
                            }
                            else
                            {
                                outputFiles.Add(job.Address + ".bsc");
                            }
                            #endregion

                            break;
                        }
                }
            }
            #region Compare and delete each resulting file
            while (outputFiles.Count > 1)
            {
                if (check.FileSizeKB(outputFiles[0]) < check.FileSizeKB(outputFiles[1]))
                {
                    File.Delete(outputFiles[1]);
                    outputFiles.RemoveAt(1);
                }
                else if (check.FileSizeKB(outputFiles[0]) > check.FileSizeKB(outputFiles[1]))
                {
                    File.Delete(outputFiles[0]);
                    outputFiles.RemoveAt(0);
                }
            }

            job.State = "DONE";
            job.SizeAfter = check.SizeOf(outputFiles[0]);
            #endregion
        }
    }
}
