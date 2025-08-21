using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.Models;

namespace PresupuestitoBack.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Person> People { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientHistory> ClientHistories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Salary> Salaries { get; set;}
        public DbSet<FixedCost> FixedCosts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeHistory> EmployeeHistories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<SubCategoryMaterial> SubCategoryMaterials { get; set; }
        public DbSet<SupplierHistory> SupplierHistories { get; set; }
        public DbSet<PaymentBudget> PaymentsBudget { get; set; }
        public DbSet<PaymentSalary> PaymentsSalary { get; set;}
        public DbSet<PaymentInvoice> PaymentsInvoice { get; set; }
    }
}
