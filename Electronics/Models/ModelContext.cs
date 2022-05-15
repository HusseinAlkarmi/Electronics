using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Electronics.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aboute> Aboutes { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Address2> Address2s { get; set; }
        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<Audits2> Audits2s { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankJordan> BankJordans { get; set; }
        public virtual DbSet<Banksystem> Banksystems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Categorye> Categoryes { get; set; }
        public virtual DbSet<Contacte> Contactes { get; set; }
        public virtual DbSet<Contactinfo> Contactinfos { get; set; }
        public virtual DbSet<Contactinfo2> Contactinfo2s { get; set; }
        public virtual DbSet<Cust> Custs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customersbank> Customersbanks { get; set; }
        public virtual DbSet<Depart> Departs { get; set; }
        public virtual DbSet<Depart2> Depart2s { get; set; }
        public virtual DbSet<DepartEmploy> DepartEmploys { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Department1> Departments1 { get; set; }
        public virtual DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }
        public virtual DbSet<DepartmentTask2> DepartmentTask2s { get; set; }
        public virtual DbSet<Employ> Employs { get; set; }
        public virtual DbSet<Employ2> Employ2s { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee2> Employee2s { get; set; }
        public virtual DbSet<EmployeeTask2> EmployeeTask2s { get; set; }
        public virtual DbSet<EmployeesBank> EmployeesBanks { get; set; }
        public virtual DbSet<Employeessystem> Employeessystems { get; set; }
        public virtual DbSet<Homepagee> Homepagees { get; set; }
        public virtual DbSet<Loginandrege> Loginandreges { get; set; }
        public virtual DbSet<Ordere> Orderes { get; set; }
        public virtual DbSet<Paymente> Paymentes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productcustomer> Productcustomers { get; set; }
        public virtual DbSet<Producte> Productes { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Reviewe> Reviewes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleBank> RoleBanks { get; set; }
        public virtual DbSet<Rolee> Rolees { get; set; }
        public virtual DbSet<Testimoniale> Testimoniales { get; set; }
        public virtual DbSet<Usere> Useres { get; set; }
        public virtual DbSet<Userlogin> Userlogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH10_USER149;PASSWORD=12345;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH10_USER149")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Aboute>(entity =>
            {
                entity.HasKey(e => e.AboutId)
                    .HasName("SYS_C00116556");

                entity.ToTable("ABOUTE");

                entity.Property(e => e.AboutId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUT_ID");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Image1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Text1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT1");

                entity.Property(e => e.Text3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT3");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Aboutes)
                    .HasForeignKey(d => d.HomeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00116557");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.AddressId)
                    .HasPrecision(10)
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.Addressname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESSNAME");
            });

            modelBuilder.Entity<Address2>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("SYS_C00101009");

                entity.ToTable("ADDRESS2");

                entity.Property(e => e.AddressId)
                    .HasPrecision(10)
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.AddressName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS_NAME");
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.ToTable("AUDITS");

                entity.Property(e => e.AuditId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AUDIT_ID");

                entity.Property(e => e.ByUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BY_USER");

                entity.Property(e => e.TableName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TABLE_NAME");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRANSACTION_DATE");

                entity.Property(e => e.TransactionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_NAME");
            });

            modelBuilder.Entity<Audits2>(entity =>
            {
                entity.HasKey(e => e.AuditId)
                    .HasName("SYS_C00101021");

                entity.ToTable("AUDITS2");

                entity.Property(e => e.AuditId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AUDIT_ID");

                entity.Property(e => e.Byuser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BYUSER");

                entity.Property(e => e.Tablename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TABLENAME");

                entity.Property(e => e.Transactiondate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRANSACTIONDATE");

                entity.Property(e => e.Transactionname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTIONNAME");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.BankBranchNum);

                entity.ToTable("BANK");

                entity.Property(e => e.BankBranchNum)
                    .HasPrecision(6)
                    .ValueGeneratedNever()
                    .HasColumnName("BANK_BRANCH_NUM");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BANK_NAME");
            });

            modelBuilder.Entity<BankJordan>(entity =>
            {
                entity.HasKey(e => e.BankBranchId)
                    .HasName("SYS_C0088982");

                entity.ToTable("BANK_JORDAN");

                entity.Property(e => e.BankBranchId)
                    .HasPrecision(4)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BANK_BRANCH_ID");

                entity.Property(e => e.BankAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BANK_ADDRESS");

                entity.Property(e => e.BankName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BANK_NAME");
            });

            modelBuilder.Entity<Banksystem>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("SYS_C0091158");

                entity.ToTable("BANKSYSTEM");

                entity.Property(e => e.BranchId)
                    .HasPrecision(4)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BRANCH_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.BankName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BANK_NAME");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");
            });

            modelBuilder.Entity<Categorye>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("SYS_C00116459");

                entity.ToTable("CATEGORYE");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");
            });

            modelBuilder.Entity<Contacte>(entity =>
            {
                entity.HasKey(e => e.ContId)
                    .HasName("SYS_C00116559");

                entity.ToTable("CONTACTE");

                entity.Property(e => e.ContId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONT_ID");

                entity.Property(e => e.Age)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("AGE");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Phone)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PHONE");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Contactes)
                    .HasForeignKey(d => d.HomeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00116560");
            });

            modelBuilder.Entity<Contactinfo>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("SYS_C00100926");

                entity.ToTable("CONTACTINFO");

                entity.Property(e => e.ContactId)
                    .HasPrecision(10)
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.AddressId)
                    .HasPrecision(10)
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.Phonenumber)
                    .HasPrecision(10)
                    .HasColumnName("PHONENUMBER");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Contactinfos)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_ADDRESS_CON");
            });

            modelBuilder.Entity<Contactinfo2>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("SYS_C00101014");

                entity.ToTable("CONTACTINFO2");

                entity.Property(e => e.ContactId)
                    .HasPrecision(10)
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.AddressId)
                    .HasPrecision(10)
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.PhoneNumber)
                    .HasPrecision(10)
                    .HasColumnName("PHONE_NUMBER");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Contactinfo2s)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_ADDRESSINFO");
            });

            modelBuilder.Entity<Cust>(entity =>
            {
                entity.ToTable("CUST");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER(20,4)")
                    .HasColumnName("BALANCE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.BankAcountNum)
                    .HasPrecision(6)
                    .HasColumnName("BANK_ACOUNT_NUM");

                entity.Property(e => e.BankBranchNum)
                    .HasPrecision(6)
                    .HasColumnName("BANK_BRANCH_NUM");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.PhoneNum)
                    .HasPrecision(10)
                    .HasColumnName("PHONE_NUM");

                entity.HasOne(d => d.BankBranchNumNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BankBranchNum)
                    .HasConstraintName("FK_CUSTOMER");
            });

            modelBuilder.Entity<Customersbank>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("SYS_C0091160");

                entity.ToTable("CUSTOMERSBANK");

                entity.Property(e => e.CustomerId)
                    .HasPrecision(6)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.AccountId)
                    .HasPrecision(6)
                    .HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.Balance)
                    .HasPrecision(8)
                    .HasColumnName("BALANCE");

                entity.Property(e => e.BranchId)
                    .HasPrecision(4)
                    .HasColumnName("BRANCH_ID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Customersbanks)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_CU");
            });

            modelBuilder.Entity<Depart>(entity =>
            {
                entity.ToTable("DEPART");

                entity.Property(e => e.DepartId)
                    .HasPrecision(10)
                    .HasColumnName("DEPART_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.DepartName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPART_NAME");
            });

            modelBuilder.Entity<Depart2>(entity =>
            {
                entity.HasKey(e => e.DepartId)
                    .HasName("SYS_C00101011");

                entity.ToTable("DEPART2");

                entity.Property(e => e.DepartId)
                    .HasPrecision(10)
                    .HasColumnName("DEPART_ID");

                entity.Property(e => e.AddressId)
                    .HasPrecision(10)
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.DepartName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPART_NAME");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Depart2s)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_ADDRESS2");
            });

            modelBuilder.Entity<DepartEmploy>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DEPART_EMPLOY");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(10,4)")
                    .HasColumnName("SALARY");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT__");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(10)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.AddressId)
                    .HasPrecision(10)
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.Departmentname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENTNAME");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_ADDRESS");
            });

            modelBuilder.Entity<Department1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<DepartmentEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DEPARTMENT_EMPLOYEE");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(10,4)")
                    .HasColumnName("SALARY");
            });

            modelBuilder.Entity<DepartmentTask2>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("SYS_C0098901");

                entity.ToTable("DEPARTMENT_TASK2");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(10)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT_NAME");
            });

            modelBuilder.Entity<Employ>(entity =>
            {
                entity.ToTable("EMPLOY");

                entity.Property(e => e.Employid)
                    .HasPrecision(10)
                    .HasColumnName("EMPLOYID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.DepartId)
                    .HasPrecision(10)
                    .HasColumnName("DEPART_ID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.PhoneNumber)
                    .HasPrecision(10)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(10,4)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.Employs)
                    .HasForeignKey(d => d.DepartId)
                    .HasConstraintName("FK_EMPLOY");
            });

            modelBuilder.Entity<Employ2>(entity =>
            {
                entity.HasKey(e => e.EmployId)
                    .HasName("SYS_C00101017");

                entity.ToTable("EMPLOY2");

                entity.Property(e => e.EmployId)
                    .HasPrecision(10)
                    .HasColumnName("EMPLOY_ID");

                entity.Property(e => e.ContactId)
                    .HasPrecision(10)
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.DepartId)
                    .HasPrecision(10)
                    .HasColumnName("DEPART_ID");

                entity.Property(e => e.EmployName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOY_NAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Employ2s)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_CONTACT2");

                entity.HasOne(d => d.Depart)
                    .WithMany(p => p.Employ2s)
                    .HasForeignKey(d => d.DepartId)
                    .HasConstraintName("FK_EMPLOY2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(10)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.EmploymentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EMPLOYMENT_DATE");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.PosId)
                    .HasPrecision(6)
                    .HasColumnName("POS_ID");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(10,4)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PosId)
                    .HasConstraintName("FK_EMPLOYEE");
            });

            modelBuilder.Entity<Employee2>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("SYS_C00100929");

                entity.ToTable("EMPLOYEE2");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(10)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.ContactId)
                    .HasPrecision(10)
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(10)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Employeename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEENAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Employee2s)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_CONTACT_");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee2s)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_EMP_");
            });

            modelBuilder.Entity<EmployeeTask2>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("SYS_C0098916");

                entity.ToTable("EMPLOYEE_TASK2");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(10)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.DepartmentId)
                    .HasPrecision(10)
                    .HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasPrecision(10)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(10,4)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeTask2s)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_EMP");
            });

            modelBuilder.Entity<EmployeesBank>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("SYS_C0088986");

                entity.ToTable("EMPLOYEES_BANK");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(5)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.BankBranchId)
                    .HasPrecision(4)
                    .HasColumnName("BANK_BRANCH_ID");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NAME");

                entity.Property(e => e.EmploymentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EMPLOYMENT_DATE");

                entity.Property(e => e.Salary)
                    .HasPrecision(4)
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.BankBranch)
                    .WithMany(p => p.EmployeesBanks)
                    .HasForeignKey(d => d.BankBranchId)
                    .HasConstraintName("BANK_BRANCH");
            });

            modelBuilder.Entity<Employeessystem>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("SYS_C0091163");

                entity.ToTable("EMPLOYEESSYSTEM");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(5)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.BranchId)
                    .HasPrecision(4)
                    .HasColumnName("BRANCH_ID");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NAME");

                entity.Property(e => e.EmploymentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EMPLOYMENT_DATE");

                entity.Property(e => e.Salary)
                    .HasPrecision(4)
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Employeessystems)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FKEMPLOYEES");
            });

            modelBuilder.Entity<Homepagee>(entity =>
            {
                entity.HasKey(e => e.HomeId)
                    .HasName("SYS_C00116522");

                entity.ToTable("HOMEPAGEE");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Image1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Image3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE3");

                entity.Property(e => e.Image4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE4");

                entity.Property(e => e.Image5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE5");

                entity.Property(e => e.Image6)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE6");

                entity.Property(e => e.Image7)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE7");

                entity.Property(e => e.Text1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT1");

                entity.Property(e => e.Text2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT2");

                entity.Property(e => e.Text3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT3");

                entity.Property(e => e.Text4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT4");

                entity.Property(e => e.Text5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT5");

                entity.Property(e => e.Text6)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT6");

                entity.Property(e => e.Text7)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TEXT7");
            });

            modelBuilder.Entity<Loginandrege>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("SYS_C00116444");

                entity.ToTable("LOGINANDREGE");

                entity.Property(e => e.LogId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOG_ID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Loginandreges)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("USERE_FK");
            });

            modelBuilder.Entity<Ordere>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("SYS_C00125662");

                entity.ToTable("ORDERE");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.OrdersDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDERS_DATE");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.Sale)
                    .HasColumnType("FLOAT")
                    .HasColumnName("SALE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PROD");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orderes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USER2_FK");
            });

            modelBuilder.Entity<Paymente>(entity =>
            {
                entity.HasKey(e => e.PayemntId)
                    .HasName("SYS_C00116469");

                entity.ToTable("PAYMENTE");

                entity.Property(e => e.PayemntId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYEMNT_ID");

                entity.Property(e => e.Cardexp)
                    .HasColumnType("DATE")
                    .HasColumnName("CARDEXP");

                entity.Property(e => e.Cardname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARDNAME");

                entity.Property(e => e.Cardnum)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CARDNUM");

                entity.Property(e => e.Toalamount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOALAMOUNT");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Paymentes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CUSTO_FK");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PosId);

                entity.ToTable("POSITION");

                entity.Property(e => e.PosId)
                    .HasPrecision(6)
                    .HasColumnName("POS_ID");

                entity.Property(e => e.BankBranchNum)
                    .HasPrecision(6)
                    .HasColumnName("BANK_BRANCH_NUM");

                entity.Property(e => e.PosName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POS_NAME");

                entity.HasOne(d => d.BankBranchNumNavigation)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.BankBranchNum)
                    .HasConstraintName("FK_POSITION");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Sale)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SALE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK_CATE");
            });

            modelBuilder.Entity<Productcustomer>(entity =>
            {
                entity.ToTable("PRODUCTCUSTOMER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.Dateto)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETO");

                entity.Property(e => e.Productid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCTID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Productcustomers)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK_CUST_PROD");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productcustomers)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("FK_PRODU");
            });

            modelBuilder.Entity<Producte>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("SYS_C00116463");

                entity.ToTable("PRODUCTE");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Cost)
                    .HasColumnType("FLOAT")
                    .HasColumnName("COST");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.Quntity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("QUNTITY");

                entity.Property(e => e.Sale)
                    .HasColumnType("FLOAT")
                    .HasColumnName("SALE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Productes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CATE2");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("REPORT");

                entity.Property(e => e.ReportId)
                    .HasPrecision(10)
                    .HasColumnName("REPORT_ID");

                entity.Property(e => e.BankBranchNum)
                    .HasPrecision(6)
                    .HasColumnName("BANK_BRANCH_NUM");

                entity.Property(e => e.EmployeeReportId)
                    .HasPrecision(10)
                    .HasColumnName("EMPLOYEE_REPORT_ID");

                entity.Property(e => e.EmployeeReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_REPORT_NAME");

                entity.Property(e => e.ReportDate)
                    .HasColumnType("DATE")
                    .HasColumnName("REPORT_DATE");

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORT_NAME");

                entity.HasOne(d => d.BankBranchNumNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.BankBranchNum)
                    .HasConstraintName("FK_REPORT");
            });

            modelBuilder.Entity<Reviewe>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("SYS_C00116479");

                entity.ToTable("REVIEWE");

                entity.Property(e => e.ReviewId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REVIEW_ID");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Rating)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RATING");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviewes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C00116480");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ROLE");

                entity.Property(e => e.Column1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN1");
            });

            modelBuilder.Entity<RoleBank>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("SYS_C0091166");

                entity.ToTable("ROLE_BANK");

                entity.Property(e => e.RoleId)
                    .HasPrecision(4)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.EmployeeId)
                    .HasPrecision(5)
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RoleBanks)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("ROLE_FK");
            });

            modelBuilder.Entity<Rolee>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("SYS_C00116440");

                entity.ToTable("ROLEE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Testimoniale>(entity =>
            {
                entity.HasKey(e => e.TestimonialId)
                    .HasName("SYS_C00116488");

                entity.ToTable("TESTIMONIALE");

                entity.Property(e => e.TestimonialId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ID");

                entity.Property(e => e.TestimonialText)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIAL_TEXT");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimoniales)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("TEST_CUS_FK");
            });

            modelBuilder.Entity<Usere>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("SYS_C00116453");

                entity.ToTable("USERE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                //entity.Property(e => e.LogId)
                //    .HasColumnType("NUMBER(38)")
                //    .HasColumnName("LOG_ID");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                //entity.HasOne(d => d.Log)
                //    .WithMany(p => p.Useres)
                //    .HasForeignKey(d => d.LogId)
                //    .HasConstraintName("LOGE_FK");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Useres)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("USERE2_FK");
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.ToTable("USERLOGIN");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Customerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMERID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Userlogins)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK_CUST");
            });

            modelBuilder.HasSequence("ADDRESS_ID");

            modelBuilder.HasSequence("DEPART_ID");

            modelBuilder.HasSequence("DEPARTMENT_ID");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
