namespace WebAppVet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TurnRooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropForeignKey("dbo.TurnRooms", new[] { "Rooms_Id_room", "Rooms_Id_turn" }, "dbo.Rooms");
            DropForeignKey("dbo.DoctorTurns", new[] { "Doctor_Id_doctor", "Doctor_Id_turn" }, "dbo.Doctors");
            DropForeignKey("dbo.DoctorTurns", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropIndex("dbo.TurnRooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropIndex("dbo.TurnRooms", new[] { "Rooms_Id_room", "Rooms_Id_turn" });
            DropIndex("dbo.DoctorTurns", new[] { "Doctor_Id_doctor", "Doctor_Id_turn" });
            DropIndex("dbo.DoctorTurns", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropPrimaryKey("dbo.Doctors");
            DropPrimaryKey("dbo.Rooms");
            AddColumn("dbo.Doctors", "Turn_Id_turn", c => c.Int());
            AddColumn("dbo.Doctors", "Turn_Id_patient", c => c.Int());
            AddColumn("dbo.Doctors", "Turn_Id_doctor", c => c.Int());
            AddColumn("dbo.Doctors", "Turn_Id_room", c => c.Int());
            AddColumn("dbo.Rooms", "Turn_Id_turn", c => c.Int());
            AddColumn("dbo.Rooms", "Turn_Id_patient", c => c.Int());
            AddColumn("dbo.Rooms", "Turn_Id_doctor", c => c.Int());
            AddColumn("dbo.Rooms", "Turn_Id_room", c => c.Int());
            AlterColumn("dbo.Doctors", "Id_doctor", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Rooms", "Id_room", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Doctors", "Id_doctor");
            AddPrimaryKey("dbo.Rooms", "Id_room");
            CreateIndex("dbo.Doctors", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            CreateIndex("dbo.Rooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            AddForeignKey("dbo.Doctors", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns", new[] { "Id_turn", "Id_patient", "Id_doctor", "Id_room" });
            AddForeignKey("dbo.Rooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns", new[] { "Id_turn", "Id_patient", "Id_doctor", "Id_room" });
            DropColumn("dbo.Doctors", "Id_turn");
            DropColumn("dbo.Rooms", "Id_turn");
            DropTable("dbo.TurnRooms");
            DropTable("dbo.DoctorTurns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DoctorTurns",
                c => new
                    {
                        Doctor_Id_doctor = c.Int(nullable: false),
                        Doctor_Id_turn = c.Int(nullable: false),
                        Turn_Id_turn = c.Int(nullable: false),
                        Turn_Id_patient = c.Int(nullable: false),
                        Turn_Id_doctor = c.Int(nullable: false),
                        Turn_Id_room = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Doctor_Id_doctor, t.Doctor_Id_turn, t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room });
            
            CreateTable(
                "dbo.TurnRooms",
                c => new
                    {
                        Turn_Id_turn = c.Int(nullable: false),
                        Turn_Id_patient = c.Int(nullable: false),
                        Turn_Id_doctor = c.Int(nullable: false),
                        Turn_Id_room = c.Int(nullable: false),
                        Rooms_Id_room = c.Int(nullable: false),
                        Rooms_Id_turn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room, t.Rooms_Id_room, t.Rooms_Id_turn });
            
            AddColumn("dbo.Rooms", "Id_turn", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "Id_turn", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropForeignKey("dbo.Doctors", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropIndex("dbo.Rooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropIndex("dbo.Doctors", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropPrimaryKey("dbo.Rooms");
            DropPrimaryKey("dbo.Doctors");
            AlterColumn("dbo.Rooms", "Id_room", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "Id_doctor", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "Turn_Id_room");
            DropColumn("dbo.Rooms", "Turn_Id_doctor");
            DropColumn("dbo.Rooms", "Turn_Id_patient");
            DropColumn("dbo.Rooms", "Turn_Id_turn");
            DropColumn("dbo.Doctors", "Turn_Id_room");
            DropColumn("dbo.Doctors", "Turn_Id_doctor");
            DropColumn("dbo.Doctors", "Turn_Id_patient");
            DropColumn("dbo.Doctors", "Turn_Id_turn");
            AddPrimaryKey("dbo.Rooms", new[] { "Id_room", "Id_turn" });
            AddPrimaryKey("dbo.Doctors", new[] { "Id_doctor", "Id_turn" });
            CreateIndex("dbo.DoctorTurns", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            CreateIndex("dbo.DoctorTurns", new[] { "Doctor_Id_doctor", "Doctor_Id_turn" });
            CreateIndex("dbo.TurnRooms", new[] { "Rooms_Id_room", "Rooms_Id_turn" });
            CreateIndex("dbo.TurnRooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            AddForeignKey("dbo.DoctorTurns", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns", new[] { "Id_turn", "Id_patient", "Id_doctor", "Id_room" }, cascadeDelete: true);
            AddForeignKey("dbo.DoctorTurns", new[] { "Doctor_Id_doctor", "Doctor_Id_turn" }, "dbo.Doctors", new[] { "Id_doctor", "Id_turn" }, cascadeDelete: true);
            AddForeignKey("dbo.TurnRooms", new[] { "Rooms_Id_room", "Rooms_Id_turn" }, "dbo.Rooms", new[] { "Id_room", "Id_turn" }, cascadeDelete: true);
            AddForeignKey("dbo.TurnRooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns", new[] { "Id_turn", "Id_patient", "Id_doctor", "Id_room" }, cascadeDelete: true);
        }
    }
}
