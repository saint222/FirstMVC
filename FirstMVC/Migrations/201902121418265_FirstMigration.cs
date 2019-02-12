namespace FirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Squads", name: "Faction_Id", newName: "FactionId");
            RenameIndex(table: "dbo.Squads", name: "IX_Faction_Id", newName: "IX_FactionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Squads", name: "IX_FactionId", newName: "IX_Faction_Id");
            RenameColumn(table: "dbo.Squads", name: "FactionId", newName: "Faction_Id");
        }
    }
}
