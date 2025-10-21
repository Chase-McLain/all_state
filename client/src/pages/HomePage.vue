<script setup>
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted } from 'vue';





onMounted(() => {

})


async function getRecipes() {
  try {
    //
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
        recipes
      </div>
    </section>
  </main>
</template>

<style scoped lang="scss"></style>
