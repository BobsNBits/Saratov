using System.Drawing;
using System.IO;

namespace Saratov
{
    class CommandGenerator
    {
        public string Prepare(string program, string action, string algorithm, string level, string memory,
                              string wordSize, string threads, string format, JobClass job, Color deleteAfter)
        {
            FileInfo fi = new FileInfo(job.Address);
            Checks check = new Checks();
            Worker worker = new Worker();

            string command = null;
            string outputName = @"""" + job.Address + "." + format + @"""";

            switch (program)
            {
                case "7zip":
                    {
                        switch (action)
                        {
                            case "Add":
                                {
                                    command = "a " + //Action
                                        outputName + //What it says
                                        " \"" + job.Address + "\""; // Files to add

                                    if (algorithm == "") { command += " -m0=LZMA2"; } //Algorythm
                                    if (threads != "") { command += " -mmt" + threads; } //Cores
                                    if (level != "") { command += " -mx" + level; } //Level
                                    if (memory != "") { command += " -md" + memory + "m"; } //Dictionary(memory) size
                                    if (wordSize != "") { command += " -mfb" + wordSize; } //Word size

                                    if (deleteAfter == Color.Green)
                                        command = command + " -sdel ";
                                    break;
                                }
                            case "Extract":
                                {
                                    command = "e " + outputName; //Action + Output name
                                    break;
                                }
                            case "Test":
                                {
                                    command =
                                        "t " + //Action
                                        outputName; //What it says
                                    break;
                                }
                        }
                        break;
                    }
                case "FreeARC":
                    {
                        break;
                    }
                case "MCM":
                    {
                        break;
                    }
                case "BSC":
                    {
                        switch (action)
                        {
                            case "Add":
                                {
                                    if (check.DirExists(job.Address.ToString()) == 1)
                                    {
                                        string tarcommand = "a " + @"""" + job.Address + ".tar" + @"""" + " \"" + job.Address + "\"";

                                        worker.Start(job, tarcommand, Color.Firebrick, "7zip");

                                        string tarfile = job.Address + ".tar";

                                        command =
                                            "e" + //Action
                                            " \"" + tarfile + "\" " + // File(s) location
                                            @"""" + tarfile + ".bsc" + @"""" + //Output Name
                                            " -b" + memory + //Dictionary Size
                                            " -m" + algorithm + //Algorythm
                                            " -e2" + //Another Algorythm option, Entropy Encoding
                                            " -G -P "; //Special Options
                                    }
                                    else
                                    {
                                        command =
                                            "e" + //Action
                                            " \"" + job.Address + "\" " + // File(s) location
                                            outputName + //What is says
                                            " -b" + memory + //Dictionary Size
                                            " -m" + algorithm + //Algorythm
                                            " -e2" + //Another Algorythm option, Entropy Encoding
                                            " -G -P "; //Special Options
                                    }
                                    break;
                                }
                            case "Extract":
                                {
                                    command =
                                        "d" +
                                        Path.GetFileName(outputName); //What is says
                                    break;
                                }
                        }
                        break;
                    }
            }
            return command;
        }
    }
}