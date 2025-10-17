
namespace all_state.Services;




public class RecipesService
{

  private readonly RecipesRepository _recipesRepository;

  public RecipesService(RecipesRepository recipesRepository)
  {
    _recipesRepository = recipesRepository;
  }

  public Recipe createRecipe(Recipe recipeData)
  {
    Recipe recipe = _recipesRepository.createRecipe(recipeData);
    return recipe;
  }
}


