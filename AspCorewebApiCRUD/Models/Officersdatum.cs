using System;
using System.Collections.Generic;

namespace AspCorewebApiCRUD.Models;

public partial class Officersdatum
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int Salary { get; set; }

    public string State { get; set; } = null!;

    public string AnyFir { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
