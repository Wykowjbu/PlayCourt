using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Lưu trữ lịch sử dòng tiền ra/vào hệ thống.
/// </summary>
public partial class Payment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? BookingId { get; set; }

    public decimal Amount { get; set; }

    /// <summary>
    /// Cổng thanh toán xử lý giao dịch (Momo, VNPay...).
    /// </summary>
    public string Provider { get; set; } = null!;

    /// <summary>
    /// Mã giao dịch trả về từ cổng thanh toán để đối soát.
    /// </summary>
    public string? TransactionCode { get; set; }

    /// <summary>
    /// Loại giao dịch. Mapping: 0=Payment (Khách trả tiền), 1=Refund (Hoàn tiền khách), 2=Payout (Trả tiền chủ sân).
    /// </summary>
    public short Type { get; set; }

    /// <summary>
    /// Trạng thái giao dịch. Mapping: 0=Pending, 1=Success, 2=Failed.
    /// </summary>
    public short Status { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual User User { get; set; } = null!;
}
