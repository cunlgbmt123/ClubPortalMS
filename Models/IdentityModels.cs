using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using ClubPortalMS.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ClubPortalMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Album> Album { get; set; }
        public DbSet<CLB> CLB { get; set; }
        public DbSet<ChoXetDuyet> ChoXetDuyet { get; set; }
        public DbSet<DangKy> DangKy { get; set; }
        public DbSet<GioiThieu> GioiThieu { get; set; }
        public DbSet<HoatDong> HoatDong { get; set; }
        public DbSet<LienHe> LienHe { get; set; }
        public DbSet<LoaiCLB> LoaiCLB { get; set; }
        public DbSet<LoaiHD> LoaiHD { get; set; }
        public DbSet<LoaiSuKien> LoaiSuKien { get; set; }
        public DbSet<NhiemVu> NhiemVu { get; set; }
        public DbSet<Poster> Poster { get; set; }
        public DbSet<PhanHoi> PhanHoi { get; set; }
        public DbSet<QLDSHoatDong> QLDSHoatDong { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<SuKien> SuKien { get; set; }
        public DbSet<TTNhatKy> TTNhatKy { get; set; }
        public DbSet<ThanhVien> ThanhVien { get; set; }
        public DbSet<ThongBao> ThongBao { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<UserRoles> UserRole { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}