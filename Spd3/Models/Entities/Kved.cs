using System.Collections.Generic;

namespace Spd.Models.Entities
{
	public class Kved
	{
		public string Code { get; set; }
		public string ParentCode { get; set; }
		public string Name { get; set; }
		public virtual Kved ParentKved { get; set; }
		public virtual ICollection<Kved> ChildrenKvedList { get; set; }
	}
}
