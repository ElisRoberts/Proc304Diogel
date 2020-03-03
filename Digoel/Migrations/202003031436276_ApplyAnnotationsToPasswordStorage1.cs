namespace Digoel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToPasswordStorage1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PasswordStorages", "Password", c => c.String(nullable: false, maxLength: 75));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PasswordStorages", "Password", c => c.String());
        }
    }
}
