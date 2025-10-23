

namespace all_state.Services;


public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepository;

  public FavoritesService(FavoritesRepository favoritesRepository)
  {
    _favoritesRepository = favoritesRepository;
  }


  public FavoriteRecpie CreateFavorite(Favorite favoriteData)
  {
    FavoriteRecpie favorite = _favoritesRepository.CreateFavorite(favoriteData);
    return favorite;
  }

  public List<FavoriteRecpie> GetFavoritesByAccountId(string userId)
  {
    List<FavoriteRecpie> favorites = _favoritesRepository.GetFavoritesByAccountId(userId);
    return favorites;
  }

  private Favorite GetFavoriteById(int favoriteId)
  {
    Favorite favorite = _favoritesRepository.GetFavoritesById(favoriteId);
    if (favorite == null)
    {
      throw new Exception("No such favorite exists");
    }
    return favorite;
  }

  public void DeleteFavorite(string userId, int favoriteId)
  {
    Favorite favorite = GetFavoriteById(favoriteId);
    if (favorite.AccountId != userId)
    {
      throw new Exception("This ain't be belonging to you. Don't touch it.");
    }
    _favoritesRepository.DeleteFavorite(favoriteId);
  }

  public List<Favorite> GetFavoritesByRecipeId(int recipeId)
  {
    List<Favorite> favorites = _favoritesRepository.GetFavoritesByRecipeId(recipeId);
    return favorites;
  }
}