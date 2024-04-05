using System.Diagnostics.Eventing.Reader;

namespace SpinsWebApi.Models
{
    public class BarangayDTO
    {
        public long Id { get; set; }
        public int PSGCBrgy { get; set; }
        public string? BrgyName { get; set; }
        public int PSGCCityMun { get; set; }
        public int ClassificationID { get; set; }

        public bool IsComplete { get; set; }
    }
}