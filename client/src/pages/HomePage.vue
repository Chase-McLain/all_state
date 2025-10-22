<script setup>
import { AppState } from '@/AppState.js';
import Navbar from '@/components/Navbar.vue';
import RecipeCard from '@/components/RecipeCard.vue';
import { recipesService } from '@/services/RecipesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';




onMounted(() => {
  getRecipes()
})

const recipes = computed(() => AppState.recipes)


async function getRecipes() {
  try {
    await recipesService.getRecipes()
  }
  catch (error) {
    Pop.error(error);
    logger.error(error)
  }
}



</script>

<template>
  <header>
    <Navbar />
  </header>
  <main class="container-fluid">
    <section class="row mt-5 gap-1 justify-content-evenly">
      <div v-for="recipe in recipes" :key="'recipe' + recipe.id" class="col-md-3">
        <RecipeCard :recipe="recipe" />
      </div>
    </section>
  </main>
</template>

<style scoped lang="scss">
.a {
  text-decoration: unset;
  color: unset;
}
</style>
