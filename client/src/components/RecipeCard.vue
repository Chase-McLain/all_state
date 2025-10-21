<script setup>
import { Recipe } from '@/models/Recipe.js';



defineProps({
  recipe: { type: Recipe, required: true }
})



</script>


<template>
  <div class="recipe-img mb-5 p-1" :style="{ backgroundImage: `URL(${recipe.img})` }">
    <span class="recipe-spacing justify-content-between">
      <span class="d-flex justify-content-between">
        <h5 class="recipe-title p-1">{{ recipe.category }}</h5>
        <p class="recipe-title p-1"><i class="mdi mdi-heart"></i></p>
      </span>
      <div class="recipe-title">
        <h5>{{ recipe.title }}</h5>
      </div>
    </span>
  </div>
</template>


<style lang="scss" scoped>
.recipe-img {
  background-position: center;
  background-size: cover;
  box-shadow: 0px 2px 10px;
  max-height: 300px;
  aspect-ratio: 1/1;
}

.recipe-spacing {
  display: flex;
  flex-direction: column;
  height: 100%;
}

.recipe-title {
  border-radius: 10px;
  border: solid 1px white;
  background-color: rgba(#525050, 0.8);
  color: white;
}
</style>