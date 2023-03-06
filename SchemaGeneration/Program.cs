// See https://aka.ms/new-console-template for more information

/*
using FinolDigital.Cgs.CardGameDef;
using Json.Schema;
using Json.Schema.Generation;
using System.Text.Json;
using System.Text.Json.Serialization;

var jsonSchema = new JsonSchemaBuilder().FromType<CardGame>().Build();
string jsonSchemaString = JsonSerializer.Serialize(jsonSchema, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles });
File.WriteAllText(SchemaFilePath, jsonSchemaString);*/

using FinolDigital.Cgs.CardGameDef;
using NJsonSchema;
using NJsonSchema.Generation;

string SchemaFilePath = "CardGameDef.json";
string SchemaVersion = "https://json-schema.org/draft/2019-09/schema";
string SchemaId = "https://cardgamesim.finoldigital.com/schema/CardGameDef.json";
string SchemaTitle = "CGS Custom Card Game";
string SchemaDescription = "Card Game Simulator (CGS) custom card game specification";

var settings = new JsonSchemaGeneratorSettings
{
    DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull,
    SerializerSettings = CardGame.SerializerSettings
};
var jsonSchema = JsonSchema.FromType<CardGame>(settings);
jsonSchema.SchemaVersion = SchemaVersion; // this unfortunately doesn't work, and manual edits are required to change from v4 to v2019
jsonSchema.Id = SchemaId;
jsonSchema.Title = SchemaTitle;
jsonSchema.Description = SchemaDescription;
// HACK: cardImageUrl uses a custom implementation of uri-template to allow for more versatility
jsonSchema.Properties["cardImageUrl"].Format = "uri-template";
File.WriteAllText(SchemaFilePath, jsonSchema.ToJson());
