

namespace all_state.Services;




public class RecipesService(RecipesRepository recipesRepository)
{
  private readonly RecipesRepository _recipesRepository = recipesRepository;


  public Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _recipesRepository.CreateRecipe(recipeData);
    return recipe;
  }


  public List<Recipe> GetRecipes()
  {
    List<Recipe> recipes = _recipesRepository.GetRecipes();
    return recipes;
  }
}


