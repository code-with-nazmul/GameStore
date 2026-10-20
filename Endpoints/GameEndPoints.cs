using GameStore.API.Dtos;

namespace GameStore.API.Endpoints;

public static class GetGameEndpoints
{
  const string GetGameEndpointName = "GetGame";
  private static List <GameDto> games = [
    new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
    new(2, "Call of duty", "Shooting", 20.13M, new DateOnly(2010, 1, 15)),
    new(3, "NFS", "Speeding", 15.15M, new DateOnly(2010, 5, 17))
  ];

  public static void MapGamesEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("/games");

    // GET /games
    group.MapGet("/", () => games);

    // GET /games/1
    group.MapGet("/{id}", (int id) =>
    {
      var game = games.Find(game => game.Id == id);

      return game is null ? Results.NotFound() : Results.Ok(game);
    }).
      WithName(GetGameEndpointName);

    // POST /games
    group.MapPost("/", (CreateGameDto newGame) =>
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

    // PUT /games/1
    group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
    {
      var index = games.FindIndex(game => game.Id == id);

      if(index == -1)
      {
        return Results.NotFound();
      }

      games[index] = new GameDto(
        index,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
      );

      return Results.NoContent();
    });

    // DELETE /games/1
    group.MapDelete("/{id}", (int id) =>
    {
      games.RemoveAll(game => game.Id == id);

      return Results.NoContent();
    });
  }
}