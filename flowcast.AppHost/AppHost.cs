// Création du builder pour l'application distribuée avec les arguments d'exécution
var builder = DistributedApplication.CreateBuilder(args);

// Ajout et configuration d'un cache Redis nommé "cache"
var cache = builder.AddRedis("cache");


// Ajout et configuration d'un serveur PostgreSQL nommé "postgres"
// Avec interface PgAdmin, volume de données persistant et base de données "flowcastDb"
var postgresServer = builder.AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume()
    .AddDatabase("flowcastDb");


// Ajout du projet API Service "flowcast_ApiService"
// Configuration d'un endpoint de health check HTTP sur /health
// Déclare une dépendance et attend la disponibilité du serveur PostgreSQL
var apiService = builder.AddProject<Projects.flowcast_ApiService>("apiservice")
    .WithHttpHealthCheck("/health")
    .WithReference(postgresServer)
    .WaitFor(postgresServer);

// Ajout du projet frontend web "flowcast_Web"
// Exposition d'endpoints HTTP externes
// Configuration d'un endpoint de health check HTTP sur /health
// Déclare des dépendances sur le cache Redis et le service API et attend leur disponibilité
builder.AddProject<Projects.flowcast_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
