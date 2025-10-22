import { reactive } from 'vue'


export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,



  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,

  /** @type {import('./models/Recipe.js').Recipe[]} */
  recipes: [],

  /** @type {import('./models/Recipe.js').Recipe} */
  recipe: null,

  /** @type {import('./models/Ingredient.js').Ingredient[]} */
  ingredients: []
})

