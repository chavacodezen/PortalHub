using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalHub.Models;

public partial class User
{
    [Key]
    public int IdUser { get; set; }

    public string? Email { get; set; }

    public bool? EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }

    public bool? IsActive { get; set; }

    public int EmployeeNo { get; set; }

    public string? UserName { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public int? IdCompany { get; set; }

    public int? IdDepartment { get; set; }

    public int? IdPosition { get; set; }

    public int? IdPicture { get; set; }
}
