﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class Machines
{
    public int MachineId { get; set; }

    public string MachineNo { get; set; }

    public virtual ICollection<Outputs> Outputs { get; set; } = new List<Outputs>();
}