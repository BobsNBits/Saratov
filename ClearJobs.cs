using System.Windows.Forms;
using System.ComponentModel;

namespace Saratov
{
    class ClearJobs
    {
        public static BindingList<JobClass> Done(BindingList<JobClass> jobs)
        {
            var mesBoxResult = MessageBox.Show("Remove completed jobs?", "Confirmation",
                                                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            switch (mesBoxResult)
            {
                case DialogResult.OK:
                    {
                        int listLenght = jobs.Count;
                        do
                        {
                            int i = jobs.Count - listLenght;
                            if (jobs[i].State == "DONE")
                            {
                                jobs.Remove(jobs[i]);
                            }
                            listLenght -= 1;
                        }
                        while (listLenght != 0);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return jobs;
        }
        public static BindingList<JobClass> All(BindingList<JobClass> jobs)
        {
            var mesBoxResult = MessageBox.Show("You are about to clear ALL jobs in the list \nProceed?", "Confirmation",
                                                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            switch (mesBoxResult)
            {
                case DialogResult.OK:
                    {
                        jobs.Clear();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return jobs;
        }
    }
}
