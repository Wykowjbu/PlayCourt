using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Bảng danh mục các môn thể thao trong hệ thống
/// </summary>
public partial class Sport
{
    /// <summary>
    /// Khóa chính của bảng Sports, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Mã môn thể thao dùng trong hệ thống (ví dụ: TENNIS, BADMINTON, PICKLEBALL)
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Tên môn thể thao hiển thị cho người dùng
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Mô tả chi tiết về môn thể thao
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Số lượng người chơi tiêu chuẩn cho môn thể thao
    /// </summary>
    public short? PlayerCount { get; set; }

    /// <summary>
    /// Trạng thái kích hoạt môn thể thao (true = đang được sử dụng, false = ngừng sử dụng)
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Thời điểm tạo bản ghi môn thể thao
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Court> Courts { get; set; } = new List<Court>();

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual ICollection<PlayerSport> PlayerSports { get; set; } = new List<PlayerSport>();
}
