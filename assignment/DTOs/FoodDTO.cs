using System;
namespace assignment.DTOs
{
	public class FoodDTO
	{
        public int Fid { get; set; }
        public int Cid { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public DateOnly Expire { get; set; }
        public CollectionRequestDTO CidNavigation { get; set; } = null!;
    }
}

