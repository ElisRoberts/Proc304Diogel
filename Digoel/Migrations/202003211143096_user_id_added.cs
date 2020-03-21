namespace Digoel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_id_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PasswordStorages", "UserId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PasswordStorages", "UserId");
        }
    }
}
