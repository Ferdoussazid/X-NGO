using System;
namespace assignment.DTOs
{
	public class EmployeeDTO
	{
        public int Eid { get; set; }
        public string Name { get; set; } = null!;
        public int Number { get; set; }
        public virtual ICollection<CollectionRequestDTO> CollectionRequests { get; set; } = new List<CollectionRequestDTO>();
    }
}

