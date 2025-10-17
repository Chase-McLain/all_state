
namespace all_state.Repositories;



public class RecipesRepository
{

  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  public Recipe createRecipe(Recipe recipeData)
  {
    string sql = @"
      INSERT INTO recipes
      (title, instructions, img, category, creator_id)
      VALUES
      (@Title, @Instructions, @Img, @Category, @CreatorId);

      SELECT recipes.*, accounts.*
      FROM recipes
      JOIN accounts ON accounts.id = recipes.creator_id
      WHERE recipes.id = LAST_INSERT_ID()
      ;";

    Recipe recipe = _db.Query(sql, (Recipe recipe, Profile account) => { recipe.Creator = account; return recipe; }, recipeData).SingleOrDefault();

    return recipe;
  }
}