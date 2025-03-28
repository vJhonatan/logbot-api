using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Database
{
    public class AppDbContext : DbContext
    {
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

