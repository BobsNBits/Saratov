namespace Saratov
{
    public class ParameterClass
    {
        public string format { get; set; }
        public string algorithm { get; set; }
        public short level { get; set; }
        public short threads { get; set; }
        public short wordsize { get; set; }
        public int memory { get; set; }
        public ParameterClass(string format, string algorithm, short level, short threads, short wordsize, int memory)
        {
            this.format = format;
            this.algorithm = algorithm;
            this.level = level;
            this.threads = threads;
            this.wordsize = wordsize;
            this.memory = memory;
        }
    }
}
