namespace Digoel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToPasswordStorage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PasswordStorages", "Website", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.PasswordStorages", "DateSaved", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PasswordStorages", "DateSaved", c => c.String());
            AlterColumn("dbo.PasswordStorages", "Website", c => c.String());
        }
    }
}
