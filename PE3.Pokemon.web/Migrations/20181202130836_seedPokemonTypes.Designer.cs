﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PE3.Pokemon.web.Data;

namespace PE3.Pokemon.web.Migrations
{
    [DbContext(typeof(PokemonContext))]
    [Migration("20181202130836_seedPokemonTypes")]
    partial class seedPokemonTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PE3.Pokemon.web.Entities.MyPokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("HasAllolanForm");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");

                    b.HasData(
                        new { Id = new Guid("00000000-0000-0000-0000-000000000001"), Description = "It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely calm and very difficult to capture in the wild. ", HasAllolanForm = false, ImgUrl = "Bulbasaur.png", Location = "Starter", Name = "Bulbasaur" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000002"), Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind leg", HasAllolanForm = false, ImgUrl = "Ivysaur.png", Location = "Evolve Bulbasaur", Name = "Ivysaur" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000003"), Description = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.", HasAllolanForm = false, ImgUrl = "Venusaur.png", Location = "Evolve Ivysaur", Name = "Venusaur" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000004"), Description = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.", HasAllolanForm = false, ImgUrl = "Charmander.png", Location = "Starter", Name = "Charmander" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000005"), Description = "When it swings its burning tail, it elevates the temperature to unbearably high levels.", HasAllolanForm = false, ImgUrl = "Charmeleon.png", Location = "Evolve Charmander", Name = "Charmeleon" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000006"), Description = "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally.", HasAllolanForm = false, ImgUrl = "Charizard.png", Location = "Evolve Charmeleon", Name = "Charizard" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000007"), Description = "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.", HasAllolanForm = false, ImgUrl = "Squirtle.png", Location = "Starter", Name = "Squirtle" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000008"), Description = "Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance", HasAllolanForm = false, ImgUrl = "Wartortle.png", Location = "Evolve Squirtle", Name = "Wartortle" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000009"), Description = "A brutal Pokémon with pressurized water jets on its shell. They are used for high speed tackles.", HasAllolanForm = false, ImgUrl = "Blastoise.png", Location = "evolve Wartortle", Name = "Blastoise" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000010"), Description = "Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.", HasAllolanForm = false, ImgUrl = "Caterpie.png", Location = "Routes 2, 24 and 25,Viridian Forest", Name = "Caterpie" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000011"), Description = "This Pokémon is vulnerable to attack while its shell is soft, exposing its weak and tender body", HasAllolanForm = false, ImgUrl = "Metapod.png", Location = "Routes 24 and 25, Viridian Forest or evolve Caterpie", Name = "Metapod" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000012"), Description = "In battle, it flaps its wings at high speed to release highly toxic dust into the air.", HasAllolanForm = false, ImgUrl = "Butterfree.png", Location = "Evolve Metapod", Name = "Butterfree" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000013"), Description = "Often found in forests, eating leaves. It has a sharp venomous stinger on its head.", HasAllolanForm = false, ImgUrl = "Weedle.png", Location = "Routes 2, 24, and 25, Viridian Forest", Name = "Weedle" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000014"), Description = "Almost incapable of moving, this Pokémon can only harden its shell to protect itself from predators.", HasAllolanForm = false, ImgUrl = "Kakuna.png", Location = "Routes 24 and 25, Viridian Forest", Name = "Kakuna" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000015"), Description = "Flies at high speed and attacks using its large venomous stingers on its forelegs and tail.", HasAllolanForm = false, ImgUrl = "Beedrill.png", Location = "Evolve Kakuna", Name = "Beedrill" }
                    );
                });

            modelBuilder.Entity("PE3.Pokemon.web.Entities.PokemonType", b =>
                {
                    b.Property<Guid>("PokemonId");

                    b.Property<Guid>("TypeId");

                    b.HasKey("PokemonId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("PokemonTypes");

                    b.HasData(
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000001"), TypeId = new Guid("00000000-0000-0000-0000-00000000000c") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000002"), TypeId = new Guid("00000000-0000-0000-0000-00000000000c") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000003"), TypeId = new Guid("00000000-0000-0000-0000-00000000000c") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000004"), TypeId = new Guid("00000000-0000-0000-0000-00000000000a") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000005"), TypeId = new Guid("00000000-0000-0000-0000-00000000000a") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000006"), TypeId = new Guid("00000000-0000-0000-0000-00000000000a") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000007"), TypeId = new Guid("00000000-0000-0000-0000-00000000000b") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000008"), TypeId = new Guid("00000000-0000-0000-0000-00000000000b") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000009"), TypeId = new Guid("00000000-0000-0000-0000-00000000000b") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000010"), TypeId = new Guid("00000000-0000-0000-0000-000000000007") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000011"), TypeId = new Guid("00000000-0000-0000-0000-000000000007") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000012"), TypeId = new Guid("00000000-0000-0000-0000-000000000007") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000013"), TypeId = new Guid("00000000-0000-0000-0000-000000000007") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000014"), TypeId = new Guid("00000000-0000-0000-0000-000000000007") },
                        new { PokemonId = new Guid("00000000-0000-0000-0000-000000000015"), TypeId = new Guid("00000000-0000-0000-0000-000000000007") }
                    );
                });

            modelBuilder.Entity("PE3.Pokemon.web.Entities.PokemonUser", b =>
                {
                    b.Property<Guid>("PokemonId");

                    b.Property<Guid>("UserId");

                    b.Property<byte>("Catches");

                    b.Property<Guid?>("MyPokemonId");

                    b.HasKey("PokemonId", "UserId");

                    b.HasIndex("MyPokemonId");

                    b.HasIndex("UserId");

                    b.ToTable("PokemonUsers");
                });

            modelBuilder.Entity("PE3.Pokemon.web.Entities.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Normal" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Fighting" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Flying" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000004"), Name = "Poison" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000005"), Name = "Ground" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000006"), Name = "Rock" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000007"), Name = "Bug" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000008"), Name = "Ghost" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000009"), Name = "Steel" },
                        new { Id = new Guid("00000000-0000-0000-0000-00000000000a"), Name = "Fire" },
                        new { Id = new Guid("00000000-0000-0000-0000-00000000000b"), Name = "Water" },
                        new { Id = new Guid("00000000-0000-0000-0000-00000000000c"), Name = "Grass" },
                        new { Id = new Guid("00000000-0000-0000-0000-00000000000d"), Name = "Electric" },
                        new { Id = new Guid("00000000-0000-0000-0000-00000000000e"), Name = "Psychic" },
                        new { Id = new Guid("00000000-0000-0000-0000-00000000000f"), Name = "Ice" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000010"), Name = "Dragon" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000011"), Name = "Dark" },
                        new { Id = new Guid("00000000-0000-0000-0000-000000000012"), Name = "Fairy" }
                    );
                });

            modelBuilder.Entity("PE3.Pokemon.web.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = new Guid("10000000-0000-0000-0000-000000000000"), FirstName = "ad", LastName = "min", Password = "pokemon1234", Username = "admin" }
                    );
                });

            modelBuilder.Entity("PE3.Pokemon.web.Entities.PokemonType", b =>
                {
                    b.HasOne("PE3.Pokemon.web.Entities.MyPokemon", "Pokemon")
                        .WithMany("PokemonTypes")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PE3.Pokemon.web.Entities.Type", "Type")
                        .WithMany("PokemonTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PE3.Pokemon.web.Entities.PokemonUser", b =>
                {
                    b.HasOne("PE3.Pokemon.web.Entities.MyPokemon")
                        .WithMany("PokemonUsers")
                        .HasForeignKey("MyPokemonId");

                    b.HasOne("PE3.Pokemon.web.Entities.User")
                        .WithMany("PokemonUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
