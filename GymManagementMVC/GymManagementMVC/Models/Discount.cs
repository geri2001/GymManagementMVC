using System;
using System.Collections.Generic;

namespace GymManagementMVC.Models
{
    public partial class Discount
    {
        public Discount()
        {
            DiscountedMemberSubscriptions = new HashSet<DiscountedMemberSubscription>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool DeactivationDate { get; set; }

        public virtual ICollection<DiscountedMemberSubscription> DiscountedMemberSubscriptions { get; set; }
    }
}
