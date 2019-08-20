CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Action" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_Action" PRIMARY KEY ("Id")
);

CREATE TABLE "ActionPhase" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "RoundId" integer NOT NULL,
    CONSTRAINT "PK_ActionPhase" PRIMARY KEY ("Id")
);

CREATE TABLE "Affiliation" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_Affiliation" PRIMARY KEY ("Id")
);

CREATE TABLE "Artist" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_Artist" PRIMARY KEY ("Id")
);

CREATE TABLE "Color" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_Color" PRIMARY KEY ("Id")
);

CREATE TABLE "Deck" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    "Url" character varying(500) NOT NULL,
    CONSTRAINT "PK_Deck" PRIMARY KEY ("Id")
);

CREATE TABLE "DiceAction" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_DiceAction" PRIMARY KEY ("Id")
);

CREATE TABLE "Die" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "CardId" integer NOT NULL,
    CONSTRAINT "PK_Die" PRIMARY KEY ("Id")
);

CREATE TABLE "Faction" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_Faction" PRIMARY KEY ("Id")
);

CREATE TABLE "Legality" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_Legality" PRIMARY KEY ("Id")
);

CREATE TABLE "Player" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_Player" PRIMARY KEY ("Id")
);

CREATE TABLE "Rarity" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_Rarity" PRIMARY KEY ("Id")
);

CREATE TABLE "SetStarWars" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_SetStarWars" PRIMARY KEY ("Id")
);

CREATE TABLE "Type" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    CONSTRAINT "PK_Type" PRIMARY KEY ("Id")
);

CREATE TABLE "Turn" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Number" integer NOT NULL,
    "ActionPhaseId" integer NOT NULL,
    CONSTRAINT "PK_Turn" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Turn_ActionPhase_ActionPhaseId" FOREIGN KEY ("ActionPhaseId") REFERENCES "ActionPhase" ("Id") ON DELETE CASCADE
);

CREATE TABLE "DiceFace" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Value" text NOT NULL,
    "IsModifier" boolean NOT NULL,
    "DiceActionId" integer NOT NULL,
    "Cost" integer NOT NULL,
    "DieId" integer NOT NULL,
    CONSTRAINT "PK_DiceFace" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_DiceFace_DiceAction_DiceActionId" FOREIGN KEY ("DiceActionId") REFERENCES "DiceAction" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_DiceFace_Die_DieId" FOREIGN KEY ("DieId") REFERENCES "Die" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Card" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    "Subtitle" character varying(255) NULL,
    "Text" text NULL,
    "Number" integer NOT NULL,
    "ArtistId" integer NULL,
    "AffiliationId" integer NOT NULL,
    "FactionId" integer NOT NULL,
    "ColorId" integer NOT NULL,
    "RarityId" integer NOT NULL,
    "DieId" integer NULL,
    "SetStarWarsId" integer NOT NULL,
    "Url" character varying(500) NOT NULL,
    "UrlImage" character varying(500) NULL,
    "DataCode" character varying(255) NOT NULL,
    "Points" integer NULL,
    "ElitePoints" integer NULL,
    "Health" integer NULL,
    "Cost" integer NULL,
    "IsCharacter" boolean NOT NULL,
    "IsSuport" boolean NOT NULL,
    "IsUpgrade" boolean NOT NULL,
    "IsUnique" boolean NULL,
    "Flavor" text NULL,
    "Image" text NULL,
    CONSTRAINT "PK_Card" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Card_Affiliation_AffiliationId" FOREIGN KEY ("AffiliationId") REFERENCES "Affiliation" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Card_Artist_ArtistId" FOREIGN KEY ("ArtistId") REFERENCES "Artist" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Card_Color_ColorId" FOREIGN KEY ("ColorId") REFERENCES "Color" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Card_Die_DieId" FOREIGN KEY ("DieId") REFERENCES "Die" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Card_Faction_FactionId" FOREIGN KEY ("FactionId") REFERENCES "Faction" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Card_Rarity_RarityId" FOREIGN KEY ("RarityId") REFERENCES "Rarity" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Card_SetStarWars_SetStarWarsId" FOREIGN KEY ("SetStarWarsId") REFERENCES "SetStarWars" ("Id") ON DELETE CASCADE
);

