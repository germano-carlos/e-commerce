<template>
    <div>
        <!-- Start Page Title Area -->
        <div class="page-title-area">
            <div class="container">
                <ul>
                    <li><nuxt-link to="/">Inicio</nuxt-link></li>
                    <li>{{product.name}}</li>
                </ul>
            </div>
        </div>
        <!-- End Page Title Area -->

        <!-- Start Products Details Area -->
        <section class="products-details-area ptb-60">
            <div class="container">
                <div class="row">
                    <ProductImages :anexos="this.product.image" />
                    <Details 
                        :id = "this.product.id"
                        :name = "this.product.name" 
                        :price = "this.product.price"
                        :image = "this.product.banner"
                    />
                    <DetailsInfo :descricao="this.product.descricao" />
                    <!-- <RelatedProducts :id = "this.product.id" /> -->
                </div>
            </div>
        </section>
    </div>
</template>



<script>
import ProductImages from '../../components/products/ProductImages';
import Details from '../../components/products/Details';
import DetailsInfo from '../../components/products/DetailsInfo';
import RelatedProducts from '../../components/products/RelatedProducts';
import WorkAPI from "../../apis/WorkAPI";

export default {
    components: {
        ProductImages, Details, DetailsInfo, RelatedProducts
    },
    data(){
        return {
            id: this.$route.params.id,
            product: {
                id: null,
                name: '', 
                price: 0,
                image: null,
                descricao: '',
                banner: ''
            }
        }
    },
    async mounted() {
        await WorkAPI.Produto.obterProdutoPorId(
            this.id,
            (data) => {
                this.product.id = data.produtoId;
                this.product.name = data.nome;
                this.product.price = data.opcoes[0] ? data.opcoes[0].preco : 0;
                this.product.image = data.AnexoImagemList;
                this.product.banner = data.AnexoImagemList[0]?.descricao;
                this.product.descricao = data.descricao;
            }
        );
    }
}
</script>