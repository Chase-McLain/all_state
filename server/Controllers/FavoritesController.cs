namespace all_state.Controllers;




[ApiController]
[Route("api/[controller]")]

public class FavoritesController : ControllerBase
{

  private readonly Auth0Provider _auth;

  public FavoritesController(Auth0Provider auth)
  {
    _auth = auth;
  }




}