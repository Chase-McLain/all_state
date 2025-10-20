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


  [HttpPost]
  [Authorize]
  public async Task<ActionResult<FavoriteRecpie>> CreateFavorite([FromBody] Favorite favoriteData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      favoriteData.AccountId = userInfo.Id;
      FavoriteRecpie favorite = _favoritesService.CreateFavorite(favoriteData);
      return favorite;
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


}