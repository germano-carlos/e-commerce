<template>
  <div class="col-lg-4 col-md-12">
    <div class="woocommerce-sidebar-area">
      <div class="collapse-widget filter-list-widget">
        <h3 v-b-toggle.collapse-1 class="collapse-widget-title">
          Seleção atual
          <i class="fas fa-angle-up"></i>
        </h3>

        <b-collapse visible id="collapse-1" class="selected-filters-wrap-list">
          <ul>
            <li v-for="(filter, index) in this.filtrosEscolhidos" :key="index">
              <a href="#" @click="ExcluirFiltro(filter, index)">{{ filter.nome }}</a>
            </li>
          </ul>

          <div class="delete-selected-filters">
            <a href="#" @click="ExcluirTodosFiltros"
              ><i class="far fa-trash-alt"></i> <span>Limpar tudo</span></a
            >
          </div>
        </b-collapse>
      </div>

      <div class="collapse-widget collections-list-widget">
        <h3 v-b-toggle.collapse-2 class="collapse-widget-title">
          Coleções

          <i class="fas fa-angle-up"></i>
        </h3>
        <b-collapse visible id="collapse-2" v-if="this.filtrosSideBar.colecoes">
          <ul class="collections-list-row">
            <li
              v-for="(collection, index) in this.filtrosSideBar.colecoes"
              :key="index"
              :class="collection.active ? `active` : ``"
            >
              <a
                href="#"
                @click="adicionaFiltroPersonalizado(`colecao`, collection)"
                >{{ collection.nome }}</a
              >
            </li>
          </ul>
        </b-collapse>
      </div>

      <div
        class="collapse-widget brands-list-widget"
        v-if="this.filtrosSideBar.marcas"
      >
        <h3 v-b-toggle.collapse-3 class="collapse-widget-title">
          Marcas

          <i class="fas fa-angle-up"></i>
        </h3>

        <b-collapse visible id="collapse-3">
          <ul class="brands-list-row">
            <li
              v-for="(marca, index) in this.filtrosSideBar.marcas"
              :key="index"
              :class="marca.active ? `active` : ``"
            >
              <a
                href="#"
                @click="adicionaFiltroPersonalizado(`marca`, marca)"
                >{{ marca.nome }}</a
              >
            </li>
          </ul>
        </b-collapse>
      </div>

      <div
        class="collapse-widget size-list-widget"
        v-if="this.filtrosSideBar.tamanho"
      >
        <h3 v-b-toggle.collapse-4 class="collapse-widget-title">
          Tamanho
          <i class="fas fa-angle-up"></i>
        </h3>

        <b-collapse visible id="collapse-4">
          <ul class="size-list-row">
            <li
              v-for="(tamanho, index) in this.filtrosSideBar.tamanho"
              :key="index"
              :class="tamanho.active ? `active` : ``"
            >
              <a
                href="#"
                class="active"
                @click="adicionaFiltroPersonalizado(`tamanho`, tamanho)"
                >{{ tamanho.nome }}</a
              >
            </li>
          </ul>
        </b-collapse>
      </div>

      <div class="collapse-widget price-list-widget">
        <h3 v-b-toggle.collapse-5 class="collapse-widget-title">
          Preço
          <i class="fas fa-angle-up"></i>
        </h3>

        <b-collapse visible id="collapse-5">
          <ul class="price-list-row">
            <li><a href="#">R$10 - R$100</a></li>
            <li class="active"><a href="#">R$100 - R$200</a></li>
            <li><a href="#">R$200 - R$300</a></li>
            <li><a href="#">R$300 - R$400</a></li>
            <li><a href="#">R$400 - R$500</a></li>
            <li><a href="#">R$500 - R$600</a></li>
            <li><a href="#">R$600 +</a></li>
          </ul>
        </b-collapse>
      </div>

      <div class="collapse-widget color-list-widget">
        <h3 v-b-toggle.collapse-6 class="collapse-widget-title">
          Cor

          <i class="fas fa-angle-up"></i>
        </h3>

        <b-collapse visible id="collapse-6">
          <ul class="color-list-row">
            <li><a href="#" title="Black" class="color-black"></a></li>
            <li><a href="#" title="Red" class="color-red"></a></li>
            <li><a href="#" title="Yellow" class="color-yellow"></a></li>
            <li><a href="#" title="White" class="color-white"></a></li>
            <li><a href="#" title="Blue" class="color-blue"></a></li>
            <li><a href="#" title="Green" class="color-green"></a></li>
            <li>
              <a href="#" title="Yellow Green" class="color-yellowgreen"></a>
            </li>
            <li><a href="#" title="Pink" class="color-pink"></a></li>
            <li><a href="#" title="Violet" class="color-violet"></a></li>
            <li>
              <a href="#" title="Blue Violet" class="color-blueviolet"></a>
            </li>
            <li><a href="#" title="Lime" class="color-lime"></a></li>
            <li><a href="#" title="Plum" class="color-plum"></a></li>
          </ul>
        </b-collapse>
      </div>

      <!-- <div class="collapse-widget tag-list-widget">
        <h3 v-b-toggle.collapse-7 class="collapse-widget-title">
          Tags populares

          <i class="fas fa-angle-up"></i>
        </h3>
        <b-collapse visible id="collapse-7">
          <ul class="tags-list-row">
            <li><a href="#">Vintage</a></li>
            <li><a href="#">Black</a></li>
            <li class="active"><a href="#">Desconto</a></li>
            <li><a href="#">Good</a></li>
            <li><a href="#">Jeans</a></li>
            <li><a href="#">Summer</a></li>
            <li><a href="#">Winter</a></li>
          </ul>
        </b-collapse>
      </div> -->

      <div class="collapse-widget aside-products-widget" v-if="trending">
        <h3 class="aside-widget-title">Produtos populares</h3>

        <div
          class="aside-single-products"
          v-for="(prod, index) in this.trending"
          :key="index"
        >
          <div class="products-image">
            <a :href="`/products-details/${prod.id}`">
              <img :src="prod.imagem.descricao" alt="image" />
            </a>
          </div>

          <div class="products-content">
            <h3>
              <a :href="`/products-details/${prod.id}`">{{ prod.nome }}</a>
            </h3>

            <div class="product-price">
              <span class="new-price">R$ {{ prod.preco }}</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import WorkAPI from "../../apis/WorkAPI";

