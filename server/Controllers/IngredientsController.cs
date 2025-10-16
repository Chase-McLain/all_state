namespace all_state.Controllers;


[ApiController]
[Route("api/[controller]")]


public class IngredientsController
{

  private readonly IngredientsService _ingredientsService;
  private readonly Auth0Provider _auth;

  public IngredientsController(Auth0Provider auth)
  {
    _auth = auth;
  }

  public IngredientsController(IngredientsService ingredientsService)
  {
    _ingredientsService = ingredientsService;
  }






}