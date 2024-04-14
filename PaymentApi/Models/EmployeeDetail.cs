using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Models;

public class EmployeeDetail
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// CardOwnerName
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// CardNumber
    /// </summary>
    public string Role { get; set; }

    /// <summary>
    /// CardCvv
    /// </summary>
    public string Experience { get; set; }

    /// <summary>
    /// CardExpiryDate
    /// </summary>
    public decimal Salary { get; set; }
}