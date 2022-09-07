<template>
    <!-- Start Top Header Area -->
    <div class="top-header">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-7 col-md-6">
                    <ul class="top-header-nav">
                        <li v-if="this.isAuthenticated">
                            <nuxt-link to="/usuario/minha-area">Minha Conta</nuxt-link>
                        </li>
                        <li v-else>
                            <nuxt-link to="/login">Login</nuxt-link>
                        </li>
                        <li v-if="!this.isAuthenticated" ><nuxt-link to="/signup">Cadastrar</nuxt-link></li>
                        <li><nuxt-link to="/products">Nossos Produtos</nuxt-link></li>
                        <li><nuxt-link to="/contact">Contatos</nuxt-link></li>
                    </ul>
                </div>

                <div class="col-lg-5 col-md-6">
                    <ul class="top-header-right-nav">
                        <li><nuxt-link to="/cart">Carrinho</nuxt-link></li>
                        <li>
                            <div class="languages-list">
                                <select>
                                    <option value="1">PT-BR</option>
                                    <!-- <option value="2">en-US</option>
                                    <option value="3">es-ES</option> -->
                                </select>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- End Top Header Area -->
</template>

<script>

export default {
    data() {
        return {

        }
    },
    methods: {

    },
    computed: {
        isAuthenticated() {
            return this.$auth.loggedIn && this.$auth.strategy.options.name === "usuario";
        }
    }
}
</script>
