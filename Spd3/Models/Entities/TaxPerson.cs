namespace Spd.Models.Entities
{
    public class TaxPerson
    {
		public int Id { get; set; }
		public string IdentityId { get; set; }
		public TaxAccountant Identity { get; set; }
		public string Location { get; set; }
		public string Locale { get; set; }
		public string Gender { get; set; }
	}
}
