namespace Pokemon.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CapturedPokemons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MasterId = c.Int(nullable: false),
                        PokemonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Masters", t => t.MasterId, cascadeDelete: true)
                .ForeignKey("dbo.Pokemons", t => t.PokemonId, cascadeDelete: true)
                .Index(t => t.MasterId)
                .Index(t => t.PokemonId);
            
            CreateTable(
                "dbo.Masters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        FullName = c.String(),
                        UserName = c.String(),
                        CPF = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pokemons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PokeApiId = c.Int(nullable: false),
                        BaseExperience = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Name = c.String(),
                        Sprite = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CapturedPokemons", "PokemonId", "dbo.Pokemons");
            DropForeignKey("dbo.CapturedPokemons", "MasterId", "dbo.Masters");
            DropIndex("dbo.CapturedPokemons", new[] { "PokemonId" });
            DropIndex("dbo.CapturedPokemons", new[] { "MasterId" });
            DropTable("dbo.Pokemons");
            DropTable("dbo.Masters");
            DropTable("dbo.CapturedPokemons");
        }
    }
}
