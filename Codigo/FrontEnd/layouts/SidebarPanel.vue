<template>
    <div>
        <div class="modal-backdrop" v-if="isPanelOpen"></div>
        <!-- Start Shopping Cart Modal -->
        <transition name="slide-fade">
            <div v-if="isPanelOpen" class="modal right shoppingCartModal" id="shoppingCartModal" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <button type="button" class="close" @click="closeSidebarPanel"><span aria-hidden="true">&times;</span></button>

                        <div 
                            class="modal-body"
                            v-if="cart.length > 0"
                        >
                            <h3>Meu carrinho ({{cart.length}})</h3>

                            <div class="product-cart-content">

                                <div 
                                    class="product-cart"
                                    v-for="cart in cart"
                                    :key="cart.id"
                                >
                                    <div class="product-image">
                                        <img :src="cart.image" :alt="cart.name" />
                                    </div>

                                    <div class="product-content">
                                        <h3><a href="#">{{cart.name}}</a></h3>
                                        <span>Azul / XS</span>
                                        <div class="product-price">
                                            <span>{{cart.quantity}}</span>
                                            <span>x</span>
                                            <span class="price">R$ {{cart.price}}</span>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="product-cart-subtotal">
                                <span>Subtotal</span>

                                <span class="subtotal">R$ {{cartTotal}}</span>
                            </div>

                            <div @click="closeSidebarPanel" class="product-cart-btn">
                                <nuxt-link to="/checkout" class="btn btn-primary">Fazer o check-out</nuxt-link>
                                <nuxt-link to="/cart" class="btn btn-light">Ver o carrinho de compras</nuxt-link>
                            </div>
                        </div>
                        <div class="modal-body" v-else>
                            <h3>Carrinho Vazio!</h3>
                            <div @click="closeSidebarPanel" class="product-cart-btn">
                                <nuxt-link to="/products" class="btn btn-primary">Procurar Produtos</nuxt-link>
                                <!-- <nuxt-link to="/products" class="btn btn-light">Browse Latest!</nuxt-link> -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </transition>
        <!-- End Shopping Cart Modal -->
    </div>
</template>

<script>
import { store, mutations } from '../utils/sidebar-util';
export default {
    name: 'SidebarPanel',
    methods: {
        closeSidebarPanel: mutations.toggleNav
    },
    computed: {
        isPanelOpen(){
            return store.isNavOpen
        },
        cart(){
            return this.$store.getters.cart
        },
        cartTotal(){
            return this.$store.getters.totalAmount
        }
    }
}
</script>

<style lang="scss" scoped>
@import "../assets/scss/styles/_transitions.scss";
</style>