using System;
using System.Collections.Generic;

namespace UPCFleet.Models;

public partial class Transaction
{
    public double? Transaction1 { get; set; }

    public string? Barge { get; set; }

    public string? Status { get; set; }

    public double? Rate { get; set; }

    public int Id { get; set; }
}
