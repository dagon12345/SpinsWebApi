namespace SpinsWebApi.Models
{
    public class Barangay
    {
        public long Id { get; set; }
        public int PSGCBrgy { get; set; }
        public string? BrgyName { get; set; }
        public int PSGCCityMun { get; set; }
        public int ClassificationID { get; set; }

        public string? Secret { get; set; }
    }
}