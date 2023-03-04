using System;
using System.Collections.Generic;

namespace GymManagementMVC.Models
{
    public partial class DiscountedMemberSubscription
    {
        public int Id { get; set; }
        public int MemberSubscriptionsId { get; set; }
        public int DiscountsId { get; set; }

        public virtual Discount Discounts { get; set; } = null!;
        public virtual MemberSubscription MemberSubscriptions { get; set; } = null!;
    }
}
