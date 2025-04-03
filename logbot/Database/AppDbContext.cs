using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Database
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento entre Employee e Company
            modelBuilder.Entity<EmployeeModel>()
                .HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento entre Product e Company
            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Company)
                .WithMany()
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre Order e Company
            modelBuilder.Entity<OrderModel>()
                .HasOne(o => o.Company)
                .WithMany()
                .HasForeignKey(o => o.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento entre OrderItem e Order
            modelBuilder.Entity<OrderItemModel>()
                .HasOne(oi => oi.Order)
                .WithMany()
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre OrderItem e Product
            modelBuilder.Entity<OrderItemModel>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre Payment e Order
            modelBuilder.Entity<PaymentModel>()
                .HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre Message e Company
            modelBuilder.Entity<MessageModel>()
                .HasOne(m => m.Company)
                .WithMany()
                .HasForeignKey(m => m.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre Conversation e Company
            modelBuilder.Entity<ConversationModel>()
                .HasOne(c => c.Company)
                .WithMany()
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre ConversationStep e Conversation
            modelBuilder.Entity<ConversationStepModel>()
                .HasOne(cs => cs.Conversation)
                .WithMany()
                .HasForeignKey(cs => cs.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre UserResponse e ConversationStep
            modelBuilder.Entity<UserResponseModel>()
                .HasOne(ur => ur.ConversationStep)
                .WithMany()
                .HasForeignKey(ur => ur.ConversationStepId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre ConversationLog e Company
            modelBuilder.Entity<ConversationLogModel>()
                .HasOne(cl => cl.Company)
                .WithMany()
                .HasForeignKey(cl => cl.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AutomatedReplyModel> AutomatedReplies { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<ConversationLogModel> ConversationLogs { get; set; }
        public DbSet<ConversationModel> Conversations { get; set; }
        public DbSet<ConversationStepModel> ConversationSteps { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserResponseModel> UserResponses { get; set; }


    }
}

