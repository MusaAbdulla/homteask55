using System;
using System.Collections.Generic;

namespace WebApplication1.model;

public partial class Front
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? Deadline { get; set; }
}
