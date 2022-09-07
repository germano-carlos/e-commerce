<template>
    <div class="col-lg-8 col-md-12">
        <div class="products-filter-options">
            <div class="row align-items-center">
                <div class="col d-flex">
                    <p>Mostrando {{this.products.length}} de 102 resultados</p>
                </div>

                <div class="col d-flex">
                    <span>Mostrar:</span>

                    <div class="show-products-number">
                        <select>
                            <option value="1">22</option>
                            <option value="2">32</option>
                            <option value="3">42</option>
                            <option value="4">52</option>
                            <option value="5">62</option>
                        </select>
                    </div>

                    <span>Ordenar:</span>

                    <div class="products-ordering-list">
                        <select>
                            <option value="1">Destaques</option>
                            <option value="2">Mais Vendido</option>
                            <option value="3">Preço crescente</option>
                            <option value="4">Preço decrescente</option>
                            <option value="5">Data Ascendente</option>
                            <option value="6">Data Decrescente</option>
                            <option value="7">Nome crescente</option>
                            <option value="8">Nome Decrescente</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>

        <div id="products-filter" class="products-collections-listing row">
            <ProductItem
                v-for="(product, index) in this.products"
                :product="product"
                :key="index"
                @clicked="toggle(product)"
                :className="`col-lg-6 col-md-6 products-col-item`"
            ></ProductItem>
            
        </div>

        <nav class="woocommerce-pagination">
            <ul>
                <li><a href="#" class="page-numbers">1</a></li>
                <li><span class="page-numbers current">2</span></li>
                <li><a href="#" class="page-numbers">3</a></li>
                <li><a href="#" class="page-numbers">4</a></li>
                <li><span class="page-numbers dots">…</span></li>
                <li><a href="#" class="page-numbers">11</a></li>
                <li><a href="#" class="page-numbers">12</a></li>
                <li><a href="#" class="next page-numbers"><i class="fas fa-chevron-right"></i></a></li>
            </ul>
        </nav>

        <QuckView v-if="this.produtoQV" :product="this.produtoQV" />
    </div>
</template>

<script>
import QuckView from '../modals/QuckView';
import { mutations } from '../../utils/sidebar-util';
import ProductItem from '../landing-one/ProductItem';
export default {
    components: {
        QuckView,
        ProductItem
    },
    props: ['products'],
    data() {
        return { 
            produtoQV: null,
            productsA: []
        }
    },
    methods: {
        toggle(product) {
            this.produtoQV = product;
            mutations.toggleQuickView();
        }
    },
    mounted() {
    }
}
</script>