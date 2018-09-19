using System.Collections.Generic;

namespace Spd3.Models.Entities
{
    public class TaxInspection
    {
		public int Id { get; set; }

		public string Name { get; set; }

		public int RegionId { get; set; }

		public Region Region { get; set; }

		public virtual ICollection<TaxPerson> TaxPersons { get; set; }
	}
}
