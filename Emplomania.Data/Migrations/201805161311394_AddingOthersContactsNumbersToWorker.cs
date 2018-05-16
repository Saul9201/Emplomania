namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOthersContactsNumbersToWorker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "OtherHomePhoneNumber", c => c.String());
            AddColumn("dbo.Workers", "OtherMovilPhoneNumber", c => c.String());
            AddColumn("dbo.Workers", "OtherEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "OtherEmail");
            DropColumn("dbo.Workers", "OtherMovilPhoneNumber");
            DropColumn("dbo.Workers", "OtherHomePhoneNumber");
        }
    }
}
