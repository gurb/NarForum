using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Api>("api");

var narForumUser = builder.AddProject<Projects.NarForumUser>("narforumuser")
                                .WithReference(api);

builder.Build().Run();
