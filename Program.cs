using GameStore.API.Dtos;

const string GetGameEndpointName = "GetGame";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List <GameDto> games = [
  new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
  new(2, "Call of duty", "Shooting", 20.13M, new DateOnly(2010, 1, 15)),
  new(3, "NFS", "Speeding", 15.15M, new DateOnly(2010, 5, 17))
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/1
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).
  WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
  GameDto game = new(
    games.Count + 1,
    newGame.Name,
    newGame.Genre,
    newGame.Price,
    newGame.ReleaseDate
  );

  games.Add(game);
  
  return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
}); 


app.Run();
