import { api } from "./AxiosService.js"


class FavoritesService{
  async getFavoritesByRecipe(recipeId) {
    const response = await api.get(`api/recipes/${recipeId}/favorites`)
    
  }


}







export const favoritesService = new FavoritesService()



