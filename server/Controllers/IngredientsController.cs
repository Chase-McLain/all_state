namespace all_state.Controllers;


[ApiController]
[Route("api/ingredients")]


public class IngredientsController : ControllerBase
{
  private readonly IngredientsService _ingredientsService;
  private readonly Auth0Provider _auth;


  public IngredientsController(Auth0Provider auth, IngredientsService ingredientsService)
  {
    _ingredientsService = ingredientsService;
    _auth = auth;
  }


  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData, userInfo.Id);
      return ingredient;
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }





}