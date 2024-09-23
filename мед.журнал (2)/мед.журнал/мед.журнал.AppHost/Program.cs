var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.мед_журнал>("мед-журнал");

builder.Build().Run();
