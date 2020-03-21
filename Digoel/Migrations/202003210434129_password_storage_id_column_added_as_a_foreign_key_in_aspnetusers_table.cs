namespace Digoel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class password_storage_id_column_added_as_a_foreign_key_in_aspnetusers_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PasswordStorage_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "PasswordStorage_Id");
            AddForeignKey("dbo.AspNetUsers", "PasswordStorage_Id", "dbo.PasswordStorages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PasswordStorage_Id", "dbo.PasswordStorages");
            DropIndex("dbo.AspNetUsers", new[] { "PasswordStorage_Id" });
            DropColumn("dbo.AspNetUsers", "PasswordStorage_Id");
        }
    }
}
