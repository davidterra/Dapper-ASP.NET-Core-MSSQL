using System.Collections.Generic;

namespace Dummy.ViewModel
{
    public class GroupByCategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IEnumerable<GroupByCategoryProductViewModel> Products { get; set; }
    }

    public class GroupByCategoryProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }

    }
}