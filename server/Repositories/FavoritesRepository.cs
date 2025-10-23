



namespace all_state.Repositories;


public class FavoritesRepository(IDbConnection db)
{
  private readonly IDbConnection _db = db;
  public FavoriteRecpie CreateFavorite(Favorite favoriteData)
  {
    string sql = @"
      INSERT INTO favorites
      (recipe_id, account_id)
      VALUES
      (@RecipeId, @AccountId);
      
      SELECT
      recipes.*,
      favorites.account_id AS account_id,
      favorites.id AS favorite_id,
      accounts.*
      FROM favorites
      INNER JOIN recipes ON favorites.recipe_id = recipes.id
      INNER JOIN accounts ON favorites.account_id = accounts.id
      WHERE favorites.id = LAST_INSERT_ID();";

    FavoriteRecpie favorite = _db.Query(sql, (FavoriteRecpie favorite, Profile account) => { favorite.Creator = account; return favorite; }, favoriteData).SingleOrDefault();

    return favorite;
  }

  public List<FavoriteRecpie> GetFavoritesByAccountId(string userId)
  {
    string sql = @"SELECT
      recipes.*,
      favorites.account_id AS account_id,
      favorites.id AS favorite_id,
      accounts.*
      FROM favorites
      INNER JOIN recipes ON favorites.recipe_id = recipes.id
      INNER JOIN accounts ON favorites.account_id = accounts.id
      WHERE favorites.account_id = @userId;";

    List<FavoriteRecpie> favorites = _db.Query(sql, (FavoriteRecpie favorite, Profile account) => { favorite.Creator = account; return favorite; }, new { userId }).ToList();

    return favorites;
  }

  public Favorite GetFavoritesById(int favoriteId)
  {
    string sql = @"SELECT * FROM favorites
      WHERE favorites.id = @favoriteId;";

    Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).SingleOrDefault();

    return favorite;
  }

  public void DeleteFavorite(int favoriteId)
  {
    string sql = @"DELETE FROM favorites
      WHERE favorites.id = @favoriteID LIMIT 1;";

    _db.Execute(sql, new { favoriteId });
  }

  public List<Favorite> GetFavoritesByRecipeId(int recipeId)
  {
    string sql = @"SELECT * FROM favorites
      WHERE favorites.recipe_id = @recipeId;";

    List<Favorite> favorites = _db.Query<Favorite>(sql, new { recipeId }).ToList();

    return favorites;
  }
}