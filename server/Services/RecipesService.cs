



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


  public Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _recipesRepository.GetRecipeById(recipeId);
    if (recipe == null)
    {
      throw new Exception("No such recipe exists.");
    }
    return recipe;
  }

  public Recipe UpdateRecipe(Recipe recipeData, string userId, int recipeId)
  {
    Recipe recipe = GetRecipeById(recipeId);
    if (recipe.CreatorId != userId)
    {
      throw new Exception("This ain't be belonging to you. Don't touch it.");
    }
    recipe.Title = recipeData.Title ?? recipe.Title;
    recipe.Instructions = recipeData.Instructions ?? recipe.Instructions;
    recipe.Img = recipeData.Img ?? recipe.Img;
    recipe.Category = recipeData.Category ?? recipe.Category;
    _recipesRepository.UpdateRecipe(recipe);
    return recipe;
  }

  public void DeleteRecipe(int recipeId, string userId)
  {
    Recipe recipe = GetRecipeById(recipeId);
    if (recipe.CreatorId != userId)
    {
      throw new Exception("This ain't be belonging to you. Don't touch it.");
    }
    _recipesRepository.DeleteRecipe(recipe.Id);
  }


}


