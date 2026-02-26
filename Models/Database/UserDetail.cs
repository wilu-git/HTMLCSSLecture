using System;
using System.Collections.Generic;

namespace HTMLCSSLecture.Models.Database;

public partial class UserDetail
{
    public int UserDetailsId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual User User { get; set; } = null!;
}
