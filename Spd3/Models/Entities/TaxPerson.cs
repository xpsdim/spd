using System.Collections.Generic;

namespace Spd3.Models.Entities
{
    public class TaxPerson
    {
		public int Id { get; set; }

		public string IdentityId { get; set; }

		public AppUser Identity { get; set; }
		
		public string FullName { get; set; }

		public string TaxCode { get; set; }

		public string ZipCode { get; set; }

		public string City { get; set; }

		public string Street { get; set; }

		public virtual ICollection<TaxPersonKved> TaxPersonKveds { get; set; }

		public int TaxInspectionId { get; set; }

		public TaxInspection TaxInspection { get; set; }
	}
}
