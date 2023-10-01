using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using onlineshop.Models;
using System;

namespace onlineshop.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Basket> BasketCtx { get; set; }

        public DbSet<Category> CategoriesCtx { get; set; }

        public DbSet<Comment> CommentsCtx { get; set; }

        public DbSet<DeliveryMethod> DeliveryMethodsCtx { get; set; }

        public DbSet<EvaluationQueue> EvaluationQueueCtx { get; set; }

        public DbSet<Event> EventsCtx { get; set; }

        public DbSet<Order> OrdersCtx { get; set; }

        public DbSet<OrderProduct> OrderProductCtx { get; set; }

        public DbSet<PaymentMethod> PaymentMethodsCtx { get; set; }

        public DbSet<Product> ProductsCtx { get; set; }

        public DbSet<SupplerFirm> SupplerFirmsCtx { get; set; }

        public DbSet<UserSupplerFirm> UserSupplerFirmCtx { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //add roles (cant be edit/removed)

            //builder.Entity<Role>().HasData(
            //    new Role("admin", "online shop admin", true),
            //    new Role("owner", "online shop owner", true),
            //    new Role("seller", "online shop seller", true),
            //    new Role("buyer", "online shop buyer", true)
            //);

            //add user (root) with owner role (full access) (cant be edit/removed)

            //associate with enums

            builder.Entity<Order>().Property(o => o.OrderStatus).HasConversion(s => s.ToString(), s => (OrderStatus)Enum.Parse(typeof(OrderStatus), s));
            builder.Entity<PaymentMethod>().Property(p => p.PaymentType).HasConversion(s => s.ToString(), s => (PaymentType)Enum.Parse(typeof(PaymentType), s));

            //declre foreign keys

            builder.Entity<PaymentMethod>().HasOne(p => p.User).WithMany(u => u.PaymentMethods).HasForeignKey(p => p.UserId).IsRequired();

            builder.Entity<Order>().HasOne(o => o.DeliveryMethod).WithMany(d => d.Orders).HasForeignKey(o => o.DeliveryMethodId).IsRequired();
            builder.Entity<Order>().HasOne(o => o.PaymentMethod).WithMany(p => p.Orders).HasForeignKey(o => o.PaymentMethodId).IsRequired();
            builder.Entity<Order>().HasOne(o => o.Buyer).WithMany(u => u.Orders).HasForeignKey(o => o.BuyerId).IsRequired();

            builder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<OrderProduct>().HasOne<Order>(op => op.Order).WithMany(o => o.OrderProducts).HasForeignKey(o => o.OrderId);
            builder.Entity<OrderProduct>().HasOne<Product>(op => op.Product).WithMany(p => p.OrderProducts).HasForeignKey(o => o.ProductId);

            builder.Entity<UserSupplerFirm>().HasKey(uf => new { uf.SellerId, uf.SupplerFirmId});

            builder.Entity<UserSupplerFirm>().HasOne<User>(uf => uf.Seller).WithMany(u => u.UserSupplerFirms).HasForeignKey(uf => uf.SellerId);
            builder.Entity<UserSupplerFirm>().HasOne<SupplerFirm>(uf => uf.SupplerFirm).WithMany(sf => sf.UserSupplerFirms).HasForeignKey(uf => uf.SupplerFirmId);

            builder.Entity<Event>().HasOne(e => e.Product).WithMany(p => p.Events).HasForeignKey(e => e.ProductId).IsRequired();

            builder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).IsRequired();
            builder.Entity<Product>().HasOne(p => p.SupplerFirm).WithMany(s => s.Products).HasForeignKey(p => p.SupplerFirmId).IsRequired();

            builder.Entity<Comment>().HasOne(c => c.Product).WithMany(p => p.Comments).HasForeignKey(c => c.ProductId);//.IsRequired();

            builder.Entity<Basket>().HasOne(b => b.Product).WithMany(p => p.Baskets).HasForeignKey(b => b.ProductId).IsRequired();
            builder.Entity<Basket>().HasOne(b => b.Buyer).WithMany(b => b.Baskets).HasForeignKey(b => b.BuyerId).IsRequired();

            builder.Entity<EvaluationQueue>().HasOne(e => e.Buyer).WithMany(u => u.EvaluationQueues).HasForeignKey(e => e.BuyerId).IsRequired();
            builder.Entity<EvaluationQueue>().HasOne(e => e.Product).WithMany(p => p.EvaluationQueues).HasForeignKey(e => e.ProductId).IsRequired();
            builder.Entity<EvaluationQueue>().HasOne(e => e.Order).WithMany(o => o.EvaluationQueues).HasForeignKey(e => e.OrderId).IsRequired();

            base.OnModelCreating(builder);
        }
    }
}