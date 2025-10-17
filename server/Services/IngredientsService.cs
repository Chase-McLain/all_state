namespace all_state.Services;


public class IngredientsService
{
  private readonly IngredientsRepository _ingredientsRepository;
  private readonly RecipesService _recipesService;


  public IngredientsService(IngredientsRepository ingredientsRepository, RecipesService recipesService)
  {
    _ingredientsRepository = ingredientsRepository;
    _recipesService = recipesService;
  }

  public Ingredient CreateIngredient(Ingredient ingredientData, string userId)
  {
    Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);
    if (recipe.CreatorId != userId)
    {
      throw new Exception("No add ingredients to the recipes of others.");
    }
    Ingredient ingredient = _ingredientsRepository.CreateIngredient(ingredientData);
    return ingredient;
  }
}