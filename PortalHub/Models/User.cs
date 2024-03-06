using System;
using System.Collections.Generic;

namespace PortalHub.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public bool? EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }

    public bool? IsActive { get; set; }

    public string? Badge { get; set; }

    public string? UserName { get; set; }

    public string? Name { get; set; }

    public int? CompanyKey { get; set; }

    public int? DepartmentNo { get; set; }

    public int? PositionKey { get; set; }

    public int? PictureId { get; set; }
}
