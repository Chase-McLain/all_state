<script setup>
import { ref, watch } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';

const theme = ref(loadState('theme') || 'light')

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
}

watch(theme, () => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}, { immediate: true })

</script>

<template>
  <nav class="">
    <div class="container-fuid p-5">
      <div class="navbar-bg-img row">
        <div class="col-md-11 text-end text-white">
          <h5 class="mt-1">SEARCH BAR HERE</h5>
        </div>
        <div class="col-md-1 text-end mt-1">
          <Login />
        </div>
        <div class="col-12 text-center text-white logo-section">
          <RouterLink :to="{ name: 'Home' }" class="">
            <img class="all-state" src="../assets/img/Allstate-Logo.png" alt="all state logo">
          </RouterLink>
          <p class="mb-0 mt-2">Cherish Your Hands</p>
          <p class="mb-5">And Their Insurance</p>
        </div>
      </div>
      <div class="row justify-content-center position-relative">
        <div class="col-6 bg-white mini-nav">
          <span class="d-flex gap-5 justify-content-evenly text-center text-success">
            <RouterLink :to="{ name: 'Home' }" class="">
              <h5>Home</h5>
            </RouterLink>
            <h5>My Recipes</h5>
            <h5>Favorites</h5>
          </span>
        </div>
      </div>
    </div>
  </nav>
</template>

<style lang="scss" scoped>
a {
  text-decoration: none;
  color: unset;
}

.navbar-bg-img {
  background-image: url(../assets/img/navbar.png);
  background-position: center;
  background-size: cover;
  box-shadow: 0px 2px 10px;
}

.all-state {
  object-fit: cover;
  object-position: center;
  max-height: 150px;
}

.logo-section {
  text-shadow: 0px 2px 2px black;
}

.mini-nav {
  position: absolute;
  top: -20px;
  box-shadow: 0px 2px 4px;
}
</style>
