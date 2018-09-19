using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spd3.Models.Entities
{
	public class TaxAccount
	{
		public int Id { get; set; }

		public int AccountTypeId { get; set; }

		public TaxAccountType TaxAccountType { get; set; }

		public string Mfo { get; set; }

		public string BankName { get; set; }

		public string Edrpou { get; set; }

		public string Account { get; set; }

		public string Name { get; set; }

    }
}
