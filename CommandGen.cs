using System.IO;

namespace Saratov
{
    class CommandGen
    {
        public string Prepare(int programID, int actionID, string algorithm, int level, int memory, int wordSize, int threads, string format, JobClass job, bool deleteAfter)
        {
            FileInfo fi = new FileInfo(job.Address);
            Checks check = new Checks();
            Worker worker = new Worker();
            string command = null;

            string outputName = "";
            outputName = @"""" + job.Address + "." + format + @"""";

            switch (programID)
            {
                case 1: //7zip
                    {
                        if (level % 2 == 0 || (level < 1 || level > 9)) { level = 9; }

                        switch (actionID)
                        {
                            case 1:
                                {
                                    command =
                                        "a " + //Action
                                        outputName + //What it says
                                        " \"" + job.Address + "\"" + // Files to add
                                        " -m0=" + algorithm + //+ algorythms[algorythm] + //Algorythm
                                        " -mmt" + threads + //Cores
                                        " -mx" + level + //Level
                                        " -md" + memory + "m" + //memory size
                                        " -mfb" + wordSize; //Word size

                                    if (deleteAfter == true)
                                        command = command + " -sdel ";
                                    break;
                                }
                            case 2:
                                {
                                    command =
                                        "e " + //Action
                                        outputName; //What it says
                                    break;
                                }
                            case 3:
                                {
                                    command =
                                        "t " + //Action
                                        outputName; //What it says
                                    break;
                                }
                        }
                        break;
                    }
                case 2: //FreeARC
                    {
                        break;
                    }
                case 3: //MCM
                    {
                        break;
                    }
                case 4: //BSC
                    {
                        switch (actionID)
                        {
                            case 1: // Compress
                                {
                                    //TODO: Special logic to determine if to .tar a folder
                                    if (check.DirExists(job.Address.ToString()) == 1)
                                    {
                                        string tarcommand = "a " + @"""" + job.Address + ".tar" + @"""" + " \"" + job.Address + "\"";

                                        worker.Start(job, tarcommand, false, 1);

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
                            case 2:
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