using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public partial class PlayCourtDbContext : DbContext
{
    public PlayCourtDbContext()
    {
    }

    public PlayCourtDbContext(DbContextOptions<PlayCourtDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<CourtOwnerProfile> CourtOwnerProfiles { get; set; }

    public virtual DbSet<CourtSchedule> CourtSchedules { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<MatchJoinRequest> MatchJoinRequests { get; set; }

    public virtual DbSet<MatchParticipant> MatchParticipants { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PlayerSport> PlayerSports { get; set; }

    public virtual DbSet<PricingRule> PricingRules { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewImage> ReviewImages { get; set; }

    public virtual DbSet<ReviewReport> ReviewReports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    public virtual DbSet<VenueDocument> VenueDocuments { get; set; }

    public virtual DbSet<VenueImage> VenueImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.ToTable("Amenities", "venue", tb => tb.HasComment("Danh mục tiện ích sân"));

            entity.HasIndex(e => e.Name, "UQ_Amenities_Name").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Khoá chính tiện ích")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("Tên tiện ích (Parking, Wifi, Shower,...)");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Bookings", "booking", tb => tb.HasComment("Bảng lưu trữ thông tin đặt sân (Normalized)."));

            entity.HasIndex(e => e.BookingDate, "IX_Bookings_BookingDate");

            entity.HasIndex(e => e.Status, "IX_Bookings_Status");

            entity.HasIndex(e => e.UserId, "IX_Bookings_UserId");

            entity.HasIndex(e => e.VenueId, "IX_Bookings_VenueId");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CourtId).HasComment("Tham chiếu đến bảng Courts. Join để lấy tên sân.");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.OwnerEarnings).HasPrecision(12, 2);
            entity.Property(e => e.PlatformFee)
                .HasPrecision(12, 2)
                .HasDefaultValueSql("0");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("Trạng thái đơn hàng. Mapping Code: 0=Pending, 1=Confirmed, 2=Cancelled, 3=Completed, 4=Refunded");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(12, 2)
                .HasComment("Giá tiền chốt tại thời điểm đặt (Snapshot giá).");
            entity.Property(e => e.VenueId).HasComment("Tham chiếu đến bảng Venues. Join để lấy tên và địa chỉ.");

            entity.HasOne(d => d.Court).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CourtId)
                .HasConstraintName("FK_Bookings_Court");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Bookings_User");

            entity.HasOne(d => d.Venue).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK_Bookings_Venue");
        });

        modelBuilder.Entity<Court>(entity =>
        {
            entity.ToTable("Courts", "court", tb => tb.HasComment("Danh sách các sân con thuộc một venue"));

            entity.HasIndex(e => e.VenueId, "IX_Courts_VenueId");

            entity.Property(e => e.Id)
                .HasComment("Khoá chính của sân")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo sân");
            entity.Property(e => e.Indoor)
                .HasDefaultValue(false)
                .HasComment("Sân trong nhà hay ngoài trời");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("Tên sân (Court 1, Court A,...)");
            entity.Property(e => e.SportId).HasComment("ID môn thể thao (Pickleball | Tennis | Badminton)");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("Trạng thái sân: 0-Active | 1-Maintenance | 2-Inactive");
            entity.Property(e => e.VenueId).HasComment("ID venue mà sân thuộc về");

            entity.HasOne(d => d.Sport).WithMany(p => p.Courts)
                .HasForeignKey(d => d.SportId)
                .HasConstraintName("FK_Courts_Sports");

            entity.HasOne(d => d.Venue).WithMany(p => p.Courts)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK_Courts_Venues");
        });

        modelBuilder.Entity<CourtOwnerProfile>(entity =>
        {
            entity.ToTable("CourtOwnerProfiles", "user", tb => tb.HasComment("Bảng lưu thông tin hồ sơ dành riêng cho chủ sân thể thao"));

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng CourtOwnerProfiles, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.BusinessAddress).HasComment("Địa chỉ kinh doanh của sân thể thao");
            entity.Property(e => e.BusinessLicenseNo)
                .HasMaxLength(100)
                .HasComment("Số giấy phép kinh doanh của chủ sân");
            entity.Property(e => e.BusinessName)
                .HasMaxLength(255)
                .HasComment("Tên doanh nghiệp hoặc tên cơ sở kinh doanh của chủ sân");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo hồ sơ chủ sân");
            entity.Property(e => e.TaxCode)
                .HasMaxLength(50)
                .HasComment("Mã số thuế của doanh nghiệp hoặc chủ sân");
            entity.Property(e => e.UpdatedAt).HasComment("Thời điểm cập nhật gần nhất hồ sơ chủ sân");
            entity.Property(e => e.UserProfilesId).HasComment("Khóa ngoại tham chiếu đến bảng user.UserProfiles (hồ sơ người dùng)");
            entity.Property(e => e.VerificationStatus).HasComment("Trạng thái xác minh hồ sơ chủ sân: 0 = Chờ duyệt, 1 = Đã duyệt, 2 = Từ chối (0=Pending, 1=Approved, 2=Rejected)");

            entity.HasOne(d => d.UserProfiles).WithMany(p => p.CourtOwnerProfiles)
                .HasForeignKey(d => d.UserProfilesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourtOwnerProfiles_UserProfiles");
        });

        modelBuilder.Entity<CourtSchedule>(entity =>
        {
            entity.ToTable("CourtSchedules", "court", tb => tb.HasComment("Lịch khoá sân (bảo trì, nghỉ lễ, sự kiện,...)"));

            entity.HasIndex(e => new { e.CourtId, e.StartTime, e.EndTime }, "IX_CourtSchedules_CourtId_StartTime_EndTime");

            entity.Property(e => e.Id)
                .HasComment("Khoá chính lịch sân")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.CourtId).HasComment("ID sân bị khoá");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo lịch khoá");
            entity.Property(e => e.EndTime).HasComment("Thời điểm kết thúc khoá sân");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasComment("Lý do khoá sân");
            entity.Property(e => e.StartTime).HasComment("Thời điểm bắt đầu khoá sân");

            entity.HasOne(d => d.Court).WithMany(p => p.CourtSchedules)
                .HasForeignKey(d => d.CourtId)
                .HasConstraintName("FK_CourtSchedules_Courts");
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.ToTable("Matches", "match", tb => tb.HasComment("Bảng lưu thông tin các bài đăng tìm trận (match request) do người chơi tạo"));

            entity.HasIndex(e => e.CourtId, "IX_Matches_CourtId");

            entity.HasIndex(e => e.HostId, "IX_Matches_HostId");

            entity.HasIndex(e => new { e.ScheduledDate, e.Status }, "IX_Matches_ScheduledDate_Status");

            entity.HasIndex(e => e.SportId, "IX_Matches_SportId");

            entity.HasIndex(e => e.Status, "IX_Matches_Status");

            entity.HasIndex(e => e.VenueId, "IX_Matches_VenueId");

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng Matches, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.CostDescription).HasComment("Mô tả cách chia tiền (ví dụ: \"50/50\", \"Loser pays\", \"Free\")");
            entity.Property(e => e.CourtId).HasComment("Khóa ngoại tham chiếu đến bảng court.Courts (sân con cụ thể - có thể NULL nếu chỉ chọn venue)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo bài đăng tìm trận");
            entity.Property(e => e.CurrentParticipants)
                .HasDefaultValue((short)1)
                .HasComment("Số lượng người chơi hiện tại (bắt đầu = 1 do có host)");
            entity.Property(e => e.Description).HasComment("Mô tả chi tiết về trận đấu, ghi chú từ host");
            entity.Property(e => e.EndTime).HasComment("Giờ kết thúc trận đấu");
            entity.Property(e => e.HostId).HasComment("Khóa ngoại tham chiếu đến bảng user.UserProfiles (người tạo trận - host)");
            entity.Property(e => e.LocationDescription)
                .HasMaxLength(500)
                .HasComment("Mô tả địa điểm chơi (ví dụ: \"Quận Hải Châu\" khi không chọn sân cụ thể)");
            entity.Property(e => e.MaxParticipants).HasComment("Số lượng người chơi tối đa (bao gồm cả host)");
            entity.Property(e => e.RequiredSkillLevelMax).HasComment("Trình độ tối đa yêu cầu (0=Beginner, 1=Intermediate, 2=Advanced) - NULL = không giới hạn");
            entity.Property(e => e.RequiredSkillLevelMin).HasComment("Trình độ tối thiểu yêu cầu (0=Beginner, 1=Intermediate, 2=Advanced) - NULL = không yêu cầu");
            entity.Property(e => e.ScheduledDate).HasComment("Ngày dự kiến tổ chức trận đấu");
            entity.Property(e => e.SportId).HasComment("Khóa ngoại tham chiếu đến bảng sport.Sports (môn thể thao của trận đấu)");
            entity.Property(e => e.StartTime).HasComment("Giờ bắt đầu trận đấu");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("Trạng thái trận đấu: 0=Open (Đang tìm người), 1=Full (Đã đủ người), 2=InProgress (Đang diễn ra), 3=Completed (Đã kết thúc), 4=Cancelled (Đã hủy)");
            entity.Property(e => e.UpdatedAt).HasComment("Thời điểm cập nhật thông tin trận đấu gần nhất");
            entity.Property(e => e.VenueId).HasComment("Khóa ngoại tham chiếu đến bảng venue.Venues (sân lớn - có thể NULL nếu chỉ mô tả khu vực)");

            entity.HasOne(d => d.Court).WithMany(p => p.Matches)
                .HasForeignKey(d => d.CourtId)
                .HasConstraintName("FK_Matches_Courts");

            entity.HasOne(d => d.Host).WithMany(p => p.Matches)
                .HasForeignKey(d => d.HostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_UserProfiles");

            entity.HasOne(d => d.Sport).WithMany(p => p.Matches)
                .HasForeignKey(d => d.SportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matches_Sports");

            entity.HasOne(d => d.Venue).WithMany(p => p.Matches)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK_Matches_Venues");
        });

        modelBuilder.Entity<MatchJoinRequest>(entity =>
        {
            entity.ToTable("MatchJoinRequests", "match", tb => tb.HasComment("Bảng lưu các yêu cầu xin tham gia trận đấu từ người chơi, chờ host duyệt"));

            entity.HasIndex(e => new { e.MatchId, e.Status }, "IX_MatchJoinRequests_MatchId_Status");

            entity.HasIndex(e => e.PlayerId, "IX_MatchJoinRequests_PlayerId");

            entity.HasIndex(e => new { e.MatchId, e.PlayerId }, "UQ_MatchJoinRequests").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng MatchJoinRequests, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.MatchId).HasComment("Khóa ngoại tham chiếu đến bảng match.Matches (trận đấu muốn tham gia)");
            entity.Property(e => e.PlayerId).HasComment("Khóa ngoại tham chiếu đến bảng user.UserProfiles (người chơi gửi yêu cầu)");
            entity.Property(e => e.RequestedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm gửi yêu cầu tham gia");
            entity.Property(e => e.RespondedAt).HasComment("Thời điểm host phản hồi (accept/reject) yêu cầu");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("Trạng thái yêu cầu: 0=Pending (Chờ duyệt), 1=Accepted (Đã chấp nhận), 2=Rejected (Đã từ chối)");

            entity.HasOne(d => d.Match).WithMany(p => p.MatchJoinRequests)
                .HasForeignKey(d => d.MatchId)
                .HasConstraintName("FK_MatchJoinRequests_Matches");

            entity.HasOne(d => d.Player).WithMany(p => p.MatchJoinRequests)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchJoinRequests_UserProfiles");
        });

        modelBuilder.Entity<MatchParticipant>(entity =>
        {
            entity.ToTable("MatchParticipants", "match", tb => tb.HasComment("Bảng lưu danh sách người chơi đã được chấp nhận tham gia trận đấu"));

            entity.HasIndex(e => e.MatchId, "IX_MatchParticipants_MatchId");

            entity.HasIndex(e => e.PlayerId, "IX_MatchParticipants_PlayerId");

            entity.HasIndex(e => new { e.MatchId, e.PlayerId }, "UQ_MatchParticipants").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng MatchParticipants, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.IsHost)
                .HasDefaultValue(false)
                .HasComment("Đánh dấu người chơi này là host (người tạo trận) hay không");
            entity.Property(e => e.JoinedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm người chơi được chấp nhận tham gia trận đấu");
            entity.Property(e => e.MatchId).HasComment("Khóa ngoại tham chiếu đến bảng match.Matches (trận đấu)");
            entity.Property(e => e.PlayerId).HasComment("Khóa ngoại tham chiếu đến bảng user.UserProfiles (người chơi tham gia)");

            entity.HasOne(d => d.Match).WithMany(p => p.MatchParticipants)
                .HasForeignKey(d => d.MatchId)
                .HasConstraintName("FK_MatchParticipants_Matches");

            entity.HasOne(d => d.Player).WithMany(p => p.MatchParticipants)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchParticipants_UserProfiles");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payments", "payment", tb => tb.HasComment("Lưu trữ lịch sử dòng tiền ra/vào hệ thống."));

            entity.HasIndex(e => e.BookingId, "IX_Payments_BookingId");

            entity.HasIndex(e => e.CreatedAt, "IX_Payments_CreatedAt");

            entity.HasIndex(e => e.TransactionCode, "IX_Payments_TransactionCode");

            entity.HasIndex(e => e.UserId, "IX_Payments_UserId");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Amount).HasPrecision(12, 2);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .HasComment("Cổng thanh toán xử lý giao dịch (Momo, VNPay...).");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("Trạng thái giao dịch. Mapping: 0=Pending, 1=Success, 2=Failed.");
            entity.Property(e => e.TransactionCode)
                .HasMaxLength(100)
                .HasComment("Mã giao dịch trả về từ cổng thanh toán để đối soát.");
            entity.Property(e => e.Type).HasComment("Loại giao dịch. Mapping: 0=Payment (Khách trả tiền), 1=Refund (Hoàn tiền khách), 2=Payout (Trả tiền chủ sân).");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Payments_Booking");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Payments_User");
        });

        modelBuilder.Entity<PlayerSport>(entity =>
        {
            entity.ToTable("PlayerSports", "sport", tb => tb.HasComment("Bảng liên kết giữa người chơi và các môn thể thao mà họ tham gia"));

            entity.HasIndex(e => new { e.UserProfilesId, e.SportId }, "UQ_PlayerSports").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng PlayerSports, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm người chơi đăng ký tham gia môn thể thao");
            entity.Property(e => e.SkillLevel).HasComment("Trình độ của người chơi đối với môn thể thao: 0 = Người mới, 1 = Trung bình, 2 = Nâng cao");
            entity.Property(e => e.SportId).HasComment("Khóa ngoại tham chiếu đến bảng sport.Sports (môn thể thao)");
            entity.Property(e => e.UserProfilesId).HasComment("Khóa ngoại tham chiếu đến bảng user.UserProfiles (hồ sơ user)");

            entity.HasOne(d => d.Sport).WithMany(p => p.PlayerSports)
                .HasForeignKey(d => d.SportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerSports_Sports");

            entity.HasOne(d => d.UserProfiles).WithMany(p => p.PlayerSports)
                .HasForeignKey(d => d.UserProfilesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerSports_UserProfiles");
        });

        modelBuilder.Entity<PricingRule>(entity =>
        {
            entity.ToTable("PricingRules", "court", tb => tb.HasComment("Quy tắc giá thuê sân theo ngày và khung giờ"));

            entity.HasIndex(e => new { e.CourtId, e.DayOfWeek }, "IX_PricingRules_CourtId_DayOfWeek");

            entity.Property(e => e.Id)
                .HasComment("Khoá chính bảng giá")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.CourtId).HasComment("ID sân áp dụng bảng giá");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo quy tắc giá");
            entity.Property(e => e.DayOfWeek).HasComment("Thứ trong tuần: 1=Mon ... 7=Sun");
            entity.Property(e => e.EndTime).HasComment("Giờ kết thúc áp dụng giá");
            entity.Property(e => e.PricePerHour)
                .HasPrecision(10, 2)
                .HasComment("Giá thuê sân theo giờ");
            entity.Property(e => e.StartTime).HasComment("Giờ bắt đầu áp dụng giá");

            entity.HasOne(d => d.Court).WithMany(p => p.PricingRules)
                .HasForeignKey(d => d.CourtId)
                .HasConstraintName("FK_PricingRules_Courts");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Reviews", "review", tb => tb.HasComment("Bảng lưu đánh giá của người chơi về sân thể thao sau khi hoàn thành booking"));

            entity.HasIndex(e => e.BookingId, "IX_Reviews_BookingId");

            entity.HasIndex(e => e.CreatedAt, "IX_Reviews_CreatedAt").IsDescending();

            entity.HasIndex(e => e.PlayerId, "IX_Reviews_PlayerId");

            entity.HasIndex(e => e.Rating, "IX_Reviews_Rating");

            entity.HasIndex(e => new { e.VenueId, e.Status }, "IX_Reviews_VenueId_Status");

            entity.HasIndex(e => e.BookingId, "UQ_Reviews_BookingId").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng Reviews, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.BookingId).HasComment("Khóa ngoại tham chiếu đến bảng booking.Bookings (booking liên quan - NULL nếu đánh giá chung)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo đánh giá");
            entity.Property(e => e.PlayerId).HasComment("Khóa ngoại tham chiếu đến bảng user.UserProfiles (người đánh giá)");
            entity.Property(e => e.Rating)
                .HasPrecision(2, 1)
                .HasComment("Điểm đánh giá từ 1.0 đến 5.0 sao (cho phép 0.5 sao, ví dụ: 4.5)");
            entity.Property(e => e.ReviewText).HasComment("Nội dung đánh giá chi tiết của người chơi (tùy chọn)");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("Trạng thái đánh giá: 0=Active (Hiển thị công khai), 1=Hidden (Đã ẩn bởi admin), 2=Flagged (Bị báo cáo - đang chờ kiểm duyệt)");
            entity.Property(e => e.UpdatedAt).HasComment("Thời điểm cập nhật đánh giá gần nhất (khi người dùng edit)");
            entity.Property(e => e.VenueId).HasComment("Khóa ngoại tham chiếu đến bảng venue.Venues (sân được đánh giá)");

            entity.HasOne(d => d.Booking).WithOne(p => p.Review)
                .HasForeignKey<Review>(d => d.BookingId)
                .HasConstraintName("FK_Reviews_Bookings");

            entity.HasOne(d => d.Player).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_UserProfiles");

            entity.HasOne(d => d.Venue).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK_Reviews_Venues");
        });

        modelBuilder.Entity<ReviewImage>(entity =>
        {
            entity.ToTable("ReviewImages", "review", tb => tb.HasComment("Bảng lưu hình ảnh kèm theo đánh giá của người chơi (tối đa 5-10 ảnh/review)"));

            entity.HasIndex(e => e.ReviewId, "IX_ReviewImages_ReviewId");

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng ReviewImages, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm upload hình ảnh");
            entity.Property(e => e.DisplayOrder)
                .HasDefaultValue((short)0)
                .HasComment("Thứ tự hiển thị hình ảnh (0 = ảnh đầu tiên, 1 = ảnh thứ hai,...)");
            entity.Property(e => e.ImageUrl).HasComment("Đường dẫn URL đến hình ảnh được upload");
            entity.Property(e => e.ReviewId).HasComment("Khóa ngoại tham chiếu đến bảng review.Reviews (đánh giá chứa hình ảnh này)");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewImages)
                .HasForeignKey(d => d.ReviewId)
                .HasConstraintName("FK_ReviewImages_Reviews");
        });

        modelBuilder.Entity<ReviewReport>(entity =>
        {
            entity.ToTable("ReviewReports", "review", tb => tb.HasComment("Bảng lưu các báo cáo vi phạm về nội dung đánh giá (spam, offensive, fake review)"));

            entity.HasIndex(e => e.ReporterId, "IX_ReviewReports_ReporterId");

            entity.HasIndex(e => new { e.ReviewId, e.Status }, "IX_ReviewReports_ReviewId_Status");

            entity.HasIndex(e => e.Status, "IX_ReviewReports_Status");

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng ReviewReports, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.AdminNote).HasComment("Ghi chú của admin khi xử lý báo cáo");
            entity.Property(e => e.ReasonDescription).HasComment("Mô tả chi tiết lý do báo cáo từ người dùng");
            entity.Property(e => e.ReasonType).HasComment("Loại vi phạm: 0=Spam, 1=Offensive/Abusive, 2=Fake Review, 3=Inappropriate Content, 4=Other");
            entity.Property(e => e.ReportedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm gửi báo cáo");
            entity.Property(e => e.ReporterId).HasComment("Khóa ngoại tham chiếu đến bảng auth_app.User (người gửi báo cáo)");
            entity.Property(e => e.ResolvedAt).HasComment("Thời điểm admin xử lý báo cáo");
            entity.Property(e => e.ResolvedById).HasComment("Khóa ngoại tham chiếu đến bảng auth_app.User (admin xử lý báo cáo)");
            entity.Property(e => e.ReviewId).HasComment("Khóa ngoại tham chiếu đến bảng review.Reviews (đánh giá bị báo cáo)");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("Trạng thái xử lý: 0=Pending (Chờ xử lý), 1=Resolved (Đã xử lý - review bị ẩn/xóa), 2=Rejected (Báo cáo không hợp lệ)");

            entity.HasOne(d => d.Reporter).WithMany(p => p.ReviewReportReporters)
                .HasForeignKey(d => d.ReporterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewReports_Reporter");

            entity.HasOne(d => d.ResolvedBy).WithMany(p => p.ReviewReportResolvedBies)
                .HasForeignKey(d => d.ResolvedById)
                .HasConstraintName("FK_ReviewReports_ResolvedBy");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewReports)
                .HasForeignKey(d => d.ReviewId)
                .HasConstraintName("FK_ReviewReports_Reviews");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles", "auth_app", tb => tb.HasComment("Bảng danh mục vai trò người dùng trong hệ thống"));

            entity.HasIndex(e => e.Code, "UQ_Roles_Code").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng Roles")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasComment("Mã vai trò (ví dụ: PLAYER, COURT_OWNER, ADMIN)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo vai trò");
            entity.Property(e => e.Description).HasComment("Mô tả chi tiết quyền hạn của vai trò");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("Tên vai trò hiển thị");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.ToTable("Sports", "sport", tb => tb.HasComment("Bảng danh mục các môn thể thao trong hệ thống"));

            entity.HasIndex(e => e.Code, "UQ_Sports_Code").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng Sports, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasComment("Mã môn thể thao dùng trong hệ thống (ví dụ: TENNIS, BADMINTON, PICKLEBALL)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo bản ghi môn thể thao");
            entity.Property(e => e.Description).HasComment("Mô tả chi tiết về môn thể thao");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasComment("Trạng thái kích hoạt môn thể thao (true = đang được sử dụng, false = ngừng sử dụng)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasComment("Tên môn thể thao hiển thị cho người dùng");
            entity.Property(e => e.PlayerCount).HasComment("Số lượng người chơi tiêu chuẩn cho môn thể thao");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User", "auth_app", tb => tb.HasComment("Bảng lưu thông tin xác thực và phân quyền người dùng trong hệ thống"));

            entity.HasIndex(e => e.RoleId, "IX_User_RoleId");

            entity.HasIndex(e => e.Email, "UQ_User_Email").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng User, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo tài khoản người dùng");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasComment("Email dùng để đăng nhập hệ thống (duy nhất)");
            entity.Property(e => e.FailedLoginCount)
                .HasDefaultValue(0)
                .HasComment("Số lần đăng nhập thất bại liên tiếp");
            entity.Property(e => e.IsEmailVerified)
                .HasDefaultValue(false)
                .HasComment("Trạng thái xác minh email của người dùng");
            entity.Property(e => e.LastLoginAt).HasComment("Thời điểm đăng nhập gần nhất");
            entity.Property(e => e.LockedUntil).HasComment("Thời điểm hết hạn khóa tài khoản do đăng nhập sai");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasComment("Mật khẩu đã được mã hóa (hash)");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasComment("Số điện thoại của người dùng");
            entity.Property(e => e.RoleId).HasComment("Khóa ngoại tham chiếu đến bảng auth_app.Roles (vai trò người dùng)");
            entity.Property(e => e.Status).HasComment("Trạng thái tài khoản: 0 = Chưa xác minh, 1 = Hoạt động, 2 = Bị khóa");
            entity.Property(e => e.UpdatedAt).HasComment("Thời điểm cập nhật thông tin tài khoản gần nhất");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Roles");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.ToTable("UserProfiles", "user", tb => tb.HasComment("Bảng lưu thông tin hồ sơ cá nhân của người dùng (dùng chung cho tất cả các loại user)"));

            entity.Property(e => e.Id)
                .HasComment("Khóa chính của bảng UserProfiles, tự tăng")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Address).HasComment("Địa chỉ chi tiết của người dùng");
            entity.Property(e => e.AvatarUrl).HasComment("Đường dẫn (URL) ảnh đại diện của người dùng");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasComment("Thành phố nơi người dùng sinh sống");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasComment("Quốc gia nơi người dùng sinh sống");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo bản ghi hồ sơ người dùng");
            entity.Property(e => e.DateOfBirth).HasComment("Ngày sinh của người dùng");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasComment("Họ và tên đầy đủ của người dùng");
            entity.Property(e => e.Gender).HasComment("Giới tính của người dùng:  0 = Nam, 1 = Nữ");
            entity.Property(e => e.UpdatedAt).HasComment("Thời điểm cập nhật gần nhất thông tin hồ sơ người dùng");
            entity.Property(e => e.UserId).HasComment("Khóa ngoại tham chiếu đến bảng auth_app.User (định danh người dùng)");

            entity.HasOne(d => d.User).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserProfiles_User");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.ToTable("Venues", "venue", tb => tb.HasComment("Thông tin sân thể thao (pickleball, tennis, badminton,...)"));

            entity.HasIndex(e => e.OwnerId, "IX_Venues_OwnerId");

            entity.Property(e => e.Id)
                .HasComment("Khoá chính của sân")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasComment("Địa chỉ chi tiết của sân");
            entity.Property(e => e.CloseTime).HasComment("Giờ đóng cửa");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm tạo bản ghi sân");
            entity.Property(e => e.Description).HasComment("Mô tả chi tiết về sân");
            entity.Property(e => e.Latitude).HasComment("Vĩ độ (latitude) dùng để định vị bản đồ");
            entity.Property(e => e.Longitude).HasComment("Kinh độ (longitude) dùng để định vị bản đồ");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("Tên sân");
            entity.Property(e => e.OpenTime).HasComment("Giờ mở cửa");
            entity.Property(e => e.OwnerId).HasComment("ID chủ sân (tham chiếu auth_app.Users)");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasComment("Số điện thoại liên hệ sân");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("Trạng thái sân: 0-Pending | 1-Active | 2-Inactive | 3-Blocked");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm cập nhật thông tin sân");

            entity.HasOne(d => d.Owner).WithMany(p => p.Venues)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_Venues_Users");

            entity.HasMany(d => d.Amenities).WithMany(p => p.Venues)
                .UsingEntity<Dictionary<string, object>>(
                    "VenueAmenity",
                    r => r.HasOne<Amenity>().WithMany()
                        .HasForeignKey("AmenityId")
                        .HasConstraintName("FK_VenueAmenities_Amenities"),
                    l => l.HasOne<Venue>().WithMany()
                        .HasForeignKey("VenueId")
                        .HasConstraintName("FK_VenueAmenities_Venues"),
                    j =>
                    {
                        j.HasKey("VenueId", "AmenityId");
                        j.ToTable("VenueAmenities", "venue", tb => tb.HasComment("Bảng liên kết nhiều-nhiều giữa sân và tiện ích"));
                        j.HasIndex(new[] { "AmenityId" }, "IX_VenueAmenities_AmenityId");
                        j.IndexerProperty<int>("VenueId").HasComment("ID sân");
                        j.IndexerProperty<int>("AmenityId").HasComment("ID tiện ích");
                    });
        });

        modelBuilder.Entity<VenueDocument>(entity =>
        {
            entity.ToTable("VenueDocuments", "venue", tb => tb.HasComment("Giấy tờ pháp lý của sân"));

            entity.HasIndex(e => e.VenueId, "IX_VenueDocuments_VenueId");

            entity.Property(e => e.Id)
                .HasComment("Khoá chính giấy tờ")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.DocumentType)
                .HasMaxLength(50)
                .HasComment("Loại giấy tờ: BusinessLicense, Contract, IDCard,...");
            entity.Property(e => e.DocumentUrl).HasComment("Đường dẫn file giấy tờ");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)0)
                .HasComment("Trạng thái duyệt: 0-Pending | 1-Approved | 2-Rejected");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm chủ sân upload giấy tờ");
            entity.Property(e => e.VenueId).HasComment("ID sân sở hữu giấy tờ");
            entity.Property(e => e.VerifiedAt).HasComment("Thời điểm admin xác minh giấy tờ");

            entity.HasOne(d => d.Venue).WithMany(p => p.VenueDocuments)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK_VenueDocuments_Venues");
        });

        modelBuilder.Entity<VenueImage>(entity =>
        {
            entity.ToTable("VenueImages", "venue", tb => tb.HasComment("Danh sách hình ảnh của sân"));

            entity.HasIndex(e => e.VenueId, "IX_VenueImages_VenueId");

            entity.Property(e => e.Id)
                .HasComment("Khoá chính ảnh")
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasComment("Thời điểm upload ảnh");
            entity.Property(e => e.ImageUrl).HasComment("Đường dẫn ảnh (URL hoặc path)");
            entity.Property(e => e.IsCover)
                .HasDefaultValue(false)
                .HasComment("Ảnh đại diện của sân hay không");
            entity.Property(e => e.VenueId).HasComment("ID sân sở hữu hình ảnh");

            entity.HasOne(d => d.Venue).WithMany(p => p.VenueImages)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK_VenueImages_Venues");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
