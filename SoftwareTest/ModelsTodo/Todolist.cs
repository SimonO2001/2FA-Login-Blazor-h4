using System;
using System.Collections.Generic;

namespace SoftwareTest.ModelsTodo;

public partial class Todolist
{
    public string UserId { get; set; } = null!;

    public string Item { get; set; } = null!;

    public virtual Cpr User { get; set; } = null!;
}