CREATE TABLE "BattleField" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "GameId" integer NOT NULL,
    "BattlefieldCardId" integer NOT NULL,
    CONSTRAINT "PK_BattleField" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_BattleField_Card_BattlefieldCardId" FOREIGN KEY ("BattlefieldCardId") REFERENCES "Card" ("Id") ON DELETE CASCADE
);

CREATE TABLE "CardDeck" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "CardId" integer NOT NULL,
    "DeckId" integer NOT NULL,
    CONSTRAINT "PK_CardDeck" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_CardDeck_Card_CardId" FOREIGN KEY ("CardId") REFERENCES "Card" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_CardDeck_Deck_DeckId" FOREIGN KEY ("DeckId") REFERENCES "Deck" ("Id") ON DELETE CASCADE
);

CREATE TABLE "CardLegality" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "CardId" integer NOT NULL,
    "LegalityId" integer NOT NULL,
    "IsLegal" boolean NOT NULL,
    CONSTRAINT "PK_CardLegality" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_CardLegality_Card_CardId" FOREIGN KEY ("CardId") REFERENCES "Card" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_CardLegality_Legality_LegalityId" FOREIGN KEY ("LegalityId") REFERENCES "Legality" ("Id") ON DELETE CASCADE
);

CREATE TABLE "CardType" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "CardId" integer NOT NULL,
    "TypeId" integer NOT NULL,
    CONSTRAINT "PK_CardType" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_CardType_Card_CardId" FOREIGN KEY ("CardId") REFERENCES "Card" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_CardType_Type_TypeId" FOREIGN KEY ("TypeId") REFERENCES "Type" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Effect" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    "EnumEffect" integer NOT NULL,
    "CardId" integer NULL,
    CONSTRAINT "PK_Effect" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Effect_Card_CardId" FOREIGN KEY ("CardId") REFERENCES "Card" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "Keyword" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "Name" character varying(255) NOT NULL,
    "Text" text NOT NULL,
    "EnumKeyWords" integer NOT NULL,
    "CardId" integer NULL,
    CONSTRAINT "PK_Keyword" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Keyword_Card_CardId" FOREIGN KEY ("CardId") REFERENCES "Card" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "Game" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "BattleFieldId" integer NOT NULL,
    "SetUpId" integer NOT NULL,
    CONSTRAINT "PK_Game" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Game_BattleField_BattleFieldId" FOREIGN KEY ("BattleFieldId") REFERENCES "BattleField" ("Id") ON DELETE CASCADE
);

CREATE TABLE "BalanceForce" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "CardLegalityId" integer NOT NULL,
    "Points" integer NULL,
    "ElitePoints" integer NULL,
    "Health" integer NULL,
    CONSTRAINT "PK_BalanceForce" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_BalanceForce_CardLegality_CardLegalityId" FOREIGN KEY ("CardLegalityId") REFERENCES "CardLegality" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PlayerGame" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "GameId" integer NOT NULL,
    "PlayerId" integer NOT NULL,
    "DeckId" integer NOT NULL,
    CONSTRAINT "PK_PlayerGame" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerGame_Deck_DeckId" FOREIGN KEY ("DeckId") REFERENCES "Deck" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerGame_Game_GameId" FOREIGN KEY ("GameId") REFERENCES "Game" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerGame_Player_PlayerId" FOREIGN KEY ("PlayerId") REFERENCES "Player" ("Id") ON DELETE CASCADE
);

