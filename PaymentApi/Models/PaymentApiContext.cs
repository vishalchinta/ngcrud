
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace PaymentApi.Models;

public class PaymentApiContext : DbContext
{
    public PaymentApiContext(DbContextOptions<PaymentApiContext> options)
        : base(options)
    {
    }

    public DbSet<PaymentDetail> PaymentDetails { get; set; }
    public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
}