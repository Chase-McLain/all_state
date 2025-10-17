
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


  public List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
    return ingredients;
  }


  private Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient ingredient = _ingredientsRepository.GetIngredientById(ingredientId);
    if (ingredient == null)
    {
      throw new Exception("No such ingredient exists");
    }
    return ingredient;
  }

  public void DeleteIngredient(int ingredientId, string userId)
  {
    Ingredient ingredient = GetIngredientById(ingredientId);
    Recipe recipe = _recipesService.GetRecipeById(ingredient.RecipeId);
    if (recipe.CreatorId != userId)
    {
      throw new Exception("This ain't be belonging to you. Don't touch it.");
    }
    _ingredientsRepository.DeleteIngredient(ingredientId);
  }


}