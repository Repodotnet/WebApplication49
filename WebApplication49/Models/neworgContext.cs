using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication49.Models
{
    public partial class neworgContext : DbContext
    {
        public neworgContext()
        {
        }

        public neworgContext(DbContextOptions<neworgContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employeeaudit> Employeeaudits { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Profilerdemo> Profilerdemos { get; set; }
        public virtual DbSet<Sqlprofilerdemo> Sqlprofilerdemos { get; set; }
        public virtual DbSet<VwGetcompinfo> VwGetcompinfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
                //You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                // optionsBuilder.UseSqlServer("Server=LAPTOP-070R2R4B\\SQLEXPRESS;Database=neworg;Trusted_Connection=True;");
               // optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DbCon"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Companyid)
                    .ValueGeneratedNever()
                    .HasColumnName("companyid");

                entity.Property(e => e.Companyname)
                    .HasMaxLength(20)
                    .HasColumnName("companyname");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.Locationid)
                    .HasConstraintName("fk_locationid");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Deptid)
                    .HasName("PK__departme__BE2C1AEE2C358C89");

                entity.ToTable("department");

                entity.Property(e => e.Deptid)
                    .ValueGeneratedNever()
                    .HasColumnName("deptid");

                entity.Property(e => e.Deptname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deptname")
                    .HasDefaultValueSql("('IT')");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => new { e.Salary, e.Deptid }, "idx_employee_salary_deptid");

                entity.Property(e => e.Employeeid)
                    .ValueGeneratedNever()
                    .HasColumnName("employeeid");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Designation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("designation");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Employeename)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnType("date")
                    .HasColumnName("hiredate");

                entity.Property(e => e.Managerid).HasColumnName("managerid");

                entity.Property(e => e.Salary)
                    .HasColumnType("money")
                    .HasColumnName("salary");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Companyid)
                    .HasConstraintName("FK__employee__compan__3F466844");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Deptid)
                    .HasConstraintName("FK__employee__deptid__403A8C7D");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.Managerid)
                    .HasConstraintName("FK__employee__manage__3E52440B");
            });

            modelBuilder.Entity<Employeeaudit>(entity =>
            {
                entity.ToTable("employeeaudit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Auditdata).HasMaxLength(100);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Profilerdemo>(entity =>
            {
                entity.HasKey(e => e.RowNumber)
                    .HasName("PK__Profiler__AAAC09D8E64E05F2");

                entity.ToTable("Profilerdemo");

                entity.Property(e => e.ApplicationName).HasMaxLength(128);

                entity.Property(e => e.BinaryData).HasColumnType("image");

                entity.Property(e => e.ClientProcessId).HasColumnName("ClientProcessID");

                entity.Property(e => e.Cpu).HasColumnName("CPU");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LoginName).HasMaxLength(128);

                entity.Property(e => e.NtuserName)
                    .HasMaxLength(128)
                    .HasColumnName("NTUserName");

                entity.Property(e => e.Spid).HasColumnName("SPID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TextData).HasColumnType("ntext");
            });

            modelBuilder.Entity<Sqlprofilerdemo>(entity =>
            {
                entity.HasKey(e => e.RowNumber)
                    .HasName("PK__sqlprofi__AAAC09D83205C80A");

                entity.ToTable("sqlprofilerdemo");

                entity.Property(e => e.ApplicationName).HasMaxLength(128);

                entity.Property(e => e.BinaryData).HasColumnType("image");

                entity.Property(e => e.ClientProcessId).HasColumnName("ClientProcessID");

                entity.Property(e => e.Cpu).HasColumnName("CPU");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LoginName).HasMaxLength(128);

                entity.Property(e => e.NtuserName)
                    .HasMaxLength(128)
                    .HasColumnName("NTUserName");

                entity.Property(e => e.Spid).HasColumnName("SPID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TextData).HasColumnType("ntext");
            });

            modelBuilder.Entity<VwGetcompinfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_getcompinfo");

                entity.Property(e => e.Companyname)
                    .HasMaxLength(20)
                    .HasColumnName("companyname");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
