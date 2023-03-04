using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        [DisplayName("Number Of Months")]
        public short NumberOfMonths { get; set; }

		[DisplayName("Week Frequency")]
		public string WeekFrequency { get; set; } = null!;

		[DisplayName("Total Number Of Sessions")]
		public int TotalNumberOfSessions { get; set; }

		[DisplayName("Total Price")]
		public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<MemberSubscription> MemberSubscriptions { get; set; }
    }
}
