namespace Saratov
{
    public class JobClass
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public double SizeBefore { get; set; }
        public double SizeAfter { get; set; }
        public string Type { get; set; }
        public JobClass(int id, string address, string state, double sizeBefore, double sizeAfter, string type)
        {
            this.ID = id;
            this.Address = address;
            this.State = state;
            this.SizeBefore = sizeBefore;
            this.SizeAfter = sizeAfter;
            this.Type = type;
        }
    }
}
