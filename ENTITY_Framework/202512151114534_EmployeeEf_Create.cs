namespace Code_frist_Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeEf_Create : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Studentstbl");
            CreateTable(
                "dbo.MyEmployee",
                c => new
                    {
                        EmpId = c.String(nullable: false, maxLength: 10, unicode: false),
                        EmpName = c.String(nullable: false, maxLength: 20),
                        DeptName = c.String(nullable: false, maxLength: 30, unicode: false),
                        Salary = c.Int(nullable: false),
                        YearOfJoining = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId);
            
            AlterColumn("dbo.Studentstbl", "Stdid", c => c.Int(nullable: false));
            AlterColumn("dbo.Studentstbl", "Class", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Studentstbl", "Stdid");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Studentstbl");
            AlterColumn("dbo.Studentstbl", "Class", c => c.String(nullable: false));
            AlterColumn("dbo.Studentstbl", "Stdid", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.MyEmployee");
            AddPrimaryKey("dbo.Studentstbl", "Stdid");
        }
    }
}
