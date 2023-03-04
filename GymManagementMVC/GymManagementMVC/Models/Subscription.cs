using System;
using System.Collections.Generic;

namespace GymManagementMVC.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            MemberSubscriptions = new HashSet<MemberSubscription>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public short NumberOfMonths { get; set; }
        public string WeekFrequency { get; set; } = null!;
        public int TotalNumberOfSessions { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<MemberSubscription> MemberSubscriptions { get; set; }
    }
}
