
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
}