namespace RandomFactory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRFactoryMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RangeEntities",
                c => new
                    {
                        ValueId = c.Int(nullable: false),
                        Min = c.Double(nullable: false),
                        Max = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ValueId)
                .ForeignKey("dbo.ValueEntities", t => t.ValueId)
                .Index(t => t.ValueId);
            
            CreateTable(
                "dbo.ValueEntities",
                c => new
                    {
                        ValueId = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        Seed = c.Int(nullable: false),
                        Step = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        RangeId = c.Int(),
                    })
                .PrimaryKey(t => t.ValueId)
                .ForeignKey("dbo.ValueTypeEntities", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.ValueTypeEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RangeEntities", "ValueId", "dbo.ValueEntities");
            DropForeignKey("dbo.ValueEntities", "TypeId", "dbo.ValueTypeEntities");
            DropIndex("dbo.ValueEntities", new[] { "TypeId" });
            DropIndex("dbo.RangeEntities", new[] { "ValueId" });
            DropTable("dbo.ValueTypeEntities");
            DropTable("dbo.ValueEntities");
            DropTable("dbo.RangeEntities");
        }
    }
}
