using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoleBasedAuthorization.list;

public partial class Ikasecurity3pContext : DbContext
{
    public Ikasecurity3pContext()
    {
    }

    public Ikasecurity3pContext(DbContextOptions<Ikasecurity3pContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAppInfo> TblAppInfos { get; set; }

    public virtual DbSet<TblButtonLang> TblButtonLangs { get; set; }

    public virtual DbSet<TblControlDefaultLabel> TblControlDefaultLabels { get; set; }

    public virtual DbSet<TblControlLabel> TblControlLabels { get; set; }

    public virtual DbSet<TblControlProfile> TblControlProfiles { get; set; }

    public virtual DbSet<TblDefault> TblDefaults { get; set; }

    public virtual DbSet<TblFormControl> TblFormControls { get; set; }

    public virtual DbSet<TblFunction> TblFunctions { get; set; }

    public virtual DbSet<TblFunctionDatum> TblFunctionData { get; set; }

    public virtual DbSet<TblFunctionDetail> TblFunctionDetails { get; set; }

    public virtual DbSet<TblFunctionPermission> TblFunctionPermissions { get; set; }

    public virtual DbSet<TblFunctionType> TblFunctionTypes { get; set; }

    public virtual DbSet<TblInfo> TblInfos { get; set; }

    public virtual DbSet<TblInfo1> TblInfo1s { get; set; }

    public virtual DbSet<TblLanguage> TblLanguages { get; set; }

    public virtual DbSet<TblLayout> TblLayouts { get; set; }

    public virtual DbSet<TblLayoutDefault> TblLayoutDefaults { get; set; }

    public virtual DbSet<TblLayoutPermission> TblLayoutPermissions { get; set; }

    public virtual DbSet<TblLicenceRegisted> TblLicenceRegisteds { get; set; }

    public virtual DbSet<TblLoginLog> TblLoginLogs { get; set; }

    public virtual DbSet<TblMenu> TblMenus { get; set; }

    public virtual DbSet<TblMenuRole> TblMenuRoles { get; set; }

    public virtual DbSet<TblMessage> TblMessages { get; set; }

    public virtual DbSet<TblMessageLang> TblMessageLangs { get; set; }

    public virtual DbSet<TblPermissionDatabase> TblPermissionDatabases { get; set; }

    public virtual DbSet<TblPermissionType> TblPermissionTypes { get; set; }

    public virtual DbSet<TblProject> TblProjects { get; set; }

    public virtual DbSet<TblProjectInfo> TblProjectInfos { get; set; }

    public virtual DbSet<TblReportPermission> TblReportPermissions { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblRoleFunctionPermission> TblRoleFunctionPermissions { get; set; }

    public virtual DbSet<TblRoleLayoutPermission> TblRoleLayoutPermissions { get; set; }

    public virtual DbSet<TblRoleReportPermission> TblRoleReportPermissions { get; set; }

    public virtual DbSet<TblRoleSystemPermission> TblRoleSystemPermissions { get; set; }

    public virtual DbSet<TblSystemPermission> TblSystemPermissions { get; set; }

    public virtual DbSet<TblText> TblTexts { get; set; }

    public virtual DbSet<TblUpdateFile> TblUpdateFiles { get; set; }

    public virtual DbSet<TblUserAccount> TblUserAccounts { get; set; }

    public virtual DbSet<TblUserDefaultValue> TblUserDefaultValues { get; set; }

    public virtual DbSet<TblUserRole> TblUserRoles { get; set; }

    public virtual DbSet<TblUserSystemPermission> TblUserSystemPermissions { get; set; }

    public virtual DbSet<TblUserTool> TblUserTools { get; set; }

    public virtual DbSet<VwControlLabel> VwControlLabels { get; set; }

    public virtual DbSet<VwFormControlDefaultLabel> VwFormControlDefaultLabels { get; set; }

    public virtual DbSet<VwLayoutDefault> VwLayoutDefaults { get; set; }

    public virtual DbSet<VwLayoutPrj> VwLayoutPrjs { get; set; }

    public virtual DbSet<VwLayoutUser> VwLayoutUsers { get; set; }

    public virtual DbSet<VwMessageLang> VwMessageLangs { get; set; }

    public virtual DbSet<VwRole2role> VwRole2roles { get; set; }

    public virtual DbSet<VwUserLayout> VwUserLayouts { get; set; }

    public virtual DbSet<VwUserRole> VwUserRoles { get; set; }

    public virtual DbSet<VwUserRoleLayout> VwUserRoleLayouts { get; set; }

    public virtual DbSet<VwUserRoleSystem> VwUserRoleSystems { get; set; }

    public virtual DbSet<VwUserSystem> VwUserSystems { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAppInfo>(entity =>
        {
            entity.HasKey(e => e.CodeProject);

            entity.ToTable("tbl_AppInfo");

            entity.Property(e => e.CodeProject)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FileId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FileID");
            entity.Property(e => e.IsSetup).HasColumnName("isSetup");
            entity.Property(e => e.PublishDate).HasColumnType("datetime");
            entity.Property(e => e.ServerPath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblButtonLang>(entity =>
        {
            entity.HasKey(e => new { e.Button, e.Lang });

            entity.ToTable("tbl_ButtonLang");

            entity.Property(e => e.Button)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Lang)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Content).HasMaxLength(50);
        });

        modelBuilder.Entity<TblControlDefaultLabel>(entity =>
        {
            entity.HasKey(e => new { e.FunctionName, e.ControlName, e.Lang });

            entity.ToTable("tbl_ControlDefaultLabel");

            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ControlName)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Lang)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ControlType)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.PropCaption).HasMaxLength(200);
            entity.Property(e => e.PropHint).HasMaxLength(200);
            entity.Property(e => e.PropParent)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblControlLabel>(entity =>
        {
            entity.HasKey(e => new { e.FunctionName, e.Lang });

            entity.ToTable("tbl_ControlLabel");

            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lang)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ControlLabel).HasColumnType("image");
        });

