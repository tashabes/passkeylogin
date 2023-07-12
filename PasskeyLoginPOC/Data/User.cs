using System;
using System.Collections.Generic;

namespace PasskeyLoginPOC.API.Data;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string MachineName { get; set; } = null!;
}
