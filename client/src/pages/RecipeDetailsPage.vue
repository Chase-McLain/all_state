<script setup>
import { AppState } from '@/AppState.js';
import { Account } from '@/models/Account.js';
import { favoritesService } from '@/services/FavoritesService.js';
import { ingredientsService } from '@/services/IngredientsService.js';
import { recipesService } from '@/services/RecipesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

onMounted(() => {
  getRecipeById()
  getIngredientsByRecipe()
  getFavoritesByRecipe()
})

const route = useRoute()
const router = useRouter()
const account = computed(() => AppState.account)
const recipe = computed(() => AppState.recipe)
const ingredients = computed(() => AppState.ingredients)
const favorite = computed(() => AppState.favorites)


async function getRecipeById() {
  try {
    await recipesService.getRecipeById(route.params.recipeId)
  }
  catch (error) {
    Pop.error(error);
    logger.error(error)
  }
}

async function getIngredientsByRecipe() {
  try {
    await ingredientsService.getIngredientsByRecipe(route.params.recipeId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function deleteRecipe() {
  const confirmed = await Pop.confirm(`Are you sure you wish to delete ${recipe.value.title}?`)
  if (!confirmed) {
    return
  }
  try {
    await recipesService.deleteRecipe(route.params.recipeId)
    router.push({ name: 'Home' })
  }
  catch (error) {
    Pop.error(error);
  }
}

async function getFavoritesByRecipe() {
  try {
    await favoritesService.getFavoritesByRecipe(route.params.recipeId)
  }
  catch (error) {
    Pop.error(error);
    logger.error(error)
  }
}


</script>


<template>
  <main class="container-fluid">
    <section v-if="recipe" class="row flex-grow-1">
      <div class="col-md-6 recipe-img" :style="{ backgroundImage: `URL(${recipe.img})` }">
        <h1 class="favorite-box rounded-bottom-4"><i class="mdi mdi-heart"></i> 99</h1>
      </div>
      <div class="col-md-6">
        <span class="d-flex justify-content-between">
          <div>
            <h2 class="mt-3">{{ recipe.title }}</h2>
            <p>By: {{ recipe.creator.name }}</p>
            <p class="category-box text-center">{{ recipe.category }}</p>
          </div>
          <div>
            <RouterLink :to="{ name: 'Home' }">
              <span><i class="mdi mdi-close-thick fs-3"></i></span>
            </RouterLink>
          </div>
        </span>
        <section class="row">
          <div class="col-md-12">
            <h3>Ingredients</h3>
            <p v-for="ingredient in ingredients" :key="'ingredients' + ingredient.id">{{ ingredient.name }}</p>
          </div>
        </section>
        <section class="row">
          <div class="col-md-12">
            <h3>Instructions</h3>
            <p>{{ recipe.instructions }}</p>
          </div>
        </section>
        <section class="row">
          <div class="col-md-12 button-zone text-end">
            <button v-if="account?.id == recipe.creatorId" class="btn btn-success">
              Edit <i class="mdi mdi-pencil-plus"></i>
            </button>
            <button v-if="account?.id == recipe.creatorId" @click="deleteRecipe()" class="btn btn-danger ms-2">
              DELETE <i class="mdi mdi-trash-can"></i>
            </button>
          </div>
        </section>
      </div>
    </section>
  </main>
</template>


<style lang="scss" scoped>
.recipe-img {
  background-size: cover;
  background-position: center;
}

a {
  color: unset;
  text-decoration: none;
}

.favorite-box {
  background-color: rgba(#a8a8a8, 0.8);
  max-width: 6rem;
}

.category-box {
  background-color: rgba(#a0a0a0, 0.9);
  color: white;
  max-width: 5rem;
  border-radius: 10px;
}

.button-zone {
  flex-grow: 1;
}
</style>