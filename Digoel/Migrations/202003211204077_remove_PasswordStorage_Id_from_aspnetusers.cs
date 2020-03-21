namespace Digoel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_PasswordStorage_Id_from_aspnetusers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "PasswordStorage_Id", "dbo.PasswordStorages");
            DropIndex("dbo.AspNetUsers", new[] { "PasswordStorage_Id" });
            DropColumn("dbo.AspNetUsers", "PasswordStorage_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PasswordStorage_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "PasswordStorage_Id");
            AddForeignKey("dbo.AspNetUsers", "PasswordStorage_Id", "dbo.PasswordStorages", "Id");
        }
    }
}
