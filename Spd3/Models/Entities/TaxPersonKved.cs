using System.Collections.Generic;

namespace Spd3.Models.Entities
{
	public class TaxPersonKved
	{
		public int Id { get; set; }

		public int TaxPersonId { get; set; }

		public TaxPerson TaxPerson { get; set;}

		public string KvedCode { get; set; }

		public string KvedName { get; set; }
    }
}
