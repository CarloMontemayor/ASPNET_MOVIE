﻿namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "FullName");
        }
    }
}
