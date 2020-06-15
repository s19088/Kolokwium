using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium_2.Migrations
{
    public partial class wszystko : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(maxLength: 30, nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    IdMusicLabel = table.Column<int>(nullable: false),
                    AlbumIdAlbum = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albums_Albums_AlbumIdAlbum",
                        column: x => x.AlbumIdAlbum,
                        principalTable: "Albums",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Musician_Tracks",
                columns: table => new
                {
                    IdMusicianTrack = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMusician = table.Column<int>(nullable: false),
                    IdTrack = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Tracks", x => x.IdMusicianTrack);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabels",
                columns: table => new
                {
                    IdMusicLabel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    MusicLabelIdMusicLabel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabels", x => x.IdMusicLabel);
                    table.ForeignKey(
                        name: "FK_MusicLabels_MusicLabels_MusicLabelIdMusicLabel",
                        column: x => x.MusicLabelIdMusicLabel,
                        principalTable: "MusicLabels",
                        principalColumn: "IdMusicLabel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    IdTrack = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(maxLength: 20, nullable: true),
                    Duration = table.Column<float>(nullable: false),
                    IdMusicAlbum = table.Column<int>(nullable: true),
                    TrackIdTrack = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.IdTrack);
                    table.ForeignKey(
                        name: "FK_Tracks_Tracks_TrackIdTrack",
                        column: x => x.TrackIdTrack,
                        principalTable: "Tracks",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_AlbumIdAlbum",
                table: "Albums",
                column: "AlbumIdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLabels_MusicLabelIdMusicLabel",
                table: "MusicLabels",
                column: "MusicLabelIdMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_TrackIdTrack",
                table: "Tracks",
                column: "TrackIdTrack");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Musician_Tracks");

            migrationBuilder.DropTable(
                name: "MusicLabels");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
