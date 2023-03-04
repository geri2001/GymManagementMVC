using System;
using System.Collections.Generic;

namespace GymManagementMVC.Models
{
    public partial class MemberSubscription
    {
        public MemberSubscription()
        {
            DiscountedMemberSubscriptions = new HashSet<DiscountedMemberSubscription>();
        }

        public int Id { get; set; }
        public int AspNetUsersId { get; set; }
        public int SubscriptionsId { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal PaidPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RemainingSessions { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ApplicationUser AspNetUsers { get; set; } = null!;
        public virtual Subscription Subscriptions { get; set; } = null!;
        public virtual ICollection<DiscountedMemberSubscription> DiscountedMemberSubscriptions { get; set; }
    }
}
