import { api } from "./AxiosService.js"



class IngredientsService{


  getIngredientsByRecipe(recipeId) {
    const response = api.get(`api/recipes/${recipeId}/ingredients`)
  }



}





export const ingredientsService = new IngredientsService()





