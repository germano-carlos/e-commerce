<template>
  <div>
    <!-- Start Navbar Area -->
    <div :class="['navbar-area', { 'is-sticky': isSticky }]">
      <div class="comero-nav">
        <div class="container">
          <nav class="navbar navbar-expand-md navbar-light">
            <nuxt-link class="navbar-brand" to="/">
              <img src="../static/logo.png" style="font-size: 1px" alt="logo" />
            </nuxt-link>

            <b-navbar-toggle target="navbarSupportedContent"></b-navbar-toggle>

            <b-collapse
              class="collapse navbar-collapse"
              id="navbarSupportedContent"
              is-nav
            >
              <ul class="navbar-nav">
                <li class="nav-item p-relative">
                  <a href="#" class="nav-link"
                    >Inicio <i class="fas fa-chevron-down"></i
                  ></a>
                  <ul class="dropdown-menu">
                    <li class="nav-item">
                      <nuxt-link to="/" class="nav-link active"
                        >Estilo 1</nuxt-link
                      >
                    </li>

                    <li class="nav-item">
                      <nuxt-link to="/diction-two" class="nav-link active"
                        >Estilo 2</nuxt-link
                      >
                    </li>
                    <li class="nav-item">
                      <nuxt-link to="/diction-three" class="nav-link active"
                        >Estilo 3</nuxt-link
                      >
                    </li>
                  </ul>
                </li>

                <li class="nav-item p-relative">
                  <a href="#" class="nav-link"
                    >Loja <i class="fas fa-chevron-down"></i
                  ></a>
                  <ul class="dropdown-menu">
                    <li class="nav-item">
                      <nuxt-link to="/products" class="nav-link"
                        >Produtos</nuxt-link
                      >
                    </li>

                    <li class="nav-item">
                      <nuxt-link to="/products-details/1" class="nav-link"
                        >Detalhes de produtos</nuxt-link
                      >
                    </li>
                  </ul>
                </li>

                <li class="nav-item">
                  <nuxt-link to="/gallery-one" class="nav-link"
                    >Galeria</nuxt-link
                  >
                </li>

                <li class="nav-item p-relative">
                  <a href="#" class="nav-link"
                    >Páginas <i class="fas fa-chevron-down"></i
                  ></a>
                  <ul class="dropdown-menu">
                    <li class="nav-item">
                      <nuxt-link to="/gallery-one" class="nav-link"
                        >Galeria</nuxt-link
                      >
                    </li>

                    <li class="nav-item">
                      <nuxt-link to="/cart" class="nav-link">Carrinho</nuxt-link>
                    </li>

                    <li class="nav-item">
                      <nuxt-link to="/checkout" class="nav-link"
                        >Checkout</nuxt-link
                      >
                    </li>

                    <li class="nav-item">
                      <nuxt-link to="/login" class="nav-link">Login</nuxt-link>
                    </li>

                    <li class="nav-item">
                      <nuxt-link to="/signup" class="nav-link"
                        >Signup</nuxt-link
                      >
                    </li>

                    <li class="nav-item">
                      <nuxt-link to="/not-found" class="nav-link"
                        >Error 404</nuxt-link
                      >
                    </li>

                    <li class="nav-item">
                      <nuxt-link to="/contact" class="nav-link"
                        >Contato</nuxt-link
                      >
                    </li>
                  </ul>
                </li>

                <li class="nav-item p-relative">
                  <a href="#" class="nav-link"
                    >Blog <i class="fas fa-chevron-down"></i
                  ></a>
                  <ul class="dropdown-menu">
                    <li class="nav-item">
                      <nuxt-link to="/blog-one" class="nav-link"
                        >Blog Grid</nuxt-link
                      >
                    </li>

                    <li class="nav-item">
                      <nuxt-link to="/blog-details" class="nav-link"
                        >Blog Details</nuxt-link
                      >
                    </li>
                  </ul>
                </li>

                <li class="nav-item">
                  <nuxt-link to="/contact" class="nav-link">Contato</nuxt-link>
                </li>
              </ul>

              <div class="others-option">
                <div class="option-item">
                  <nuxt-link to="/login">{{ this.logado.mensagem }}</nuxt-link>
                </div>
                <div class="option-item">
                  <a @click.prevent="toggle" href="#">
                    Carrinho({{ cart.length }}) <i class="fas fa-shopping-bag"></i>
                  </a>
                </div>
                <div v-if="this.logado.status" class="option-item">
                  <a style="cursor: pointer" @click="Logout">Sair</a>
                </div>
              </div>
            </b-collapse>
          </nav>
        </div>
      </div>
    </div>
    <!-- End Navbar Area -->

    <SidebarPanel></SidebarPanel>
  </div>
</template>

<script>
import SidebarPanel from "../layouts/SidebarPanel";
import { mutations } from "../utils/sidebar-util";
export default {
  components: {
    SidebarPanel,
  },
  data() {
    return {
      isSticky: false,
      logado: {
        status: false,
        mensagem: "Login",
        redirect: "/login",
      },
    };
  },
  mounted() {
    const that = this;
    window.addEventListener("scroll", () => {
      let scrollPos = window.scrollY;
      if (scrollPos >= 100) {
        that.isSticky = true;
      } else {
        that.isSticky = false;
      }
    });

    if (this.$auth.loggedIn && this.$auth.strategy.options.name === "usuario") {
      let arrayNome = this.$auth.$state.user.nomeUsuario.split(" ");
      let fname = arrayNome[0];
      let lname = arrayNome[arrayNome.length - 1];

      let name = fname !== lname ? fname + " " + lname : fname;

      this.logado = {
        status: true,
        mensagem: name,
        redirect: "/usuario/minha-area",
      };
    }
  },
  computed: {
    cart() {
      return this.$store.getters.cart;
    },
  },
  methods: {
    toggle() {
      mutations.toggleNav();
    },
    Logout() {
      this.$auth.logout().then(() => {
        this.logado = {
          status: false,
          mensagem: "Login",
          redirect: "/login"
        };

        this.$auth.$state.user = null;
        this.$auth.loggedIn = false;
        this.$router.push("/login");
      });
    },
  },
};
</script>