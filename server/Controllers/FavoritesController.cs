namespace all_state.Controllers;


[ApiController]
[Route("api/favorites")]


public class FavoritesController : ControllerBase
{
  private readonly Auth0Provider _auth;
  private readonly FavoritesService _favoritesService;

  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
  {
    _favoritesService = favoritesService;
    _auth = auth;
  }






}