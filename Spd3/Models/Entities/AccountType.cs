using System.Collections.Generic;

namespace Spd3.Models.Entities
{
    public class TaxAccountType
    {
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<TaxAccount> TaxAccounts { get; set; }
	}
}
