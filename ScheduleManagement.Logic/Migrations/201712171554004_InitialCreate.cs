namespace ScheduleManagement.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabinets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        HasComputers = c.Boolean(nullable: false),
                        HasWhiteBoard = c.Boolean(nullable: false),
                        PlacesAmount = c.Int(nullable: false),
                        School_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schools", t => t.School_ID)
                .Index(t => t.School_ID);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TutorCabinets",
                c => new
                    {
                        CabinetId = c.Int(nullable: false),
                        LessonOrder = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CabinetId, t.LessonOrder, t.Date })
                .ForeignKey("dbo.Cabinets", t => t.CabinetId, cascadeDelete: true)
                .ForeignKey("dbo.Tutors", t => t.TutorId, cascadeDelete: true)
                .Index(t => t.CabinetId)
                .Index(t => t.TutorId);
            
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TutorCabinets", "TutorId", "dbo.Tutors");
            DropForeignKey("dbo.TutorCabinets", "CabinetId", "dbo.Cabinets");
            DropForeignKey("dbo.Cabinets", "School_ID", "dbo.Schools");
            DropIndex("dbo.TutorCabinets", new[] { "TutorId" });
            DropIndex("dbo.TutorCabinets", new[] { "CabinetId" });
            DropIndex("dbo.Cabinets", new[] { "School_ID" });
            DropTable("dbo.Tutors");
            DropTable("dbo.TutorCabinets");
            DropTable("dbo.Schools");
            DropTable("dbo.Cabinets");
        }
    }
}
