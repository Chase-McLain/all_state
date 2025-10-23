import { AppState } from "@/AppState.js"
import { api } from "./AxiosService.js"
import { Favorite } from "@/models/Favorite.js"


class FavoritesService{
  async getFavoritesByRecipe(recipeId) {
    const response = await api.get(`api/recipes/${recipeId}/favorites`)
    AppState.favorites = response.data.map((favorite) => new Favorite(favorite))
  }


}







export const favoritesService = new FavoritesService()