CREATE TABLE "SetUp" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "GameId" integer NOT NULL,
    "BattlefieldChoosedId" integer NOT NULL,
    CONSTRAINT "PK_SetUp" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SetUp_BattleField_BattlefieldChoosedId" FOREIGN KEY ("BattlefieldChoosedId") REFERENCES "BattleField" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_SetUp_Game_GameId" FOREIGN KEY ("GameId") REFERENCES "Game" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Round" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "UpkeepPhaseId" integer NULL,
    "ActionPhaseId" integer NULL,
    "BattleFieldClaimed" boolean NOT NULL,
    "PlayerGameIdClaimedBattlefield" integer NULL,
    CONSTRAINT "PK_Round" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Round_ActionPhase_ActionPhaseId" FOREIGN KEY ("ActionPhaseId") REFERENCES "ActionPhase" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Round_PlayerGame_PlayerGameIdClaimedBattlefield" FOREIGN KEY ("PlayerGameIdClaimedBattlefield") REFERENCES "PlayerGame" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "PlayerGameCharacterShield" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "SetUpId" integer NOT NULL,
    "PlayerGameId" integer NOT NULL,
    "CharacterCardId" integer NOT NULL,
    "QtyShield" integer NOT NULL,
    CONSTRAINT "PK_PlayerGameCharacterShield" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerGameCharacterShield_Card_CharacterCardId" FOREIGN KEY ("CharacterCardId") REFERENCES "Card" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerGameCharacterShield_PlayerGame_PlayerGameId" FOREIGN KEY ("PlayerGameId") REFERENCES "PlayerGame" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerGameCharacterShield_SetUp_SetUpId" FOREIGN KEY ("SetUpId") REFERENCES "SetUp" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PlayerGameIniciative" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "SetUpId" integer NOT NULL,
    "PlayerGameId" integer NOT NULL,
    "Iniciative" integer NOT NULL,
    CONSTRAINT "PK_PlayerGameIniciative" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerGameIniciative_PlayerGame_PlayerGameId" FOREIGN KEY ("PlayerGameId") REFERENCES "PlayerGame" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerGameIniciative_SetUp_SetUpId" FOREIGN KEY ("SetUpId") REFERENCES "SetUp" ("Id") ON DELETE CASCADE
);

CREATE TABLE "RoundGame" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "RoundId" integer NOT NULL,
    "GameId" integer NOT NULL,
    CONSTRAINT "PK_RoundGame" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_RoundGame_Game_GameId" FOREIGN KEY ("GameId") REFERENCES "Game" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_RoundGame_Round_RoundId" FOREIGN KEY ("RoundId") REFERENCES "Round" ("Id") ON DELETE CASCADE
);

