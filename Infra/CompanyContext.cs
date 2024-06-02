using Core;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class CompanyContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<TrainingCompany>().HasData(
                 new TrainingCompany()
                 {
                     TrainingCompanyID = 1,
                     CompanyName = "RI-TECH",
                     Address = "Akurdi Pune",
                     EmailID = "contact@ritechpune.com",
                     MobileNo = "978686787686",
                     Password = "abcd",
                     WebsiteUrl = "https://www.ritechpune.com"
                 }
                ); ;
            
        }
        public CompanyContext(DbContextOptions<CompanyContext> opt):base(opt)
        { }
        public DbSet<User>  Users { get; set; }
        public DbSet<TrainingCompany> TrainingCompanies { get; set; }
        public DbSet<SubjectStream> Streams { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDet> OrderDets { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<OrderComplaint> OrderComplaints { get; set; }
        public DbSet<OrderComplaintSolution> OrderComplaintSolution { get; set; }
    }
}