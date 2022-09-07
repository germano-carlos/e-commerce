<template>
  <div v-if="this.produtos.length > 0">
    <!-- Start Trending Products Area -->
    <section class="trending-products-area pb-60">
      <div class="container">
        <div class="section-title">
          <h2><span class="dot"></span> Produtos Populares</h2>
        </div>

        <div class="row">
          <ProductItem
            v-for="product in produtos"
            :product="product"
            :key="product.id"
            @clicked="toggle(product)"
            :className="`col-lg-3 col-md-6 col-sm-6`"
          ></ProductItem>
        </div>
      </div>
    </section>
    <!-- End Trending Products Area -->
    <QuckView v-if="this.produtoQV" :product="this.produtoQV" />
  </div>
</template>

<script>
import QuckView from "../modals/QuckView";
import { mutations } from "../../utils/sidebar-util";
import ProductItem from "./ProductItem";
import WorkAPI from "../../apis/WorkAPI";
export default {
  components: {
    QuckView,
    ProductItem,
  },

  methods: {
    toggle(product) {
      this.produtoQV = product;
      mutations.toggleQuickView();
    },
  },

  data() {
    return {
      produtos: [],
      produtoQV: null,
    };
  },

  async mounted() {
    let produtosRetorno = [];
    await WorkAPI.Produto.obterProdutosPopulares(
      null,
      (data) => {
        for (
          let contador = 0;
          contador < data.length && contador < 4;
          contador++
        ) {
          produtosRetorno = [
            ...produtosRetorno,
            {
              id: data[contador].produtoId,
              name: data[contador].nome,
              price: 191.0,
              offer: false,
              offerPrice: 0,
              latest: true,
              bestSellers: false,
              trending: false,
              image: data[contador].AnexoImagemList[0]?.descricao,
              imageHover: !data[0].AnexoImagemList[1]?.descricao
                ? data[contador].AnexoImagemList[0]?.descricao
                : data[contador].AnexoImagemList[1].descricao,
              timePeriod: false,
              dateTime: data[contador].dataAtualizacao,
            },
          ];
        }

        this.produtos = produtosRetorno;
      },
      () => {}
    );
  },

  computed: {},
};
</script>