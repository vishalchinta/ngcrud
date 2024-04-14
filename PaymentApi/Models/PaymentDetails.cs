using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Models;

public class PaymentDetail
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// CardOwnerName
    /// </summary>
    public string CardOwnerName { get; set; }

    /// <summary>
    /// CardNumber
    /// </summary>
    public string CardNumber { get; set; }

    /// <summary>
    /// CardCvv
    /// </summary>
    public string CardCvv { get; set; }

    /// <summary>
    /// CardExpiryDate
    /// </summary>
    public string CardExpiryDate { get; set; }
}