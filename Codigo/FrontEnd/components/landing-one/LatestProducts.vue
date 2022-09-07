<template>
  <div>
    <!-- Start All Products Area -->
    <section class="all-products-area pb-60">
      <div class="container">
        <div class="section-title">
          <h2><span class="dot"></span> Produtos Recentemente Adicionados</h2>
        </div>

        <div class="row">
          <ProductItem
            v-for="(product, index) in produtos"
            :product="product"
            :key="index"
            @clicked="toggle(product)"
            :className="`col-lg-3 col-md-6 col-sm-6`"
          ></ProductItem>
        </div>
      </div>
    </section>
    <!-- End all Products Area -->
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
      produtoQV: null
    };
  },
  async mounted() {
    let produtosRetorno = [];
    await WorkAPI.Produto.obterUltimosProdutos(
      null,
      (data) => {
        data.forEach((element) => {
          produtosRetorno = [
            ...produtosRetorno,
            {
              id: element.produtoId,
              name: element.nome,
              price: 191.0,
              offer: false,
              offerPrice: 0,
              latest: true,
              bestSellers: false,
              trending: false,
              image: element.AnexoImagemList[0]?.descricao,
              imageHover: !element.AnexoImagemList[1]?.descricao
                ? element.AnexoImagemList[0]?.descricao
                : element.AnexoImagemList[1].descricao,
              timePeriod: false,
              dateTime: element.dataAtualizacao,
            },
          ];
        });

        this.produtos = produtosRetorno;
      },
      () => {}
    );
  },
  computed: {},
};
</script>