export default {
  props: ["products", "visible"],
  methods: {
    ExcluirFiltro(filter, index) {
      let indice = this.filtrosEscolhidos.indexOf(filter);
      if (indice > -1) {
        this.filtrosEscolhidos.splice(indice, 1);
      }
    },
    ExcluirTodosFiltros() {
      this.filtrosEscolhidos = [];
    },
    filtrarColecoes(element) {
      // Inclui as categorias em nosso filtro da barra lateral (Coleções)
      element.collection.forEach((collection) => {
        var cIndex = this.filtrosSideBar.colecoes.some(function (el, i) {
          return el.nome === collection.Categoria.nome;
        });

        if (!cIndex) {
          this.filtrosSideBar.colecoes = [
            ...this.filtrosSideBar.colecoes,
            { id: collection.Categoria.categoriaId, nome: collection.Categoria.nome, active: false, type: "colecao" },
          ];
        }
      });
    },
    filtrarMarcas(element) {
      // Inclui as marcas em nosso filtro da barra lateral (Marcas)
      let mIndex = this.filtrosSideBar.marcas.some(function (el, i) {
        return el.nome === element.brand;
      });
      if (!mIndex) {
        this.filtrosSideBar.marcas = [
          ...this.filtrosSideBar.marcas,
          { id: element.brand.marcaId , nome: element.brand.nome, active: false , type: "marca"},
        ];
      }
    },
    filtrarOpcoesProduto(element) {
      element.options.forEach((option) => {
        let cIndex = this.filtrosSideBar.cor.some(function (el, i) {
          return el.nome === option.cor;
        });
        if (!cIndex) {
          this.filtrosSideBar.cor = [...this.filtrosSideBar.cor, {nome: option.cor, type: "cor"}];
        }
        if (option.tamanho) {
          let tIndex = this.filtrosSideBar.tamanho.some(function (el, i) {
            return el.nome === option.tamanho;
          });
          if (!tIndex) {
            this.filtrosSideBar.tamanho = [
              ...this.filtrosSideBar.tamanho,
              { nome: option.tamanho, active: false, type: "tamanho" },
            ];
          }
        }
      });
    },
    adicionaFiltroPersonalizado(tipoFiltro, filtro) {
      let array = [];
      let inclui = true;
      let index = -1;
      switch (tipoFiltro) {
        case "colecao":
          array = this.filtrosSideBar.colecoes;

          index = array.indexOf(filtro);
          array[index].active = true;
          this.filtrosSideBar.colecoes = [...array];

          let cIndex = this.filtrosEscolhidos.some(function (el, i) {
            return el.nome === filtro.nome;
          });
          if (cIndex) inclui = false;
          break;
        case "marca":
          array = this.filtrosSideBar.marcas;

          index = array.indexOf(filtro);
          array[index].active = true;
          this.filtrosSideBar.marcas = [...array];

          let mIndex = this.filtrosEscolhidos.some(function (el, i) {
            return el.nome === filtro.nome;
          });
          if (mIndex) inclui = false;
          break;
        case "tamanho":
          array = this.filtrosSideBar.tamanho;

          index = array.indexOf(filtro);
          array[index].active = true;
          this.filtrosSideBar.tamanho = [...array];

          let tIndex = this.filtrosEscolhidos.some(function (el, i) {
            return el.nome === filtro.nome;
          });
          if (tIndex) inclui = false;
          break;
        case "preco":
          break;
      }
      if (inclui) {
        this.filtrosEscolhidos = [...this.filtrosEscolhidos, filtro];
      }
    },
  },
  data() {
    return {
      filtrosEscolhidos: [],
      filtrosSideBar: {
        colecoes: [],
        marcas: [],
        cor: [],
        tamanho: [],
      },
      trending: [],
    };
  },
  async mounted() {
    // Realiza a criação dos filtros da barra lateral
    this.products.forEach(async (element) => {
      this.filtrarMarcas(element);
      this.filtrarColecoes(element);
      this.filtrarOpcoesProduto(element);
    });

    // Busca os produtos Populares
    await WorkAPI.Produto.obterProdutosPopulares(
      null,
      async (data) => {
        for (let i = 0; i < data.length && i < 2; i++) {
          this.trending = [
            ...this.trending,
            {
              id: data[i].produtoId,
              nome: data[i].nome,
              imagem: data[i].AnexoImagemList[0]
                ? data[i]?.AnexoImagemList[0]
                : null,
              preco: data[i].opcoes[0] ? data[i].opcoes[0].preco : null,
            },
          ];
        }
      },
      () => {}
    );
  },
  watch: {
    filtrosEscolhidos (val, oldVal) {
      this.$emit('clicked', val);
    }
  }
};
</script>
