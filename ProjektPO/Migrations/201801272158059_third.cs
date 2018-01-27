namespace ProjektPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryEntities", "Name", c => c.String());
            AddColumn("dbo.CategoryEntities", "UserEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.CategoryItemEntities", "Name", c => c.String());
            AddColumn("dbo.CategoryItemEntities", "CategoryEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.CategoryItemEntities", "IcludeInAstimates", c => c.Boolean(nullable: false));
            AddColumn("dbo.CategoryItemEntities", "UserEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.OperationEntities", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.OperationEntities", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OperationEntities", "CategoryItemEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.OperationEntities", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.OperationEntities", "Note", c => c.String());
            AddColumn("dbo.OperationEntities", "UserEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.UserEntities", "Name", c => c.String());
            AddColumn("dbo.UserEntities", "Password", c => c.String());
            CreateIndex("dbo.CategoryEntities", "UserEntityId");
            CreateIndex("dbo.CategoryItemEntities", "CategoryEntityId");
            CreateIndex("dbo.CategoryItemEntities", "UserEntityId");
            CreateIndex("dbo.OperationEntities", "CategoryItemEntityId");
            CreateIndex("dbo.OperationEntities", "UserEntityId");
            AddForeignKey("dbo.CategoryItemEntities", "CategoryEntityId", "dbo.CategoryEntities", "Id", cascadeDelete: false);
            AddForeignKey("dbo.CategoryItemEntities", "UserEntityId", "dbo.UserEntities", "Id", cascadeDelete: false);
            AddForeignKey("dbo.CategoryEntities", "UserEntityId", "dbo.UserEntities", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OperationEntities", "CategoryItemEntityId", "dbo.CategoryItemEntities", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OperationEntities", "UserEntityId", "dbo.UserEntities", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OperationEntities", "UserEntityId", "dbo.UserEntities");
            DropForeignKey("dbo.OperationEntities", "CategoryItemEntityId", "dbo.CategoryItemEntities");
            DropForeignKey("dbo.CategoryEntities", "UserEntityId", "dbo.UserEntities");
            DropForeignKey("dbo.CategoryItemEntities", "UserEntityId", "dbo.UserEntities");
            DropForeignKey("dbo.CategoryItemEntities", "CategoryEntityId", "dbo.CategoryEntities");
            DropIndex("dbo.OperationEntities", new[] { "UserEntityId" });
            DropIndex("dbo.OperationEntities", new[] { "CategoryItemEntityId" });
            DropIndex("dbo.CategoryItemEntities", new[] { "UserEntityId" });
            DropIndex("dbo.CategoryItemEntities", new[] { "CategoryEntityId" });
            DropIndex("dbo.CategoryEntities", new[] { "UserEntityId" });
            DropColumn("dbo.UserEntities", "Password");
            DropColumn("dbo.UserEntities", "Name");
            DropColumn("dbo.OperationEntities", "UserEntityId");
            DropColumn("dbo.OperationEntities", "Note");
            DropColumn("dbo.OperationEntities", "Type");
            DropColumn("dbo.OperationEntities", "CategoryItemEntityId");
            DropColumn("dbo.OperationEntities", "Amount");
            DropColumn("dbo.OperationEntities", "Date");
            DropColumn("dbo.CategoryItemEntities", "UserEntityId");
            DropColumn("dbo.CategoryItemEntities", "IcludeInAstimates");
            DropColumn("dbo.CategoryItemEntities", "CategoryEntityId");
            DropColumn("dbo.CategoryItemEntities", "Name");
            DropColumn("dbo.CategoryEntities", "UserEntityId");
            DropColumn("dbo.CategoryEntities", "Name");
        }
    }
}
