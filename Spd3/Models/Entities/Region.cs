using System.Collections.Generic;

namespace Spd3.Models.Entities
{
	public class Region
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<TaxInspection> TaxInspections { get; set; }
    }
}
