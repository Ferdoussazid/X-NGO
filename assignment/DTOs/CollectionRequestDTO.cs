using System;
namespace assignment.DTOs
{
	public class CollectionRequestDTO
	{
        public int Cid { get; set; }
        public int Rid { get; set; }
        public int Eid { get; set; }
        public string MaxPreservationTime { get; set; } = null!;
        public string Status { get; set; } = null!;
        public EmployeeDTO EidNavigation { get; set; } = null!;
        public ICollection<FoodDTO> Foods { get; set; } = new List<FoodDTO>();
    }
}

