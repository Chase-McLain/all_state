
namespace all_state.Repositories;


public class IngredientsRepository(IDbConnection db)
{
  private readonly IDbConnection _db = db;


  public Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"INSERT INTO ingredients
      (name, quantity, recipe_id)
      VALUES
      (@Name, @Quantity, @RecipeId);
      
      SELECT * FROM ingredients
      WHERE id = LAST_INSERT_ID();";

    Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).SingleOrDefault();

    return ingredient;
  }

  public List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"SELECT *
      FROM ingredients
      WHERE ingredients.recipe_id = @recipeId;";

    List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();

    return ingredients;
  }
}