        modelBuilder.Entity<TblControlProfile>(entity =>
        {
            entity.HasKey(e => new { e.ProfileName, e.UserName });

            entity.ToTable("tbl_ControlProfile");

            entity.Property(e => e.ProfileName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Content).HasColumnType("image");
            entity.Property(e => e.ControlName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ControlType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastDay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.FunctionNameNavigation).WithMany(p => p.TblControlProfiles)
                .HasForeignKey(d => d.FunctionName)
                .HasConstraintName("FK_tbl_ControlProfile_tbl_Function");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.TblControlProfiles)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_tbl_ControlProfile_tbl_UserAccount");
        });

        modelBuilder.Entity<TblDefault>(entity =>
        {
            entity.HasKey(e => e.CName);

            entity.ToTable("tbl_default");

            entity.Property(e => e.CName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cName");
            entity.Property(e => e.CValue)
                .HasColumnType("text")
                .HasColumnName("cValue");
        });

        modelBuilder.Entity<TblFormControl>(entity =>
        {
            entity.ToTable("tbl_FormControls");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ControlType)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.DefaultValue)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PropFontName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PropIsKnownBackColor).HasDefaultValue((short)1);
            entity.Property(e => e.PropIsKnownForeColor).HasDefaultValue((short)1);
            entity.Property(e => e.PropLabel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PropName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.PropParent)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.PropStyleController)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.LayoutNameNavigation).WithMany(p => p.TblFormControls)
                .HasForeignKey(d => d.LayoutName)
                .HasConstraintName("FK_tbl_FormControls_tbl_Layout");
        });

        modelBuilder.Entity<TblFunction>(entity =>
        {
            entity.HasKey(e => e.FunctionName).HasName("PK_SS_Function");

            entity.ToTable("tbl_Function");

            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CodeProject)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Enabled).HasDefaultValue(true);
            entity.Property(e => e.FormName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FunctionDesc)
                .HasMaxLength(100)
                .HasDefaultValue("-");
            entity.Property(e => e.FunctionType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Owner)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblFunctionDatum>(entity =>
        {
            entity.HasKey(e => new { e.FunctionName, e.ObjectName });

            entity.ToTable("tbl_function_data");

            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ObjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ObjectType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblFunctionDetail>(entity =>
        {
            entity.HasKey(e => e.PermissionType);

            entity.ToTable("tbl_FunctionDetail");

            entity.Property(e => e.PermissionType)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblFunctionPermission>(entity =>
        {
            entity.HasKey(e => new { e.UserName, e.FunctionName });

            entity.ToTable("tbl_FunctionPermission");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.PermissionType)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.FunctionNameNavigation).WithMany(p => p.TblFunctionPermissions)
                .HasForeignKey(d => d.FunctionName)
                .HasConstraintName("FK_tbl_FunctionPermission_tbl_Function");
        });

        modelBuilder.Entity<TblFunctionType>(entity =>
        {
            entity.HasKey(e => e.Type);

            entity.ToTable("tbl_FunctionType");

            entity.Property(e => e.Type)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblInfo>(entity =>
        {
            entity.HasKey(e => e.IName).HasName("PK_Info");

            entity.ToTable("tbl_Info");

            entity.Property(e => e.IName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("iName");
            entity.Property(e => e.IComment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("iComment");
            entity.Property(e => e.IValue)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("iValue");
        });

        modelBuilder.Entity<TblInfo1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Info1");

            entity.Property(e => e.IComment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("iComment");
            entity.Property(e => e.IName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("iName");
            entity.Property(e => e.IValue)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("iValue");
        });

        modelBuilder.Entity<TblLanguage>(entity =>
        {
            entity.HasKey(e => e.LangEng);

            entity.ToTable("tbl_Language");

            entity.Property(e => e.LangEng)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Lang_eng");
            entity.Property(e => e.Lang).HasMaxLength(30);
        });

        modelBuilder.Entity<TblLayout>(entity =>
        {
            entity.HasKey(e => e.LayoutName);

            entity.ToTable("tbl_Layout");

            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CodeLayout).HasColumnType("text");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FormImage).HasColumnType("image");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LayoutContent).HasColumnType("image");
            entity.Property(e => e.Owner)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("INNOSOFT");
            entity.Property(e => e.Version)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.FunctionNameNavigation).WithMany(p => p.TblLayouts)
                .HasForeignKey(d => d.FunctionName)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tbl_Layout_tbl_Function");
        });

        modelBuilder.Entity<TblLayoutDefault>(entity =>
        {
            entity.HasKey(e => new { e.UserName, e.FunctionName });

            entity.ToTable("tbl_LayoutDefault");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.LayoutNameNavigation).WithMany(p => p.TblLayoutDefaults)
                .HasForeignKey(d => d.LayoutName)
                .HasConstraintName("FK_tbl_LayoutDefault_tbl_Layout");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.TblLayoutDefaults)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_tbl_LayoutDefault_tbl_UserAccount");
        });

        modelBuilder.Entity<TblLayoutPermission>(entity =>
        {
            entity.HasKey(e => new { e.UserName, e.LayoutName });

            entity.ToTable("tbl_LayoutPermission");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsDefault).HasColumnName("isDefault");

            entity.HasOne(d => d.LayoutNameNavigation).WithMany(p => p.TblLayoutPermissions)
                .HasForeignKey(d => d.LayoutName)
                .HasConstraintName("FK_tbl_LayoutPermission_tbl_Layout");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.TblLayoutPermissions)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_tbl_LayoutPermission_tbl_UserAccount");
        });

        modelBuilder.Entity<TblLicenceRegisted>(entity =>
        {
            entity.HasKey(e => new { e.MacAddress, e.Project });

            entity.ToTable("tbl_LicenceRegisted");

            entity.Property(e => e.MacAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Project)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ComputerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.IsCheckDate).HasColumnName("isCheckDate");
            entity.Property(e => e.ToDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblLoginLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_LoginLog");

            entity.Property(e => e.ComputerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoginDate).HasColumnType("datetime");
            entity.Property(e => e.MacAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Project)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblMenu>(entity =>
        {
            entity.ToTable("tbl_Menu");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NameEng)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Name_Eng");
            entity.Property(e => e.ParentId).HasColumnName("Parent_ID");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<TblMenuRole>(entity =>
        {
            entity.HasKey(e => new { e.RoleName, e.MenuId });

            entity.ToTable("tbl_Menu_Role");

            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            entity.HasOne(d => d.Menu).WithMany(p => p.TblMenuRoles)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Menu_Role_tbl_Menu");

            entity.HasOne(d => d.RoleNameNavigation).WithMany(p => p.TblMenuRoles)
                .HasForeignKey(d => d.RoleName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Menu_Role_tbl_Role");
        });

        modelBuilder.Entity<TblMessage>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("tbl_Message");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.MsAction).HasMaxLength(500);
            entity.Property(e => e.MsCaption).HasMaxLength(100);
            entity.Property(e => e.MsCause).HasMaxLength(500);
        });

        modelBuilder.Entity<TblMessageLang>(entity =>
        {
            entity.HasKey(e => new { e.Code, e.Lang }).HasName("PK_tbl_MassageLang");

            entity.ToTable("tbl_MessageLang");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Lang)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.MsAction).HasMaxLength(500);
            entity.Property(e => e.MsCaption).HasMaxLength(100);
            entity.Property(e => e.MsCause).HasMaxLength(500);

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.TblMessageLangs)
                .HasForeignKey(d => d.Code)
                .HasConstraintName("FK_tbl_MassageLang_tbl_Message");
        });

        modelBuilder.Entity<TblPermissionDatabase>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_PermissionDatabase");

            entity.Property(e => e.Pdatabase)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PDatabase");
            entity.Property(e => e.PermissionName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.PermissionNameNavigation).WithMany()
                .HasForeignKey(d => d.PermissionName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_PermissionDatabase_tbl_SystemPermission");
        });

        modelBuilder.Entity<TblPermissionType>(entity =>
        {
            entity.HasKey(e => e.Pos);

            entity.ToTable("tbl_PermissionType");

            entity.Property(e => e.Pos).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PropCaption)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PropName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UseType)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProject>(entity =>
        {
            entity.HasKey(e => e.CodeProject);

            entity.ToTable("tbl_project");

            entity.Property(e => e.CodeProject)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DatabaseName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Owner)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ServerName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProjectInfo>(entity =>
        {
            entity.HasKey(e => e.Codeproject);

            entity.ToTable("tbl_project_info");

            entity.Property(e => e.Codeproject)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("codeproject");
            entity.Property(e => e.Data)
                .HasMaxLength(8000)
                .HasColumnName("data");
            entity.Property(e => e.Project)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("project");
            entity.Property(e => e.UseThisInfo).HasDefaultValue(0);
        });

        modelBuilder.Entity<TblReportPermission>(entity =>
        {
            entity.HasKey(e => new { e.UserName, e.ReportName });

            entity.ToTable("tbl_ReportPermission");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ReportName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsDefault).HasColumnName("isDefault");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.TblReportPermissions)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_tbl_ReportPermission_tbl_UserAccount");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleName);

            entity.ToTable("tbl_Role");

            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.IsSystem).HasColumnName("isSystem");

            entity.HasMany(d => d.RoleNames).WithMany(p => p.UseRoles)
                .UsingEntity<Dictionary<string, object>>(
                    "TblRole2Role",
                    r => r.HasOne<TblRole>().WithMany()
                        .HasForeignKey("RoleName")
                        .HasConstraintName("FK_tbl_Role2Role_tbl_Role"),
                    l => l.HasOne<TblRole>().WithMany()
                        .HasForeignKey("UseRole")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tbl_Role2Role_tbl_Role1"),
                    j =>
                    {
                        j.HasKey("RoleName", "UseRole").HasName("PK_Role2Role");
                        j.ToTable("tbl_Role2Role");
                        j.IndexerProperty<string>("RoleName")
                            .HasMaxLength(30)
                            .IsUnicode(false);
                        j.IndexerProperty<string>("UseRole")
                            .HasMaxLength(30)
                            .IsUnicode(false);
                    });

            entity.HasMany(d => d.UseRoles).WithMany(p => p.RoleNames)
                .UsingEntity<Dictionary<string, object>>(
                    "TblRole2Role",
                    r => r.HasOne<TblRole>().WithMany()
                        .HasForeignKey("UseRole")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_tbl_Role2Role_tbl_Role1"),
                    l => l.HasOne<TblRole>().WithMany()
                        .HasForeignKey("RoleName")
                        .HasConstraintName("FK_tbl_Role2Role_tbl_Role"),
                    j =>
                    {
                        j.HasKey("RoleName", "UseRole").HasName("PK_Role2Role");
                        j.ToTable("tbl_Role2Role");
                        j.IndexerProperty<string>("RoleName")
                            .HasMaxLength(30)
                            .IsUnicode(false);
                        j.IndexerProperty<string>("UseRole")
                            .HasMaxLength(30)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<TblRoleFunctionPermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleName, e.FunctionName });

            entity.ToTable("tbl_RoleFunctionPermission");

            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.PermissionType)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.FunctionNameNavigation).WithMany(p => p.TblRoleFunctionPermissions)
                .HasForeignKey(d => d.FunctionName)
                .HasConstraintName("FK_tbl_RoleFunctionPermission_tbl_Function");

            entity.HasOne(d => d.RoleNameNavigation).WithMany(p => p.TblRoleFunctionPermissions)
                .HasForeignKey(d => d.RoleName)
                .HasConstraintName("FK_tbl_RoleFunctionPermission_tbl_Role");
        });

        modelBuilder.Entity<TblRoleLayoutPermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleName, e.LayoutName });

            entity.ToTable("tbl_RoleLayoutPermission");

            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsDefault).HasColumnName("isDefault");

            entity.HasOne(d => d.LayoutNameNavigation).WithMany(p => p.TblRoleLayoutPermissions)
                .HasForeignKey(d => d.LayoutName)
                .HasConstraintName("FK_tbl_RoleLayoutPermission_tbl_Layout");

            entity.HasOne(d => d.RoleNameNavigation).WithMany(p => p.TblRoleLayoutPermissions)
                .HasForeignKey(d => d.RoleName)
                .HasConstraintName("FK_tbl_RoleLayoutPermission_tbl_Role");
        });

        modelBuilder.Entity<TblRoleReportPermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleName, e.ReportName });

            entity.ToTable("tbl_RoleReportPermission");

            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReportName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.RoleNameNavigation).WithMany(p => p.TblRoleReportPermissions)
                .HasForeignKey(d => d.RoleName)
                .HasConstraintName("FK_tbl_RoleReportPermission_tbl_Role");
        });

        modelBuilder.Entity<TblRoleSystemPermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleName, e.PermissionName });

            entity.ToTable("tbl_RoleSystemPermission");

            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PermissionName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

            entity.HasOne(d => d.PermissionNameNavigation).WithMany(p => p.TblRoleSystemPermissions)
                .HasForeignKey(d => d.PermissionName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_RoleSystemPermission_tbl_SystemPermission");

            entity.HasOne(d => d.RoleNameNavigation).WithMany(p => p.TblRoleSystemPermissions)
                .HasForeignKey(d => d.RoleName)
                .HasConstraintName("FK_tbl_RoleSystemPermission_tbl_Role");
        });

        modelBuilder.Entity<TblSystemPermission>(entity =>
        {
            entity.HasKey(e => e.PermissionName);

            entity.ToTable("tbl_SystemPermission");

            entity.Property(e => e.PermissionName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("comment");
        });

        modelBuilder.Entity<TblText>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_text");

            entity.Property(e => e.Dectext)
                .HasColumnType("text")
                .HasColumnName("dectext");
            entity.Property(e => e.Enctext)
                .HasColumnType("text")
                .HasColumnName("enctext");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Text)
                .HasColumnType("text")
                .HasColumnName("text");
        });

        modelBuilder.Entity<TblUpdateFile>(entity =>
        {
            entity.HasKey(e => e.FileId);

            entity.ToTable("tbl_UpdateFile");

            entity.Property(e => e.FileId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FileID");
            entity.Property(e => e.FileName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsRarfile).HasColumnName("IsRARfile");
            entity.Property(e => e.PublishDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TblUserAccount>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK_SS_UserAccount");

            entity.ToTable("tbl_UserAccount");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(70);
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.LayoutDefault)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(88)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(172)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Signature).HasColumnType("image");
            entity.Property(e => e.ToolBarDefault)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUserDefaultValue>(entity =>
        {
            entity.HasKey(e => new { e.UserName, e.PropName, e.Project });

            entity.ToTable("tbl_UserDefaultValue");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PropName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Project)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("system");
            entity.Property(e => e.PropValue)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId);

            entity.ToTable("tbl_UserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.RoleNameNavigation).WithMany(p => p.TblUserRoles)
                .HasForeignKey(d => d.RoleName)
                .HasConstraintName("FK_tbl_UserRole_tbl_Role");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.TblUserRoles)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_tbl_UserRole_tbl_UserAccount");
        });

        modelBuilder.Entity<TblUserSystemPermission>(entity =>
        {
            entity.HasKey(e => new { e.UserName, e.PermissionName });

            entity.ToTable("tbl_UserSystemPermission");

            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PermissionName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

            entity.HasOne(d => d.PermissionNameNavigation).WithMany(p => p.TblUserSystemPermissions)
                .HasForeignKey(d => d.PermissionName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_UserSystemPermission_tbl_SystemPermission");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.TblUserSystemPermissions)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_tbl_UserSystemPermission_tbl_UserAccount");
        });

        modelBuilder.Entity<TblUserTool>(entity =>
        {
            entity.HasKey(e => e.ToolName);

            entity.ToTable("tbl_UserTool");

            entity.Property(e => e.ToolName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ToolBar).HasColumnType("image");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwControlLabel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ControlLabel");

            entity.Property(e => e.FormName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FunctionDesc).HasMaxLength(100);
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lang)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwFormControlDefaultLabel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_FormControlDefaultLabel");

            entity.Property(e => e.CodeProject)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FormName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FunctionName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwLayoutDefault>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_LayoutDefault");

            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Owner)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Version)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<VwLayoutPrj>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Layout_Prj");

            entity.Property(e => e.CodeProject)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.FormImage).HasColumnType("image");
            entity.Property(e => e.FunctionDesc).HasMaxLength(100);
            entity.Property(e => e.FunctionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LayoutContent).HasColumnType("image");
            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Owner)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Version)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<VwLayoutUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_LayoutUser");

            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.FormImage).HasColumnType("image");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LayoutContent).HasColumnType("image");
            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Owner)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Version)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<VwMessageLang>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MessageLang");

            entity.Property(e => e.Code)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Lang)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.MsAction).HasMaxLength(500);
            entity.Property(e => e.MsCaption).HasMaxLength(100);
            entity.Property(e => e.MsCause).HasMaxLength(500);
        });

        modelBuilder.Entity<VwRole2role>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_role2role");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsSystem).HasColumnName("isSystem");
            entity.Property(e => e.ProleName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PRoleName");
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwUserLayout>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UserLayout");

            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwUserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UserRole");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsSystem).HasColumnName("isSystem");
            entity.Property(e => e.RoleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwUserRoleLayout>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UserRoleLayout");

            entity.Property(e => e.LayoutName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwUserRoleSystem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UserRoleSystem");

            entity.Property(e => e.PermissionName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwUserSystem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UserSystem");

            entity.Property(e => e.PermissionName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
