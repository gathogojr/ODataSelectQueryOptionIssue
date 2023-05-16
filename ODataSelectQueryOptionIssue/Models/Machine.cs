namespace ODataSelectQueryOptionIssue.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string? OnPremTag { get; set; }

        private List<string> machineTags = new List<string>();

        public List<string> MachineTags
        {
            get
            {
                if (OnPremTag != null && !machineTags.Any(d => d == OnPremTag))
                {
                    machineTags.Add(OnPremTag);
                }

                return machineTags;
            }
            set { machineTags = value; }
        }
    }
}
