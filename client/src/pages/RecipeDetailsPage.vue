<script setup>
import { AppState } from '@/AppState.js';
import { ingredientsService } from '@/services/IngredientsService.js';
import { recipesService } from '@/services/RecipesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

onMounted(() => {
  getRecipeById()
  getIngredientsByRecipe()
})

const route = useRoute()
const recipe = computed(() => AppState.recipe)


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
</style>