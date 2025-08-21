using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresupuestitoBack.Migrations
{
    /// <inheritdoc />
    public partial class fixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostValue = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "FixedCost",
                columns: table => new
                {
                    FixedCostId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    WorkingDays = table.Column<int>(type: "INT", nullable: false),
                    HoursWorked = table.Column<int>(type: "INT", nullable: false),
                    DateCharged = table.Column<DateOnly>(type: "DATE", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedCost", x => x.FixedCostId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    DNI = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    CUIT = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryMaterialId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CategoryId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryMaterialId);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "INT", nullable: false),
                    Salary = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Suppliers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    MaterialDescription = table.Column<string>(type: "NVARCHAR(400)", nullable: false),
                    MaterialColor = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    MaterialBrand = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    MaterialMeasure = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    MaterialUnitMeasure = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    SubCategoryMaterialId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materials_SubCategories_SubCategoryMaterialId",
                        column: x => x.SubCategoryMaterialId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryMaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientsHistorys",
                columns: table => new
                {
                    ClientHistoryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsHistorys", x => x.ClientHistoryId);
                    table.ForeignKey(
                        name: "FK_ClientsHistorys_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHistories",
                columns: table => new
                {
                    EmployeeHistoryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHistories", x => x.EmployeeHistoryId);
                    table.ForeignKey(
                        name: "FK_EmployeeHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsPaid = table.Column<bool>(type: "BIT", nullable: false),
                    SupplierId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierHistories",
                columns: table => new
                {
                    SupplierHistoryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierHistories", x => x.SupplierHistoryId);
                    table.ForeignKey(
                        name: "FK_SupplierHistories_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    BudgetId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    BudgetStatus = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "DATE", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "DATE", nullable: true),
                    DescriptionBudget = table.Column<string>(type: "NVARCHAR(400)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "INT", nullable: false),
                    ClientHistoryId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.BudgetId);
                    table.ForeignKey(
                        name: "FK_Budgets_ClientsHistorys_ClientHistoryId",
                        column: x => x.ClientHistoryId,
                        principalTable: "ClientsHistorys",
                        principalColumn: "ClientHistoryId");
                    table.ForeignKey(
                        name: "FK_Budgets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoicesItems",
                columns: table => new
                {
                    InvoiceItemId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesItems", x => x.InvoiceItemId);
                    table.ForeignKey(
                        name: "FK_InvoicesItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicesItems_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DescriptionPayment = table.Column<string>(type: "VARCHAR(400)", nullable: false),
                    InvoiceId = table.Column<int>(type: "INT", nullable: false),
                    BudgetId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    WorkId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkName = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    EstimatedHoursWorked = table.Column<int>(type: "INT", nullable: false),
                    DeadLine = table.Column<DateTime>(type: "DATE", nullable: false),
                    CostPrice = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    BudgetId = table.Column<int>(type: "INT", nullable: false),
                    WorkStatus = table.Column<string>(type: "NVARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.WorkId);
                    table.ForeignKey(
                        name: "FK_Works_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsBudget",
                columns: table => new
                {
                    PaymentBudgetId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "INT", nullable: false),
                    BudgetId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsBudget", x => x.PaymentBudgetId);
                    table.ForeignKey(
                        name: "FK_PaymentsBudget_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentsBudget_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsInvoice",
                columns: table => new
                {
                    PaymentInvoice = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "INT", nullable: false),
                    InvoiceId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsInvoice", x => x.PaymentInvoice);
                    table.ForeignKey(
                        name: "FK_PaymentsInvoice_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentsInvoice_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    BillDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PaymentId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_Salaries_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "INT", nullable: false),
                    WorkId = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentsSalary",
                columns: table => new
                {
                    PaymentSalaryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "INT", nullable: false),
                    SalaryId = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentsSalary", x => x.PaymentSalaryId);
                    table.ForeignKey(
                        name: "FK_PaymentsSalary_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentsSalary_Salaries_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "Salaries",
                        principalColumn: "SalaryId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_ClientHistoryId",
                table: "Budgets",
                column: "ClientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_ClientId",
                table: "Budgets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PersonId",
                table: "Clients",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsHistorys_ClientId",
                table: "ClientsHistorys",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHistories_EmployeeId",
                table: "EmployeeHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonId",
                table: "Employees",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SupplierId",
                table: "Invoices",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesItems_InvoiceId",
                table: "InvoicesItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesItems_MaterialId",
                table: "InvoicesItems",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MaterialId",
                table: "Items",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_WorkId",
                table: "Items",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_SubCategoryMaterialId",
                table: "Materials",
                column: "SubCategoryMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BudgetId",
                table: "Payments",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsBudget_BudgetId",
                table: "PaymentsBudget",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsBudget_PaymentId",
                table: "PaymentsBudget",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsInvoice_InvoiceId",
                table: "PaymentsInvoice",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsInvoice_PaymentId",
                table: "PaymentsInvoice",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsSalary_PaymentId",
                table: "PaymentsSalary",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentsSalary_SalaryId",
                table: "PaymentsSalary",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_PaymentId",
                table: "Salaries",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierHistories_SupplierId",
                table: "SupplierHistories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_PersonId",
                table: "Suppliers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_BudgetId",
                table: "Works",
                column: "BudgetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "EmployeeHistories");

            migrationBuilder.DropTable(
                name: "FixedCost");

            migrationBuilder.DropTable(
                name: "InvoicesItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PaymentsBudget");

            migrationBuilder.DropTable(
                name: "PaymentsInvoice");

            migrationBuilder.DropTable(
                name: "PaymentsSalary");

            migrationBuilder.DropTable(
                name: "SupplierHistories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ClientsHistorys");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
