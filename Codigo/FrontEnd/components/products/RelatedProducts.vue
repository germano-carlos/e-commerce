<template>
    <div>
        <div class="related-products-area">
            <div class="container">
                <div class="section-title">
                    <h2><span class="dot"></span> Produtos Relacionados</h2>
                </div>

                <div class="row">
                    <ProductItem
                        v-for="product in relatedProducts"
                        :product="product"
                        :key="product.id"
                        @clicked="toggle(product)"
                        :className="`col-lg-3 col-md-6 col-6`"
                    ></ProductItem>
                </div>
            </div>
        </div>
        <QuckView v-if="this.produtoQV" :product="this.produtoQV" />
    </div>
</template>

<script>
import ProductItem from '../landing-one/ProductItem';
import { mutations } from '../../utils/sidebar-util';
import QuckView from '../modals/QuckView';
export default {
    components: {
        ProductItem, QuckView
    },
    props: ['id'],
    methods: {
        toggle(product) {
            this.produtoQV = product;
            mutations.toggleQuickView()
        }
    },
    computed: {
        relatedProducts(){
            return this.$store.state.products.all.filter(product => product.id !== parseInt(this.id)).slice(0, 4);
        }
    },
    data() {
        return {
            produtoQV: null
        }
    }
}
</script>