using Microsoft.AspNetCore.Identity;

namespace GymManagementMVC.Models;

public class ApplicationUser : IdentityUser<int>
{
    public ApplicationUser()
    {
        MemberSubscriptions = new HashSet<MemberSubscription>();
    }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Birthday { get; set; }
    public Guid CardNumber { get; set; }
    public DateTime RegristrationDate { get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<MemberSubscription> MemberSubscriptions { get; set; }
}
