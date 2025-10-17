

namespace all_state.Repositories;


public class RecipesRepository(IDbConnection db)
{
  private readonly IDbConnection _db = db;


  public Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
      INSERT INTO recipes
      (title, instructions, img, category, creator_id)
      VALUES
      (@Title, @Instructions, @Img, @Category, @CreatorId);

      SELECT recipes.*, accounts.*
      FROM recipes
      INNER JOIN accounts ON accounts.id = recipes.creator_id
      WHERE recipes.id = LAST_INSERT_ID();";

    Recipe recipe = _db.Query(sql, (Recipe recipe, Profile account) => { recipe.Creator = account; return recipe; }, recipeData).SingleOrDefault();

    return recipe;
  }


  public List<Recipe> GetRecipes()
  {
    string sql = @"SELECT recipes.*, accounts.*
      FROM recipes
      INNER JOIN accounts ON accounts.id = recipes.creator_id";

    List<Recipe> recipes = _db.Query(sql, (Recipe recipe, Profile account) => { recipe.Creator = account; return recipe; }).ToList();

    return recipes;
  }


  public Recipe GetRecipeById(int recipeId)
  {
    string sql = @"SELECT recipes.*, accounts.*
      FROM recipes
      INNER JOIN accounts ON accounts.id = recipes.creator_id
      WHERE recipes.id = @recipeId;";

    Recipe recipe = _db.Query(sql, (Recipe recipe, Profile account) => { recipe.Creator = account; return recipe; }, new { recipeId }).SingleOrDefault();

    return recipe;
  }


  public void UpdateRecipe(Recipe recipe)
  {
    string sql = @"UPDATE recipes
    SET
    title = @Title,
    instructions = @Instructions,
    img = @Img,
    category = @Category
    WHERE id = @Id
    LIMIT 1;";

    int rows = _db.Execute(sql, recipe);

    if (rows != 1)
    {
      throw new Exception("Machine broke.");
    }
  }

  public void DeleteRecipe(int recipeId)
  {
    string sql = @"DELETE FROM recipes WHERE recipes.id = @recipeId LIMIT 1;";

    int rows = _db.Execute(sql, new { recipeId });

    if (rows != 1)
    {
      throw new Exception("Machine broke.");
    }
  }
}