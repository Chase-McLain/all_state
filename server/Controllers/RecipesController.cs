namespace all_state.Controllers;


[ApiController]
[Route("api/recipes")]


public class RecipesController(RecipesService recipesService, Auth0Provider auth) : ControllerBase
{

  private readonly RecipesService _recipesService = recipesService;
  private readonly Auth0Provider _auth = auth;



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


  [HttpPost]
  async public Task<ActionResult<Recipe>> createRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.createRecipe(recipeData);
      return recipe;
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }




}