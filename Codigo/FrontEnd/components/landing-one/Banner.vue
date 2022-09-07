<template>
  <!-- Start Main Banner Area -->
  <div class="main-banner item-bg1">
    <div class="d-table">
      <div class="d-table-cell">
        <div class="container">
          <div class="main-banner-content">
            <span>Novas Insipirações {{ new Date().getFullYear() }}</span>
            <h1>Roupas feitas para você</h1>
            <p>Coleções para homens e mulheres</p>

            <nuxt-link to="/products" class="btn btn-primary"
              >Loja Mulheres</nuxt-link
            >
            <nuxt-link to="/products" class="btn btn-light"
              >Loja Homens</nuxt-link
            >
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- End Main Banner Area -->
</template>

<script>
export default {
  name: "Banner",
};
</script>