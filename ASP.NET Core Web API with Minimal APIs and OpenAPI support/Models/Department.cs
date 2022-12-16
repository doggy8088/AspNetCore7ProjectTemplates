﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ASP.NET_Core_Web_API_with_Minimal_APIs_and_OpenAPI_support.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; }

    public decimal Budget { get; set; }

    public DateTime StartDate { get; set; }

    public int? InstructorId { get; set; }

    public byte[] RowVersion { get; set; }

    public virtual ICollection<Course> Course { get; } = new List<Course>();

    public virtual Person Instructor { get; set; }
}