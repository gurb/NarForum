var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("pg-username", secret: true);
var password = builder.AddParameter("pg-password", secret: true);
var postgres = builder.AddPostgres("postgres", username, password)
    .WithDataVolume()
    .WithPgAdmin();
var forumIdentityDb = postgres.AddDatabase("forumidentitydb");
var forumDb = postgres.AddDatabase("forumdb");

var garnet = builder.AddGarnet("garnet", port: 6379)
    .WithDataVolume();

var api = builder.AddProject<Projects.Api>("api")
    .WaitFor(postgres)
    .WaitFor(forumDb)
    .WaitFor(forumIdentityDb)
    .WaitFor(garnet)
    .WithEnvironment("ConnectionStrings__DockerForumDatabaseConnectionString", $"{forumDb.Resource}")
    .WithEnvironment("ConnectionStrings__DockerForumIdentityDatabaseConnectionString", $"{forumIdentityDb.Resource}");

var narForumUser = builder.AddProject<Projects.NarForumUser>("narforumuser")
                                .WithExternalHttpEndpoints()
                                .WithReference(api)
                                .WaitFor(api);

builder.Build().Run();
