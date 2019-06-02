namespace Wazefa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditJob : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "TimeAdd", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "TimeAdd", c => c.DateTime());
        }
    }
}
