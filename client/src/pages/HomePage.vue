<script setup>
import { AppState } from '@/AppState.js';
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
  <main class="container">
    <section class="row">
      <div class="col">
        {{ recipes }}
      </div>
    </section>
  </main>
</template>

<style scoped lang="scss"></style>
