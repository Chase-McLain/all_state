import { AppState } from "@/AppState.js"
import { api } from "./AxiosService.js"
import { Recipe } from "@/models/Recipe.js"




class RecipesService{


  async getRecipeById(recipeId) {
    AppState.recipe = null
    const response = await api.get(`api/recipes/${recipeId}`)
    const recipe = new Recipe(response.data)
    AppState.recipe =recipe
  }


  async getRecipes() {
    const response = await api.get("api/recipes")
    AppState.recipes = response.data.map((recipe) => new Recipe(recipe))
  }






}




export const recipesService = new RecipesService()



