namespace all_state.Controllers;


[ApiController]
[Route("api/[controller]")]


public class RecipesController : ControllerBase
{

  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth;

  public RecipesController(Auth0Provider auth)
  {
    _auth = auth;
  }

  public RecipesController(RecipesService recipesService)
  {
    _recipesService = recipesService;

  }



  // [HttpGet]
  // public List<Recipe> GetRecipes()
  // {
  //   try
  //   {
  //     List<Recipe> recipes = 
  //     return recipes;
  //   }
  //   catch (Exception exception)
  //   {
  //     BadRequest(exception);
  //   }
  // }







}