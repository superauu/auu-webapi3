namespace Auu.Models.System.Backup.Admin
{
    public class MLocationBase
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string county { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string stateOrProvince { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string UserId { get; set; }
    }

    public class MLocationRequest : MLocationBase
    {
        public string[] locationType { get; set; }
    }

    public class MLocation : MLocationBase
    {
        public string locationType { get; set; }
    }

    public class MLocationEbay : MLocationBase
    {
        public string locationType { get; set; }
        public string merchantLocationStatus { get; set; }
    }

    public class EmailAndLocation
    {
        public string email { get; set; }
        public string location { get; set; }
    }

    public class DeployEbay
    {
        public MLocation location { get; set; }
        public string[] emails { get; set; }
    }
}