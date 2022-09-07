<template>
  <div>
    <!-- Start Page Title Area -->
    <div class="page-title-area">
      <div class="container">
        <ul>
          <li><nuxt-link to="/">Inicio</nuxt-link></li>
          <li>Todos os produtos</li>
        </ul>
      </div>
    </div>
    <!-- End Page Title Area -->

    <!-- Start Collections Area -->
    <section class="products-collections-area ptb-60">
      <div class="container">
        <div class="section-title">
          <h2><span class="dot"></span> Produtos</h2>
        </div>

        <div class="row">
          <Sidebar
            v-if="this.products.length > 0 || this.visible"
            :products="this.products"
            v-on:clicked="AtualizaProdutosPorFiltro"
          />
          <AllProducts
            v-if="this.products.length > 0"
            :products="this.products"
          />
        </div>
      </div>
    </section>
    <!-- End Collections Area -->

    <Loader v-if="this.loading" />
  </div>
</template>

<script>
import Sidebar from "../components/all-products/Sidebar";
import AllProducts from "../components/all-products/AllProducts";
import WorkAPI from "../apis/WorkAPI";
import Loader from "../layouts/SiteLoder";

export default {
  components: {
    Sidebar,
    AllProducts,
    Loader,
  },
  methods: {
    async AtualizaProdutosPorFiltro(val) {
      this.loading = true;

      let brandsIds = [];
      let collectionsIds = [];
      let tamanhoIds = [];
      let precoIds = [];
      let coresIds = [];

      val.forEach((element) => {
        switch (element.type) {
          case "colecao":
            collectionsIds = [...collectionsIds, element.id];
            break;
          case "marca":
            brandsIds = [...brandsIds, element.id];
            break;
          case "preco":
            precoIds = [...precoIds, element.id];
            break;
          case "tamanho":
            tamanhoIds = [...tamanhoIds, element.nome];
            break;
          case "cor":
            coresIds = [...coresIds, element.nome];
            break;
        }
      });

      let filtrosP = {
        MarcasIds: brandsIds,
        CategoriasIds: collectionsIds,
        Tamanhos: tamanhoIds,
        Preco: precoIds,
        Cores: coresIds,
        SituacaoProduto: 1,
      };

      let parametros = {
        queryParams: this.queryParams,
        filtros: filtrosP,
      };

      let productB = [];
      await WorkAPI.Produto.listarProdutos(
        parametros,
        async (data) => {
          if (data.registros) {
            productB = [...data.registros];
            let next = true;

            while (data._metadata.possuiDepois && next) {
              parametros.queryParams.numeroPagina =
                parseInt(data._metadata.paginaAtual) + 1;
              await WorkAPI.Produto.listarProdutos(
                parametros,
                (data) => {
                  productB = [...productB, ...data.registros];
                  if (!data._metadata.possuiDepois) {
                    next = false;
                  }
                },
                () => {},
                "usuario"
              );
            }

            this.products = this.tratarRetornoProduto(productB);
          }
        },
        () => {},
        "usuario"
      );
      if (this.products.length == 0) {
        this.visible = true;
      }
      this.loading = false;
    },
    tratarRetornoProduto(array) {
      let aux = [];
      array.forEach((element) => {
        aux = [
          ...aux,
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
            collection: element.categorias,
            brand: element.Marca,
            options: element.opcoes,
          },
        ];
      });

      return aux;
    },
  },
  data() {
    return {
      products: [],
      loading: true,
      visible: false,
      queryParams: {
        tamanhoPagina: 2000,
        metadata: true,
      },
      filtros: {},
    };
  },
  async mounted() {
    let productB = [];
    let parametros = {
      queryParams: this.queryParams,
      filtros: this.filtros,
    };

    await WorkAPI.Produto.listarProdutos(
      parametros,
      async (data) => {
        productB = [...data.registros];
        let next = true;

        while (data._metadata.possuiDepois && next) {
          parametros.queryParams.numeroPagina =
            parseInt(data._metadata.paginaAtual) + 1;
          await WorkAPI.Produto.listarProdutos(
            parametros,
            (data) => {
              productB = [...productB, ...data.registros];
              if (!data._metadata.possuiDepois) {
                next = false;
              }
            },
            () => {},
            "usuario"
          );
        }
      },
      () => {},
      "usuario"
    );
    
    let aux = this.tratarRetornoProduto(productB);

    this.loading = false;
    this.products = aux;
  },
};

// IMPORTAR PRODUTOS PAGINADOS !,
</script>

