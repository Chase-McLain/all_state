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
      INNER JOIN accounts ON accounts.id = recipes.creator_id
      WHERE recipes.creator_id = accounts.id;";

    List<Recipe> recipes = _db.Query(sql, (Recipe recipe, Profile account) => { recipe.Creator = account; return recipe; }).ToList();

    return recipes;
  }
}