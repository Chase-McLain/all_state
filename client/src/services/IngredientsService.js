import { AppState } from "@/AppState.js"
import { api } from "./AxiosService.js"
import { Ingredient } from "@/models/Ingredient.js"



class IngredientsService{


  async getIngredientsByRecipe(recipeId) {
    AppState.ingredients = []
    const response = await api.get(`api/recipes/${recipeId}/ingredients`)
    AppState.ingredients = response.data.map((ingredient) => new Ingredient(ingredient))
  }



}





export const ingredientsService = new IngredientsService()





