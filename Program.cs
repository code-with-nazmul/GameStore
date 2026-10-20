using GameStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List <GameDto> games = [
  new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
  new(2, "Call of duty", "Shooting", 20.13M, new DateOnly(2010, 1, 15)),
  new(3, "NFS", "Speeding", 15.15M, new DateOnly(2010, 5, 17))
];

app.Run();
