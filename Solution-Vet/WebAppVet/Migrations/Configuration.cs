namespace WebAppVet.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppVet.Data.ClinicaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAppVet.Data.ClinicaDbContext context)
        {
          /*  context.Client.AddOrUpdate(x => x.Id_client,
        new Client() { Id_client = 1, FullName = "Jane Austen", Email = "eeww@aa" },
        new Client() { Id_client = 2, FullName = "Charles Dickens", Email = "aaww@aa" },
        new Client() { Id_client = 3, FullName = "Miguel de Cervantes", Email = "ddww@aa" }
        );

            context.Patient.AddOrUpdate(x => x.Id_patient,
     new Patient() { Id_patient = 1 , Id_client = 1, Name = "Hercules"},
     new Patient() { Id_patient = 2, Id_client = 2, Name = "Macho" },
     new Patient() { Id_patient = 3, Id_client = 3, Name = "Rafa" }
     );

           context.Doctor.AddOrUpdate(x => x.Id_doctor,
     new Doctor() { Id_doctor = 1, name = "Carlos", specialization = "vaccination" },
     new Doctor() { Id_doctor = 2, name = "Alberto", specialization = "vaccination" },
     new Doctor() { Id_doctor = 3, name = "Julia", specialization = "castration" }
     );
            context.Rooms.AddOrUpdate(x => x.Id_room,
  new Rooms() { Id_room = 1, Name = "2", Location = "PA" },
  new Rooms() { Id_room = 2, Name = "112", Location = "PA" },
  new Rooms() { Id_room = 3, Name = "34", Location = "PB" }
  );
            context.Turn.AddOrUpdate(x => x.Id_turn,
new Turn() { Id_turn = 1, Id_doctor = 1, Id_patient = 1, Id_room = 1, servicio = 1},
new Turn() { Id_turn = 2, Id_doctor = 1, Id_patient = 2, Id_room = 2, servicio = 1 },
new Turn() { Id_turn = 3, Id_doctor = 3, Id_patient = 3, Id_room = 3, servicio = 2 }
);
*/
        }
}
}

