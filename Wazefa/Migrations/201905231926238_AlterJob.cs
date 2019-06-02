namespace Wazefa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterJob : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Jobs", name: "user_Id", newName: "userid");
            RenameIndex(table: "dbo.Jobs", name: "IX_user_Id", newName: "IX_userid");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Jobs", name: "IX_userid", newName: "IX_user_Id");
            RenameColumn(table: "dbo.Jobs", name: "userid", newName: "user_Id");
        }
    }
}
