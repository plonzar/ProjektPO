namespace ProjektPO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryEntities", "Name", c => c.String());
            AddColumn("dbo.CategoryEntities", "UserEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.CategoryItemEntities", "Name", c => c.String());
            AddColumn("dbo.CategoryItemEntities", "CategoryEntity_Id", c => c.Int(nullable: false));
            AddColumn("dbo.CategoryItemEntities", "IcludeInAstimates", c => c.Boolean(nullable: false));
            AddColumn("dbo.CategoryItemEntities", "UserEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.CategoryItemEntities", "CategoryEntity_Id1", c => c.Int());
            AddColumn("dbo.OperationEntities", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.OperationEntities", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OperationEntities", "CategoryItemId", c => c.Int(nullable: false));
            AddColumn("dbo.OperationEntities", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.OperationEntities", "Note", c => c.String());
            AddColumn("dbo.OperationEntities", "UserEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.OperationEntities", "Category_Id", c => c.Int());
            AddColumn("dbo.UserEntities", "Name", c => c.String());
            AddColumn("dbo.UserEntities", "Password", c => c.String());
            CreateIndex("dbo.CategoryEntities", "UserEntityId");
            CreateIndex("dbo.CategoryItemEntities", "UserEntityId");
            CreateIndex("dbo.CategoryItemEntities", "CategoryEntity_Id1");
            CreateIndex("dbo.OperationEntities", "UserEntityId");
            CreateIndex("dbo.OperationEntities", "Category_Id");
            AddForeignKey("dbo.CategoryItemEntities", "CategoryEntity_Id1", "dbo.CategoryEntities", "Id");
            AddForeignKey("dbo.CategoryItemEntities", "UserEntityId", "dbo.UserEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategoryEntities", "UserEntityId", "dbo.UserEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OperationEntities", "Category_Id", "dbo.CategoryItemEntities", "Id");
            AddForeignKey("dbo.OperationEntities", "UserEntityId", "dbo.UserEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OperationEntities", "UserEntityId", "dbo.UserEntities");
            DropForeignKey("dbo.OperationEntities", "Category_Id", "dbo.CategoryItemEntities");
            DropForeignKey("dbo.CategoryEntities", "UserEntityId", "dbo.UserEntities");
            DropForeignKey("dbo.CategoryItemEntities", "UserEntityId", "dbo.UserEntities");
            DropForeignKey("dbo.CategoryItemEntities", "CategoryEntity_Id1", "dbo.CategoryEntities");
            DropIndex("dbo.OperationEntities", new[] { "Category_Id" });
            DropIndex("dbo.OperationEntities", new[] { "UserEntityId" });
            DropIndex("dbo.CategoryItemEntities", new[] { "CategoryEntity_Id1" });
            DropIndex("dbo.CategoryItemEntities", new[] { "UserEntityId" });
            DropIndex("dbo.CategoryEntities", new[] { "UserEntityId" });
            DropColumn("dbo.UserEntities", "Password");
            DropColumn("dbo.UserEntities", "Name");
            DropColumn("dbo.OperationEntities", "Category_Id");
            DropColumn("dbo.OperationEntities", "UserEntityId");
            DropColumn("dbo.OperationEntities", "Note");
            DropColumn("dbo.OperationEntities", "Type");
            DropColumn("dbo.OperationEntities", "CategoryItemId");
            DropColumn("dbo.OperationEntities", "Amount");
            DropColumn("dbo.OperationEntities", "Date");
            DropColumn("dbo.CategoryItemEntities", "CategoryEntity_Id1");
            DropColumn("dbo.CategoryItemEntities", "UserEntityId");
            DropColumn("dbo.CategoryItemEntities", "IcludeInAstimates");
            DropColumn("dbo.CategoryItemEntities", "CategoryEntity_Id");
            DropColumn("dbo.CategoryItemEntities", "Name");
            DropColumn("dbo.CategoryEntities", "UserEntityId");
            DropColumn("dbo.CategoryEntities", "Name");
        }
    }
}
