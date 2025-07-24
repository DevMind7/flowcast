// Cr�ation du builder pour l'application distribu�e avec les arguments d'ex�cution
var builder = DistributedApplication.CreateBuilder(args);

// Ajout et configuration d'un cache Redis nomm� "cache"
var cache = builder.AddRedis("cache");


// Ajout et configuration d'un serveur PostgreSQL nomm� "postgres"
// Avec interface PgAdmin, volume de donn�es persistant et base de donn�es "flowcastDb"
var postgresServer = builder.AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume()
    .AddDatabase("flowcastDb");


// Ajout du projet API Service "flowcast_ApiService"
// Configuration d'un endpoint de health check HTTP sur /health
// D�clare une d�pendance et attend la disponibilit� du serveur PostgreSQL
var apiService = builder.AddProject<Projects.flowcast_ApiService>("apiservice")
    .WithHttpHealthCheck("/health")
    .WithReference(postgresServer)
    .WaitFor(postgresServer);

// Ajout du projet frontend web "flowcast_Web"
// Exposition d'endpoints HTTP externes
// Configuration d'un endpoint de health check HTTP sur /health
// D�clare des d�pendances sur le cache Redis et le service API et attend leur disponibilit�
builder.AddProject<Projects.flowcast_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
