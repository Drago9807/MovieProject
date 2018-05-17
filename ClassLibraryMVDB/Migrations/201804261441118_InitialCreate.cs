namespace MovieProjectDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        UserName = c.String(maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Email = c.String(maxLength: 20),
                        PhoneNumber = c.String(maxLength: 50),
                        Address = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
