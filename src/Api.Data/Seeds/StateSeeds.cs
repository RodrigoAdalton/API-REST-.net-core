using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class StateSeeds
    {
        public static void States(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateEntity>().HasData(
                new StateEntity()
                {
                    Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                    Initial = "AC",
                    Name = "Acre",
                    CreatedAt = DateTime.UtcNow
                },
                new StateEntity()
                {
                    Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                    Initial = "AL",
                    Name = "Alagoas",
                    CreatedAt = DateTime.UtcNow
                },
                new StateEntity()
                {
                    Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                    Initial = "AM",
                    Name = "Amazonas",
                    CreatedAt = DateTime.UtcNow
                },
                 new StateEntity()
                 {
                     Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                     Initial = "AP",
                     Name = "Amapá",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                     Initial = "BA",
                     Name = "Bahia",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                     Initial = "CE",
                     Name = "Ceará",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                     Initial = "DF",
                     Name = "Distrito Federal",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                     Initial = "ES",
                     Name = "Espírito Santo",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                     Initial = "GO",
                     Name = "Goiás",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                     Initial = "MA",
                     Name = "Maranhão",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                     Initial = "MG",
                     Name = "Minas Gerais",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                     Initial = "MS",
                     Name = "Mato Grosso do Sul",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                     Initial = "MT",
                     Name = "Mato Grosso",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                     Initial = "PA",
                     Name = "Pará",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                     Initial = "PB",
                     Name = "Paraíba",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                     Initial = "PE",
                     Name = "Pernambuco",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                     Initial = "PI",
                     Name = "Piauí",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                     Initial = "PR",
                     Name = "Paraná",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                     Initial = "RJ",
                     Name = "Rio de Janeiro",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                     Initial = "RN",
                     Name = "Rio Grande do Norte",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                     Initial = "RO",
                     Name = "Rondônia",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                     Initial = "RR",
                     Name = "Roraima",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                     Initial = "RS",
                     Name = "Rio Grande do Sul",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                     Initial = "SC",
                     Name = "Santa Catarina",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                     Initial = "SE",
                     Name = "Sergipe",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                     Initial = "SP",
                     Name = "São Paulo",
                     CreatedAt = DateTime.UtcNow
                 },
                 new StateEntity()
                 {
                     Id = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                     Initial = "TO",
                     Name = "Tocantins",
                     CreatedAt = DateTime.UtcNow
                 }
            );
        }
    }
}
