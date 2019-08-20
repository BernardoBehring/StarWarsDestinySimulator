using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StarWarsDestiny.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionPhase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    RoundId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPhase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Affiliation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Url = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiceAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiceAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Die",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Die", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Legality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rarity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetStarWars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetStarWars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Number = table.Column<int>(nullable: false),
                    ActionPhaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turn_ActionPhase_ActionPhaseId",
                        column: x => x.ActionPhaseId,
                        principalTable: "ActionPhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiceFace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<string>(nullable: false),
                    IsModifier = table.Column<bool>(nullable: false),
                    DiceActionId = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    DieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiceFace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiceFace_DiceAction_DiceActionId",
                        column: x => x.DiceActionId,
                        principalTable: "DiceAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiceFace_Die_DieId",
                        column: x => x.DieId,
                        principalTable: "Die",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Subtitle = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Text = table.Column<string>(unicode: false, nullable: true),
                    Number = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: true),
                    AffiliationId = table.Column<int>(nullable: false),
                    FactionId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    RarityId = table.Column<int>(nullable: false),
                    DieId = table.Column<int>(nullable: true),
                    SetStarWarsId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    UrlImage = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    DataCode = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Points = table.Column<int>(nullable: true),
                    ElitePoints = table.Column<int>(nullable: true),
                    Health = table.Column<int>(nullable: true),
                    Cost = table.Column<int>(nullable: true),
                    IsCharacter = table.Column<bool>(nullable: false),
                    IsSuport = table.Column<bool>(nullable: false),
                    IsUpgrade = table.Column<bool>(nullable: false),
                    IsUnique = table.Column<bool>(nullable: true),
                    Flavor = table.Column<string>(unicode: false, nullable: true),
                    Image = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Affiliation_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "Affiliation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_Die_DieId",
                        column: x => x.DieId,
                        principalTable: "Die",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_Faction_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Faction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_Rarity_RarityId",
                        column: x => x.RarityId,
                        principalTable: "Rarity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_SetStarWars_SetStarWarsId",
                        column: x => x.SetStarWarsId,
                        principalTable: "SetStarWars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    BattlefieldCardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleField_Card_BattlefieldCardId",
                        column: x => x.BattlefieldCardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardDeck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CardId = table.Column<int>(nullable: false),
                    DeckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDeck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardDeck_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardDeck_Deck_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Deck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardLegality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CardId = table.Column<int>(nullable: false),
                    LegalityId = table.Column<int>(nullable: false),
                    IsLegal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardLegality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardLegality_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardLegality_Legality_LegalityId",
                        column: x => x.LegalityId,
                        principalTable: "Legality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CardId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardType_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardType_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Effect",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    EnumEffect = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effect_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Keyword",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Text = table.Column<string>(unicode: false, nullable: false),
                    EnumKeyWords = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keyword_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    BattleFieldId = table.Column<int>(nullable: false),
                    SetUpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_BattleField_BattleFieldId",
                        column: x => x.BattleFieldId,
                        principalTable: "BattleField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BalanceForce",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CardLegalityId = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: true),
                    ElitePoints = table.Column<int>(nullable: true),
                    Health = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceForce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceForce_CardLegality_CardLegalityId",
                        column: x => x.CardLegalityId,
                        principalTable: "CardLegality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    DeckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Deck_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Deck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SetUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    BattlefieldChoosedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetUp_BattleField_BattlefieldChoosedId",
                        column: x => x.BattlefieldChoosedId,
                        principalTable: "BattleField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetUp_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpkeepPhaseId = table.Column<int>(nullable: true),
                    ActionPhaseId = table.Column<int>(nullable: true),
                    BattleFieldClaimed = table.Column<bool>(nullable: false),
                    PlayerGameIdClaimedBattlefield = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_ActionPhase_ActionPhaseId",
                        column: x => x.ActionPhaseId,
                        principalTable: "ActionPhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Round_PlayerGame_PlayerGameIdClaimedBattlefield",
                        column: x => x.PlayerGameIdClaimedBattlefield,
                        principalTable: "PlayerGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameCharacterShield",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    SetUpId = table.Column<int>(nullable: false),
                    PlayerGameId = table.Column<int>(nullable: false),
                    CharacterCardId = table.Column<int>(nullable: false),
                    QtyShield = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameCharacterShield", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGameCharacterShield_Card_CharacterCardId",
                        column: x => x.CharacterCardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameCharacterShield_PlayerGame_PlayerGameId",
                        column: x => x.PlayerGameId,
                        principalTable: "PlayerGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameCharacterShield_SetUp_SetUpId",
                        column: x => x.SetUpId,
                        principalTable: "SetUp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameIniciative",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    SetUpId = table.Column<int>(nullable: false),
                    PlayerGameId = table.Column<int>(nullable: false),
                    Iniciative = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameIniciative", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGameIniciative_PlayerGame_PlayerGameId",
                        column: x => x.PlayerGameId,
                        principalTable: "PlayerGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameIniciative_SetUp_SetUpId",
                        column: x => x.SetUpId,
                        principalTable: "SetUp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    RoundId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundGame_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpkeepPhase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    RoundId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpkeepPhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpkeepPhase_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRound",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlayerGameId = table.Column<int>(nullable: false),
                    RoundGameId = table.Column<int>(nullable: false),
                    Resources = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerRound_PlayerGame_PlayerGameId",
                        column: x => x.PlayerGameId,
                        principalTable: "PlayerGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRound_RoundGame_RoundGameId",
                        column: x => x.RoundGameId,
                        principalTable: "RoundGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRoundCardInDiscard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlayerRoundId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoundCardInDiscard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerRoundCardInDiscard_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRoundCardInDiscard_PlayerRound_PlayerRoundId",
                        column: x => x.PlayerRoundId,
                        principalTable: "PlayerRound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRoundCardInHand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlayerRoundId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoundCardInHand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerRoundCardInHand_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRoundCardInHand_PlayerRound_PlayerRoundId",
                        column: x => x.PlayerRoundId,
                        principalTable: "PlayerRound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRoundCardInLimbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlayerRoundId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoundCardInLimbo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerRoundCardInLimbo_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRoundCardInLimbo_PlayerRound_PlayerRoundId",
                        column: x => x.PlayerRoundId,
                        principalTable: "PlayerRound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRoundCardInPlay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlayerRoundId = table.Column<int>(nullable: false),
                    CardId = table.Column<int>(nullable: false),
                    Exausted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoundCardInPlay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerRoundCardInPlay_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRoundCardInPlay_PlayerRound_PlayerRoundId",
                        column: x => x.PlayerRoundId,
                        principalTable: "PlayerRound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRoundRolledDice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlayerRoundId = table.Column<int>(nullable: false),
                    DieId = table.Column<int>(nullable: false),
                    DiceFaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoundRolledDice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerRoundRolledDice_DiceFace_DiceFaceId",
                        column: x => x.DiceFaceId,
                        principalTable: "DiceFace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRoundRolledDice_Die_DieId",
                        column: x => x.DieId,
                        principalTable: "Die",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRoundRolledDice_PlayerRound_PlayerRoundId",
                        column: x => x.PlayerRoundId,
                        principalTable: "PlayerRound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRoundCardInPlayUpgrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InsertedIn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlayerRoundCardInPlayId = table.Column<int>(nullable: false),
                    Exausted = table.Column<bool>(nullable: false),
                    CanBeExausted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoundCardInPlayUpgrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerRoundCardInPlayUpgrade_PlayerRoundCardInPlay_PlayerRo~",
                        column: x => x.PlayerRoundCardInPlayId,
                        principalTable: "PlayerRoundCardInPlay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BalanceForce_CardLegalityId",
                table: "BalanceForce",
                column: "CardLegalityId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleField_BattlefieldCardId",
                table: "BattleField",
                column: "BattlefieldCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_AffiliationId",
                table: "Card",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_ArtistId",
                table: "Card",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_ColorId",
                table: "Card",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_DieId",
                table: "Card",
                column: "DieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_FactionId",
                table: "Card",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_RarityId",
                table: "Card",
                column: "RarityId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_SetStarWarsId",
                table: "Card",
                column: "SetStarWarsId");

            migrationBuilder.CreateIndex(
                name: "IX_CardDeck_CardId",
                table: "CardDeck",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardDeck_DeckId",
                table: "CardDeck",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_CardLegality_CardId",
                table: "CardLegality",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardLegality_LegalityId",
                table: "CardLegality",
                column: "LegalityId");

            migrationBuilder.CreateIndex(
                name: "IX_CardType_CardId",
                table: "CardType",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardType_TypeId",
                table: "CardType",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiceFace_DiceActionId",
                table: "DiceFace",
                column: "DiceActionId");

            migrationBuilder.CreateIndex(
                name: "IX_DiceFace_DieId",
                table: "DiceFace",
                column: "DieId");

            migrationBuilder.CreateIndex(
                name: "IX_Effect_CardId",
                table: "Effect",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_BattleFieldId",
                table: "Game",
                column: "BattleFieldId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keyword_CardId",
                table: "Keyword",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_DeckId",
                table: "PlayerGame",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_GameId",
                table: "PlayerGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_PlayerId",
                table: "PlayerGame",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameCharacterShield_CharacterCardId",
                table: "PlayerGameCharacterShield",
                column: "CharacterCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameCharacterShield_PlayerGameId",
                table: "PlayerGameCharacterShield",
                column: "PlayerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameCharacterShield_SetUpId",
                table: "PlayerGameCharacterShield",
                column: "SetUpId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameIniciative_PlayerGameId",
                table: "PlayerGameIniciative",
                column: "PlayerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameIniciative_SetUpId",
                table: "PlayerGameIniciative",
                column: "SetUpId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRound_PlayerGameId",
                table: "PlayerRound",
                column: "PlayerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRound_RoundGameId",
                table: "PlayerRound",
                column: "RoundGameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundCardInDiscard_CardId",
                table: "PlayerRoundCardInDiscard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundCardInDiscard_PlayerRoundId",
                table: "PlayerRoundCardInDiscard",
                column: "PlayerRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundCardInHand_CardId",
                table: "PlayerRoundCardInHand",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundCardInHand_PlayerRoundId",
                table: "PlayerRoundCardInHand",
                column: "PlayerRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundCardInLimbo_CardId",
                table: "PlayerRoundCardInLimbo",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundCardInLimbo_PlayerRoundId",
                table: "PlayerRoundCardInLimbo",
                column: "PlayerRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundCardInPlay_CardId",
                table: "PlayerRoundCardInPlay",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundCardInPlay_PlayerRoundId",
                table: "PlayerRoundCardInPlay",
                column: "PlayerRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundCardInPlayUpgrade_PlayerRoundCardInPlayId",
                table: "PlayerRoundCardInPlayUpgrade",
                column: "PlayerRoundCardInPlayId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundRolledDice_DiceFaceId",
                table: "PlayerRoundRolledDice",
                column: "DiceFaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundRolledDice_DieId",
                table: "PlayerRoundRolledDice",
                column: "DieId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundRolledDice_PlayerRoundId",
                table: "PlayerRoundRolledDice",
                column: "PlayerRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_ActionPhaseId",
                table: "Round",
                column: "ActionPhaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Round_PlayerGameIdClaimedBattlefield",
                table: "Round",
                column: "PlayerGameIdClaimedBattlefield");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGame_GameId",
                table: "RoundGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundGame_RoundId",
                table: "RoundGame",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_SetUp_BattlefieldChoosedId",
                table: "SetUp",
                column: "BattlefieldChoosedId");

            migrationBuilder.CreateIndex(
                name: "IX_SetUp_GameId",
                table: "SetUp",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turn_ActionPhaseId",
                table: "Turn",
                column: "ActionPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UpkeepPhase_RoundId",
                table: "UpkeepPhase",
                column: "RoundId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "BalanceForce");

            migrationBuilder.DropTable(
                name: "CardDeck");

            migrationBuilder.DropTable(
                name: "CardType");

            migrationBuilder.DropTable(
                name: "Effect");

            migrationBuilder.DropTable(
                name: "Keyword");

            migrationBuilder.DropTable(
                name: "PlayerGameCharacterShield");

            migrationBuilder.DropTable(
                name: "PlayerGameIniciative");

            migrationBuilder.DropTable(
                name: "PlayerRoundCardInDiscard");

            migrationBuilder.DropTable(
                name: "PlayerRoundCardInHand");

            migrationBuilder.DropTable(
                name: "PlayerRoundCardInLimbo");

            migrationBuilder.DropTable(
                name: "PlayerRoundCardInPlayUpgrade");

            migrationBuilder.DropTable(
                name: "PlayerRoundRolledDice");

            migrationBuilder.DropTable(
                name: "Turn");

            migrationBuilder.DropTable(
                name: "UpkeepPhase");

            migrationBuilder.DropTable(
                name: "CardLegality");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "SetUp");

            migrationBuilder.DropTable(
                name: "PlayerRoundCardInPlay");

            migrationBuilder.DropTable(
                name: "DiceFace");

            migrationBuilder.DropTable(
                name: "Legality");

            migrationBuilder.DropTable(
                name: "PlayerRound");

            migrationBuilder.DropTable(
                name: "DiceAction");

            migrationBuilder.DropTable(
                name: "RoundGame");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "ActionPhase");

            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "BattleField");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Affiliation");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Die");

            migrationBuilder.DropTable(
                name: "Faction");

            migrationBuilder.DropTable(
                name: "Rarity");

            migrationBuilder.DropTable(
                name: "SetStarWars");
        }
    }
}