CREATE TABLE "UpkeepPhase" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "RoundId" integer NOT NULL,
    CONSTRAINT "PK_UpkeepPhase" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_UpkeepPhase_Round_RoundId" FOREIGN KEY ("RoundId") REFERENCES "Round" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PlayerRound" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "PlayerGameId" integer NOT NULL,
    "RoundGameId" integer NOT NULL,
    "Resources" integer NOT NULL,
    CONSTRAINT "PK_PlayerRound" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerRound_PlayerGame_PlayerGameId" FOREIGN KEY ("PlayerGameId") REFERENCES "PlayerGame" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerRound_RoundGame_RoundGameId" FOREIGN KEY ("RoundGameId") REFERENCES "RoundGame" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PlayerRoundCardInDiscard" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "PlayerRoundId" integer NOT NULL,
    "CardId" integer NOT NULL,
    CONSTRAINT "PK_PlayerRoundCardInDiscard" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerRoundCardInDiscard_Card_CardId" FOREIGN KEY ("CardId") REFERENCES "Card" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerRoundCardInDiscard_PlayerRound_PlayerRoundId" FOREIGN KEY ("PlayerRoundId") REFERENCES "PlayerRound" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PlayerRoundCardInHand" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "PlayerRoundId" integer NOT NULL,
    "CardId" integer NOT NULL,
    CONSTRAINT "PK_PlayerRoundCardInHand" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerRoundCardInHand_Card_CardId" FOREIGN KEY ("CardId") REFERENCES "Card" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerRoundCardInHand_PlayerRound_PlayerRoundId" FOREIGN KEY ("PlayerRoundId") REFERENCES "PlayerRound" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PlayerRoundCardInLimbo" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "PlayerRoundId" integer NOT NULL,
    "CardId" integer NOT NULL,
    CONSTRAINT "PK_PlayerRoundCardInLimbo" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerRoundCardInLimbo_Card_CardId" FOREIGN KEY ("CardId") REFERENCES "Card" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerRoundCardInLimbo_PlayerRound_PlayerRoundId" FOREIGN KEY ("PlayerRoundId") REFERENCES "PlayerRound" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PlayerRoundCardInPlay" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "PlayerRoundId" integer NOT NULL,
    "CardId" integer NOT NULL,
    "Exausted" boolean NOT NULL,
    CONSTRAINT "PK_PlayerRoundCardInPlay" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerRoundCardInPlay_Card_CardId" FOREIGN KEY ("CardId") REFERENCES "Card" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerRoundCardInPlay_PlayerRound_PlayerRoundId" FOREIGN KEY ("PlayerRoundId") REFERENCES "PlayerRound" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PlayerRoundRolledDice" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "PlayerRoundId" integer NOT NULL,
    "DieId" integer NOT NULL,
    "DiceFaceId" integer NOT NULL,
    CONSTRAINT "PK_PlayerRoundRolledDice" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerRoundRolledDice_DiceFace_DiceFaceId" FOREIGN KEY ("DiceFaceId") REFERENCES "DiceFace" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerRoundRolledDice_Die_DieId" FOREIGN KEY ("DieId") REFERENCES "Die" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlayerRoundRolledDice_PlayerRound_PlayerRoundId" FOREIGN KEY ("PlayerRoundId") REFERENCES "PlayerRound" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PlayerRoundCardInPlayUpgrade" (
    "Id" serial NOT NULL,
    "InsertedIn" datetime NOT NULL,
    "UpdatedIn" datetime NULL,
    "DeletedIn" datetime NULL,
    "PlayerRoundCardInPlayId" integer NOT NULL,
    "Exausted" boolean NOT NULL,
    "CanBeExausted" boolean NOT NULL,
    CONSTRAINT "PK_PlayerRoundCardInPlayUpgrade" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlayerRoundCardInPlayUpgrade_PlayerRoundCardInPlay_PlayerRo~" FOREIGN KEY ("PlayerRoundCardInPlayId") REFERENCES "PlayerRoundCardInPlay" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_BalanceForce_CardLegalityId" ON "BalanceForce" ("CardLegalityId");

CREATE INDEX "IX_BattleField_BattlefieldCardId" ON "BattleField" ("BattlefieldCardId");

CREATE INDEX "IX_Card_AffiliationId" ON "Card" ("AffiliationId");

CREATE INDEX "IX_Card_ArtistId" ON "Card" ("ArtistId");

CREATE INDEX "IX_Card_ColorId" ON "Card" ("ColorId");

CREATE UNIQUE INDEX "IX_Card_DieId" ON "Card" ("DieId");

CREATE INDEX "IX_Card_FactionId" ON "Card" ("FactionId");

CREATE INDEX "IX_Card_RarityId" ON "Card" ("RarityId");

CREATE INDEX "IX_Card_SetStarWarsId" ON "Card" ("SetStarWarsId");

CREATE INDEX "IX_CardDeck_CardId" ON "CardDeck" ("CardId");

CREATE INDEX "IX_CardDeck_DeckId" ON "CardDeck" ("DeckId");

CREATE INDEX "IX_CardLegality_CardId" ON "CardLegality" ("CardId");

CREATE INDEX "IX_CardLegality_LegalityId" ON "CardLegality" ("LegalityId");

CREATE INDEX "IX_CardType_CardId" ON "CardType" ("CardId");

CREATE INDEX "IX_CardType_TypeId" ON "CardType" ("TypeId");

CREATE INDEX "IX_DiceFace_DiceActionId" ON "DiceFace" ("DiceActionId");

CREATE INDEX "IX_DiceFace_DieId" ON "DiceFace" ("DieId");

CREATE INDEX "IX_Effect_CardId" ON "Effect" ("CardId");

CREATE UNIQUE INDEX "IX_Game_BattleFieldId" ON "Game" ("BattleFieldId");

CREATE INDEX "IX_Keyword_CardId" ON "Keyword" ("CardId");

CREATE INDEX "IX_PlayerGame_DeckId" ON "PlayerGame" ("DeckId");

CREATE INDEX "IX_PlayerGame_GameId" ON "PlayerGame" ("GameId");

CREATE INDEX "IX_PlayerGame_PlayerId" ON "PlayerGame" ("PlayerId");

CREATE INDEX "IX_PlayerGameCharacterShield_CharacterCardId" ON "PlayerGameCharacterShield" ("CharacterCardId");

CREATE INDEX "IX_PlayerGameCharacterShield_PlayerGameId" ON "PlayerGameCharacterShield" ("PlayerGameId");

CREATE INDEX "IX_PlayerGameCharacterShield_SetUpId" ON "PlayerGameCharacterShield" ("SetUpId");

CREATE INDEX "IX_PlayerGameIniciative_PlayerGameId" ON "PlayerGameIniciative" ("PlayerGameId");

CREATE INDEX "IX_PlayerGameIniciative_SetUpId" ON "PlayerGameIniciative" ("SetUpId");

CREATE INDEX "IX_PlayerRound_PlayerGameId" ON "PlayerRound" ("PlayerGameId");

CREATE INDEX "IX_PlayerRound_RoundGameId" ON "PlayerRound" ("RoundGameId");

CREATE INDEX "IX_PlayerRoundCardInDiscard_CardId" ON "PlayerRoundCardInDiscard" ("CardId");

CREATE INDEX "IX_PlayerRoundCardInDiscard_PlayerRoundId" ON "PlayerRoundCardInDiscard" ("PlayerRoundId");

CREATE INDEX "IX_PlayerRoundCardInHand_CardId" ON "PlayerRoundCardInHand" ("CardId");

CREATE INDEX "IX_PlayerRoundCardInHand_PlayerRoundId" ON "PlayerRoundCardInHand" ("PlayerRoundId");

CREATE INDEX "IX_PlayerRoundCardInLimbo_CardId" ON "PlayerRoundCardInLimbo" ("CardId");

CREATE INDEX "IX_PlayerRoundCardInLimbo_PlayerRoundId" ON "PlayerRoundCardInLimbo" ("PlayerRoundId");

CREATE INDEX "IX_PlayerRoundCardInPlay_CardId" ON "PlayerRoundCardInPlay" ("CardId");

CREATE INDEX "IX_PlayerRoundCardInPlay_PlayerRoundId" ON "PlayerRoundCardInPlay" ("PlayerRoundId");

CREATE INDEX "IX_PlayerRoundCardInPlayUpgrade_PlayerRoundCardInPlayId" ON "PlayerRoundCardInPlayUpgrade" ("PlayerRoundCardInPlayId");

CREATE INDEX "IX_PlayerRoundRolledDice_DiceFaceId" ON "PlayerRoundRolledDice" ("DiceFaceId");

CREATE INDEX "IX_PlayerRoundRolledDice_DieId" ON "PlayerRoundRolledDice" ("DieId");

CREATE INDEX "IX_PlayerRoundRolledDice_PlayerRoundId" ON "PlayerRoundRolledDice" ("PlayerRoundId");

CREATE UNIQUE INDEX "IX_Round_ActionPhaseId" ON "Round" ("ActionPhaseId");

CREATE INDEX "IX_Round_PlayerGameIdClaimedBattlefield" ON "Round" ("PlayerGameIdClaimedBattlefield");

CREATE INDEX "IX_RoundGame_GameId" ON "RoundGame" ("GameId");

CREATE INDEX "IX_RoundGame_RoundId" ON "RoundGame" ("RoundId");

CREATE INDEX "IX_SetUp_BattlefieldChoosedId" ON "SetUp" ("BattlefieldChoosedId");

CREATE UNIQUE INDEX "IX_SetUp_GameId" ON "SetUp" ("GameId");

CREATE INDEX "IX_Turn_ActionPhaseId" ON "Turn" ("ActionPhaseId");

CREATE UNIQUE INDEX "IX_UpkeepPhase_RoundId" ON "UpkeepPhase" ("RoundId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190820005952_Initial', '2.2.4-servicing-10062');

