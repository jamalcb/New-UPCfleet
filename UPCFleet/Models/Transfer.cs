using System;
using System.Collections.Generic;

namespace UPCFleet.Models;

public partial class Transfer
{
    public double? Transfer1 { get; set; }

    public double? Transaction { get; set; }

    public DateTime? From { get; set; }

    public DateTime? To { get; set; }

    public string? Status { get; set; }

    public string? FromIns { get; set; }

    public double? DaysIn { get; set; }

    public string? InsuranceDays { get; set; }

    public int Id { get; set; }
}
