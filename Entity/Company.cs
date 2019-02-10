using System;

namespace Entity
{
	public class Company
	{
		public Guid Id { get; set; }
		public Guid ParentId { get; set; }
		public byte[] RowVersion { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int LevelIndex { get; set; }
		public bool HasChildren { get; set; }
		public byte LookingFor { get; set; }
	}
}
