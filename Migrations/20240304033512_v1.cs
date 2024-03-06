using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBasedAuthorization.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_AppInfo",
                columns: table => new
                {
                    CodeProject = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Version = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ServerPath = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isSetup = table.Column<bool>(type: "bit", nullable: false),
                    FileID = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EnforceUpdate = table.Column<bool>(type: "bit", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AppInfo", x => x.CodeProject);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ButtonLang",
                columns: table => new
                {
                    Button = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Lang = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ButtonLang", x => new { x.Button, x.Lang });
                });

            migrationBuilder.CreateTable(
                name: "tbl_ControlDefaultLabel",
                columns: table => new
                {
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ControlName = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Lang = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    ControlType = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    PropCaption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PropParent = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    PropHint = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ControlDefaultLabel", x => new { x.FunctionName, x.ControlName, x.Lang });
                });

            migrationBuilder.CreateTable(
                name: "tbl_ControlLabel",
                columns: table => new
                {
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Lang = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    ControlLabel = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ControlLabel", x => new { x.FunctionName, x.Lang });
                });

            migrationBuilder.CreateTable(
                name: "tbl_default",
                columns: table => new
                {
                    cName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    cValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_default", x => x.cName);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Function",
                columns: table => new
                {
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FunctionDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValue: "-"),
                    Enabled = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    FunctionType = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    CodeProject = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Owner = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    FormName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SS_Function", x => x.FunctionName);
                });

            migrationBuilder.CreateTable(
                name: "tbl_function_data",
                columns: table => new
                {
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ObjectName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Ins = table.Column<int>(type: "int", nullable: false),
                    Upd = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sel = table.Column<int>(type: "int", nullable: false),
                    Exc = table.Column<int>(type: "int", nullable: false),
                    ObjectType = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_function_data", x => new { x.FunctionName, x.ObjectName });
                });

            migrationBuilder.CreateTable(
                name: "tbl_FunctionDetail",
                columns: table => new
                {
                    PermissionType = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FunctionDetail", x => x.PermissionType);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FunctionType",
                columns: table => new
                {
                    Type = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FunctionType", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Info",
                columns: table => new
                {
                    iName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    iValue = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    iComment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.iName);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Info1",
                columns: table => new
                {
                    iName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    iValue = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    iComment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_Language",
                columns: table => new
                {
                    Lang_eng = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Lang = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Language", x => x.Lang_eng);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LicenceRegisted",
                columns: table => new
                {
                    MacAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Project = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ComputerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    isCheckDate = table.Column<bool>(type: "bit", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DefaultBranch = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LicenceRegisted", x => new { x.MacAddress, x.Project });
                });

            migrationBuilder.CreateTable(
                name: "tbl_LoginLog",
                columns: table => new
                {
                    LoginDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    MacAddress = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ComputerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Project = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name_Eng = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Icon = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    Parent_ID = table.Column<int>(type: "int", nullable: false),
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Message",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MsCause = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MsAction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MsIcon = table.Column<int>(type: "int", nullable: false),
                    MsButton = table.Column<int>(type: "int", nullable: false),
                    MsButtonDefault = table.Column<int>(type: "int", nullable: false),
                    MsCaption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Message", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PermissionType",
                columns: table => new
                {
                    Pos = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    PropName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PropCaption = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UseType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PermissionType", x => x.Pos);
                });

            migrationBuilder.CreateTable(
                name: "tbl_project",
                columns: table => new
                {
                    CodeProject = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Owner = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ServerName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DatabaseName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_project", x => x.CodeProject);
                });

            migrationBuilder.CreateTable(
                name: "tbl_project_info",
                columns: table => new
                {
                    codeproject = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    data = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: true),
                    UseThisInfo = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    project = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_project_info", x => x.codeproject);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Role",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    isSystem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Role", x => x.RoleName);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SystemPermission",
                columns: table => new
                {
                    PermissionName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    comment = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SystemPermission", x => x.PermissionName);
                });

            migrationBuilder.CreateTable(
                name: "tbl_text",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "text", nullable: true),
                    enctext = table.Column<string>(type: "text", nullable: true),
                    dectext = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_UpdateFile",
                columns: table => new
                {
                    FileID = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    PublishDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IsRARfile = table.Column<bool>(type: "bit", nullable: true),
                    FileName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UpdateFile", x => x.FileID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserAccount",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FullName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LayoutDefault = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    ToolBarDefault = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Signature = table.Column<byte[]>(type: "image", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PasswordHash = table.Column<string>(type: "char(88)", unicode: false, fixedLength: true, maxLength: 88, nullable: true),
                    PasswordSalt = table.Column<string>(type: "char(172)", unicode: false, fixedLength: true, maxLength: 172, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SS_UserAccount", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserDefaultValue",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PropName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Project = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "system"),
                    PropValue = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserDefaultValue", x => new { x.UserName, x.PropName, x.Project });
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserTool",
                columns: table => new
                {
                    ToolName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ToolBar = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserTool", x => x.ToolName);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FunctionPermission",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PermissionType = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FunctionPermission", x => new { x.UserName, x.FunctionName });
                    table.ForeignKey(
                        name: "FK_tbl_FunctionPermission_tbl_Function",
                        column: x => x.FunctionName,
                        principalTable: "tbl_Function",
                        principalColumn: "FunctionName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Layout",
                columns: table => new
                {
                    LayoutName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Owner = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, defaultValue: "INNOSOFT"),
                    DateCreate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FormImage = table.Column<byte[]>(type: "image", nullable: true),
                    Version = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: true),
                    LayoutContent = table.Column<byte[]>(type: "image", nullable: true),
                    CodeLayout = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Layout", x => x.LayoutName);
                    table.ForeignKey(
                        name: "FK_tbl_Layout_tbl_Function",
                        column: x => x.FunctionName,
                        principalTable: "tbl_Function",
                        principalColumn: "FunctionName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_MessageLang",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Lang = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MsCause = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MsAction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MsCaption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MassageLang", x => new { x.Code, x.Lang });
                    table.ForeignKey(
                        name: "FK_tbl_MassageLang_tbl_Message",
                        column: x => x.Code,
                        principalTable: "tbl_Message",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Menu_Role",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Menu_Role", x => new { x.RoleName, x.MenuID });
                    table.ForeignKey(
                        name: "FK_tbl_Menu_Role_tbl_Menu",
                        column: x => x.MenuID,
                        principalTable: "tbl_Menu",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tbl_Menu_Role_tbl_Role",
                        column: x => x.RoleName,
                        principalTable: "tbl_Role",
                        principalColumn: "RoleName");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Role2Role",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    UseRole = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role2Role", x => new { x.RoleName, x.UseRole });
                    table.ForeignKey(
                        name: "FK_tbl_Role2Role_tbl_Role",
                        column: x => x.RoleName,
                        principalTable: "tbl_Role",
                        principalColumn: "RoleName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Role2Role_tbl_Role1",
                        column: x => x.UseRole,
                        principalTable: "tbl_Role",
                        principalColumn: "RoleName");
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoleFunctionPermission",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PermissionType = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoleFunctionPermission", x => new { x.RoleName, x.FunctionName });
                    table.ForeignKey(
                        name: "FK_tbl_RoleFunctionPermission_tbl_Function",
                        column: x => x.FunctionName,
                        principalTable: "tbl_Function",
                        principalColumn: "FunctionName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_RoleFunctionPermission_tbl_Role",
                        column: x => x.RoleName,
                        principalTable: "tbl_Role",
                        principalColumn: "RoleName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoleReportPermission",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    ReportName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoleReportPermission", x => new { x.RoleName, x.ReportName });
                    table.ForeignKey(
                        name: "FK_tbl_RoleReportPermission_tbl_Role",
                        column: x => x.RoleName,
                        principalTable: "tbl_Role",
                        principalColumn: "RoleName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PermissionDatabase",
                columns: table => new
                {
                    PermissionName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    PDatabase = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tbl_PermissionDatabase_tbl_SystemPermission",
                        column: x => x.PermissionName,
                        principalTable: "tbl_SystemPermission",
                        principalColumn: "PermissionName");
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoleSystemPermission",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    PermissionName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoleSystemPermission", x => new { x.RoleName, x.PermissionName });
                    table.ForeignKey(
                        name: "FK_tbl_RoleSystemPermission_tbl_Role",
                        column: x => x.RoleName,
                        principalTable: "tbl_Role",
                        principalColumn: "RoleName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_RoleSystemPermission_tbl_SystemPermission",
                        column: x => x.PermissionName,
                        principalTable: "tbl_SystemPermission",
                        principalColumn: "PermissionName");
                });

            migrationBuilder.CreateTable(
                name: "tbl_ControlProfile",
                columns: table => new
                {
                    ProfileName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ControlType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ControlName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastDay = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Content = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ControlProfile", x => new { x.ProfileName, x.UserName });
                    table.ForeignKey(
                        name: "FK_tbl_ControlProfile_tbl_Function",
                        column: x => x.FunctionName,
                        principalTable: "tbl_Function",
                        principalColumn: "FunctionName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_ControlProfile_tbl_UserAccount",
                        column: x => x.UserName,
                        principalTable: "tbl_UserAccount",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ReportPermission",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ReportName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    isDefault = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ReportPermission", x => new { x.UserName, x.ReportName });
                    table.ForeignKey(
                        name: "FK_tbl_ReportPermission_tbl_UserAccount",
                        column: x => x.UserName,
                        principalTable: "tbl_UserAccount",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserRole",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserRole", x => x.UserRoleID);
                    table.ForeignKey(
                        name: "FK_tbl_UserRole_tbl_Role",
                        column: x => x.RoleName,
                        principalTable: "tbl_Role",
                        principalColumn: "RoleName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_UserRole_tbl_UserAccount",
                        column: x => x.UserName,
                        principalTable: "tbl_UserAccount",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserSystemPermission",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PermissionName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserSystemPermission", x => new { x.UserName, x.PermissionName });
                    table.ForeignKey(
                        name: "FK_tbl_UserSystemPermission_tbl_SystemPermission",
                        column: x => x.PermissionName,
                        principalTable: "tbl_SystemPermission",
                        principalColumn: "PermissionName");
                    table.ForeignKey(
                        name: "FK_tbl_UserSystemPermission_tbl_UserAccount",
                        column: x => x.UserName,
                        principalTable: "tbl_UserAccount",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FormControls",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlType = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    PropName = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: false),
                    PropStyleController = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    PropTop = table.Column<int>(type: "int", nullable: false),
                    PropLeft = table.Column<int>(type: "int", nullable: false),
                    PropWidth = table.Column<int>(type: "int", nullable: false),
                    PropHeigh = table.Column<int>(type: "int", nullable: false),
                    PropAnchor = table.Column<int>(type: "int", nullable: false),
                    PropDoc = table.Column<int>(type: "int", nullable: false),
                    PropBackColor = table.Column<int>(type: "int", nullable: false),
                    PropIsKnownBackColor = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    PropForeColor = table.Column<int>(type: "int", nullable: false),
                    PropIsKnownForeColor = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    PropFontName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PropFontSize = table.Column<double>(type: "float", nullable: false),
                    PropFontStyle = table.Column<short>(type: "smallint", nullable: false),
                    PropFontGdiCharSet = table.Column<short>(type: "smallint", nullable: false),
                    PropFontStrikeout = table.Column<short>(type: "smallint", nullable: false),
                    PropFontUnderline = table.Column<short>(type: "smallint", nullable: false),
                    PropEnable = table.Column<short>(type: "smallint", nullable: true),
                    PropVisible = table.Column<short>(type: "smallint", nullable: true),
                    PropParent = table.Column<string>(type: "varchar(35)", unicode: false, maxLength: 35, nullable: true),
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    LayoutName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    DefaultValue = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PropLabel = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PropTabIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FormControls", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_FormControls_tbl_Layout",
                        column: x => x.LayoutName,
                        principalTable: "tbl_Layout",
                        principalColumn: "LayoutName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LayoutDefault",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FunctionName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LayoutName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LayoutDefault", x => new { x.UserName, x.FunctionName });
                    table.ForeignKey(
                        name: "FK_tbl_LayoutDefault_tbl_Layout",
                        column: x => x.LayoutName,
                        principalTable: "tbl_Layout",
                        principalColumn: "LayoutName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_LayoutDefault_tbl_UserAccount",
                        column: x => x.UserName,
                        principalTable: "tbl_UserAccount",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LayoutPermission",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LayoutName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    isDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LayoutPermission", x => new { x.UserName, x.LayoutName });
                    table.ForeignKey(
                        name: "FK_tbl_LayoutPermission_tbl_Layout",
                        column: x => x.LayoutName,
                        principalTable: "tbl_Layout",
                        principalColumn: "LayoutName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_LayoutPermission_tbl_UserAccount",
                        column: x => x.UserName,
                        principalTable: "tbl_UserAccount",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoleLayoutPermission",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    LayoutName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    isDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoleLayoutPermission", x => new { x.RoleName, x.LayoutName });
                    table.ForeignKey(
                        name: "FK_tbl_RoleLayoutPermission_tbl_Layout",
                        column: x => x.LayoutName,
                        principalTable: "tbl_Layout",
                        principalColumn: "LayoutName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_RoleLayoutPermission_tbl_Role",
                        column: x => x.RoleName,
                        principalTable: "tbl_Role",
                        principalColumn: "RoleName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ControlProfile_FunctionName",
                table: "tbl_ControlProfile",
                column: "FunctionName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ControlProfile_UserName",
                table: "tbl_ControlProfile",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_FormControls_LayoutName",
                table: "tbl_FormControls",
                column: "LayoutName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_FunctionPermission_FunctionName",
                table: "tbl_FunctionPermission",
                column: "FunctionName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Layout_FunctionName",
                table: "tbl_Layout",
                column: "FunctionName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LayoutDefault_LayoutName",
                table: "tbl_LayoutDefault",
                column: "LayoutName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LayoutPermission_LayoutName",
                table: "tbl_LayoutPermission",
                column: "LayoutName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Menu_Role_MenuID",
                table: "tbl_Menu_Role",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PermissionDatabase_PermissionName",
                table: "tbl_PermissionDatabase",
                column: "PermissionName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Role2Role_UseRole",
                table: "tbl_Role2Role",
                column: "UseRole");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoleFunctionPermission_FunctionName",
                table: "tbl_RoleFunctionPermission",
                column: "FunctionName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoleLayoutPermission_LayoutName",
                table: "tbl_RoleLayoutPermission",
                column: "LayoutName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoleSystemPermission_PermissionName",
                table: "tbl_RoleSystemPermission",
                column: "PermissionName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserRole_RoleName",
                table: "tbl_UserRole",
                column: "RoleName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserRole_UserName",
                table: "tbl_UserRole",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserSystemPermission_PermissionName",
                table: "tbl_UserSystemPermission",
                column: "PermissionName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AppInfo");

            migrationBuilder.DropTable(
                name: "tbl_ButtonLang");

            migrationBuilder.DropTable(
                name: "tbl_ControlDefaultLabel");

            migrationBuilder.DropTable(
                name: "tbl_ControlLabel");

            migrationBuilder.DropTable(
                name: "tbl_ControlProfile");

            migrationBuilder.DropTable(
                name: "tbl_default");

            migrationBuilder.DropTable(
                name: "tbl_FormControls");

            migrationBuilder.DropTable(
                name: "tbl_function_data");

            migrationBuilder.DropTable(
                name: "tbl_FunctionDetail");

            migrationBuilder.DropTable(
                name: "tbl_FunctionPermission");

            migrationBuilder.DropTable(
                name: "tbl_FunctionType");

            migrationBuilder.DropTable(
                name: "tbl_Info");

            migrationBuilder.DropTable(
                name: "tbl_Info1");

            migrationBuilder.DropTable(
                name: "tbl_Language");

            migrationBuilder.DropTable(
                name: "tbl_LayoutDefault");

            migrationBuilder.DropTable(
                name: "tbl_LayoutPermission");

            migrationBuilder.DropTable(
                name: "tbl_LicenceRegisted");

            migrationBuilder.DropTable(
                name: "tbl_LoginLog");

            migrationBuilder.DropTable(
                name: "tbl_Menu_Role");

            migrationBuilder.DropTable(
                name: "tbl_MessageLang");

            migrationBuilder.DropTable(
                name: "tbl_PermissionDatabase");

            migrationBuilder.DropTable(
                name: "tbl_PermissionType");

            migrationBuilder.DropTable(
                name: "tbl_project");

            migrationBuilder.DropTable(
                name: "tbl_project_info");

            migrationBuilder.DropTable(
                name: "tbl_ReportPermission");

            migrationBuilder.DropTable(
                name: "tbl_Role2Role");

            migrationBuilder.DropTable(
                name: "tbl_RoleFunctionPermission");

            migrationBuilder.DropTable(
                name: "tbl_RoleLayoutPermission");

            migrationBuilder.DropTable(
                name: "tbl_RoleReportPermission");

            migrationBuilder.DropTable(
                name: "tbl_RoleSystemPermission");

            migrationBuilder.DropTable(
                name: "tbl_text");

            migrationBuilder.DropTable(
                name: "tbl_UpdateFile");

            migrationBuilder.DropTable(
                name: "tbl_UserDefaultValue");

            migrationBuilder.DropTable(
                name: "tbl_UserRole");

            migrationBuilder.DropTable(
                name: "tbl_UserSystemPermission");

            migrationBuilder.DropTable(
                name: "tbl_UserTool");

            migrationBuilder.DropTable(
                name: "tbl_Menu");

            migrationBuilder.DropTable(
                name: "tbl_Message");

            migrationBuilder.DropTable(
                name: "tbl_Layout");

            migrationBuilder.DropTable(
                name: "tbl_Role");

            migrationBuilder.DropTable(
                name: "tbl_SystemPermission");

            migrationBuilder.DropTable(
                name: "tbl_UserAccount");

            migrationBuilder.DropTable(
                name: "tbl_Function");
        }
    }
}
