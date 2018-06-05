namespace MovieProjectDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Address = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false),
                        MoviePrice = c.Double(nullable: false)
                    })
                .PrimaryKey(t => t.MovieId);

            CreateTable(
               "dbo.Genres",
               c => new
                   {
                       GenreId = c.Int(nullable: false, identity: true),
                       GenreType = c.String(nullable: false),
                       MoviePrice = c.Double(nullable: false)
                   })
               .PrimaryKey(t => t.GenreId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Movies");
            DropTable("Genres");
        }
    }
}
