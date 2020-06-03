namespace Neel.Core.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeModels", "EmployeeName", c => c.String());
            AlterColumn("dbo.EmployeeModels", "Designation", c => c.String());
            AlterColumn("dbo.EmployeeModels", "MobileNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeModels", "MobileNumber", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeModels", "Designation", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeModels", "EmployeeName", c => c.String(nullable: false));
        }
    }
}
