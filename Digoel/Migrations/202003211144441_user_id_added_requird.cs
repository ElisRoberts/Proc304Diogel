namespace Digoel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_id_added_requird : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PasswordStorages", "UserId", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PasswordStorages", "UserId", c => c.String(maxLength: 128));
        }
    }
}
