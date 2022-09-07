<template>
  <div class="container-fluid">
    <div class="row">
      <Sidebar selected="produtos-gerenconf" />
      <main role="main" class="col-md-12 ml-sm-auto col-lg-10 px-4">
        <div
          class="d-md-flex d-lg-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom"
        >
          <h1 class="h2">Produtos</h1>
        </div>

        <!-- Banner Informacao Start -->
        <div>
          <div>
            <b-breadcrumb>
              <b-breadcrumb-item href="/admin">
                <b-icon
                  icon="house-fill"
                  scale="1.25"
                  shift-v="1.25"
                  aria-hidden="true"
                ></b-icon>
                Home
              </b-breadcrumb-item>
              <b-breadcrumb-item href="/admin/produto"
                >Produto</b-breadcrumb-item
              >
              <b-breadcrumb-item href="#" active
                >Gerenciar Configurações</b-breadcrumb-item
              >
            </b-breadcrumb>
          </div>

          <b-card footer-tag="footer" title="Configurações de Produto">
            <b-card-text
              >Bem vindo a área gerencial do seu e-commerce. Abaixo você
              conseguirá visualizar as configurações criadas e realizar
              modificações.
              <p></p>
            </b-card-text>
          </b-card>
        </div>
        <!-- Banner Informacao End -->
        <div style="margin: 20px 0 0 0">
          <b-card no-body class="mb-1">
            <b-card-header header-tag="header">
              <h5 class="mb-0">Categorias</h5>
            </b-card-header>
            <b-card-body>
              <div>
                <vue-table-dynamic :params="categoriasTable" ref="table"
                  ><template v-slot:column-5="{ props }">
                    <span v-if="props && props.row != 0" style="font-size: 20px">
                      <div style="display: flex">
                        <a href="#">
                          <b-icon
                            icon="pencil-square"
                            @click="EditarProduto(props.rowData)"
                          />
                        </a>
                        <a href="#">
                          <b-icon
                            icon="trash-fill"
                            @click="ExcluirProduto(props.rowData)"
                          />
                        </a></div
                    ></span> </template
                ></vue-table-dynamic>
              </div>
            </b-card-body>
          </b-card>
          <b-card no-body class="mb-1">
            <b-card-header header-tag="header">
              <h5 class="mb-0">Subcategorias</h5>
            </b-card-header>
            <b-card-body>
              <div>
                <vue-table-dynamic :params="subcategoriasTable" ref="table"
                  ><template v-slot:column-6="{ props }">
                    <span v-if="props && props.row != 0" style="font-size: 20px">
                      <div style="display: flex">
                        <a href="#">
                          <b-icon
                            icon="pencil-square"
                            @click="EditarProduto(props.rowData)"
                          />
                        </a>
                        <a href="#">
                          <b-icon
                            icon="trash-fill"
                            @click="ExcluirProduto(props.rowData)"
                          />
                        </a></div
                    ></span> </template
                ></vue-table-dynamic>
              </div>
            </b-card-body>
          </b-card>
          <b-card no-body class="mb-1">
            <b-card-header header-tag="header">
              <h5 class="mb-0">Classificações</h5>
            </b-card-header>
            <b-card-body>
              <div>
                <vue-table-dynamic :params="classificacoesTable" ref="table"
                  ><template v-slot:column-6="{ props }">
                    <span v-if="props && props.row != 0" style="font-size: 20px">
                      <div style="display: flex">
                        <a href="#">
                          <b-icon
                            icon="pencil-square"
                            @click="EditarProduto(props.rowData)"
                          />
                        </a>
                        <a href="#">
                          <b-icon
                            icon="trash-fill"
                            @click="ExcluirProduto(props.rowData)"
                          />
                        </a></div
                    ></span> </template
                ></vue-table-dynamic>
              </div>
            </b-card-body>
          </b-card>
        </div>

        <Loader v-if="loading" />
      </main>
    </div>
  </div>
</template>

<script>
import Loader from "~/components/common/Loader";
import Sidebar from "~/components/admin/Sidebar";
import WorkAPI from "../../../apis/WorkAPI";
import { ModelSelect, ModelListSelect, MultiSelect } from "vue-search-select";

export default {
  layout: "admin",
  methods: {
    detalhesConfiguracao() {},
  },
  components: {
    Loader,
    Sidebar,
    ModelSelect,
    ModelListSelect,
    MultiSelect,
  },
  data() {
    return {
      loading: true,
      ordersData: [
        {
          id: 1,
          details: { fullName: "Carlos Germano" },
          items: { image: "", name: "Sofa Cama", quantity: 2, price: "29.90" },
        },
      ],
      categoriasTable: {
        data: [
          [
            "Id",
            "Nome Categoria",
            "Data Inclusão",
            "Data Alteração",
            "Status",
            "Ações",
          ],
        ],
        header: "row",
        border: true,
        stripe: true,
        enableSearch: true,
        pagination: true,
        sort: [0, 1],
      },
      subcategoriasTable: {
        data: [
          [
            "Id",
            "Nome Subcategoria",
            "Nome Categoria",
            "Data Inclusão",
            "Data Alteração",
            "Status",
            "Ações",
          ],
        ],
        header: "row",
        border: true,
        stripe: true,
        enableSearch: true,
        pagination: true,
        sort: [0, 1, 2],
      },
      classificacoesTable: {
        data: [
          [
            "Id",
            "Nome Classificacao",
            "Nome Subcategoria",
            "Data Inclusão",
            "Data Alteração",
            "Status",
            "Ações",
          ],
        ],
        header: "row",
        border: true,
        stripe: true,
        enableSearch: true,
        pagination: true,
        sort: [0, 1, 2],
      },
    };
  },
  mounted() {
    // WS Call
    this.loading = true;
    WorkAPI.Categoria.ListarConfiguracoes(
      (data) => {
        constroiTabelas(data);
        this.loading = false;
      },
      () => {
        this.loading = false;
      }
    );

    const constroiTabelas = (data) => {
      let categorias = separaCategorias(data);
      let subcategorias = separaSubCategorias(categorias);
      let classificacoes = separaClassificacao(subcategorias);
    };
    const separaCategorias = (data) => {
      data.forEach((element) => {
        this.categoriasTable.data = [
          ...this.categoriasTable.data,
          [
            element.categoriaId,
            element.nome,
            element.dataInclusao,
            element.dataAlteracao,
            element.StatusAtividade == 1 ? "Ativo" : "Inativo",
            "Ações",
          ],
        ];
      });

      return data;
    };
    const separaSubCategorias = (categorias) => {
      let subcategorias = [];
      categorias.forEach((element) => {
        let categoriaNome = element.nome;
        if (element.subcategorias) {
          element.subcategorias.forEach((subcategoria) => {
            subcategorias = [...subcategorias, subcategoria.SubCategoria];
            this.subcategoriasTable.data = [
              ...this.subcategoriasTable.data,
              [
                subcategoria.SubCategoria.subcategoriaId,
                subcategoria.SubCategoria.nome,
                categoriaNome,
                subcategoria.SubCategoria.dataInclusao,
                subcategoria.SubCategoria.dataAlteracao,
                subcategoria.SubCategoria.StatusAtividade == 1
                  ? "Ativo"
                  : "Inativo",
                "Ações",
              ],
            ];
          });
        }
      });

      return subcategorias;
    };
    const separaClassificacao = (subcategorias) => {
      let classificacoes = [];
      subcategorias.forEach((element) => {
        let subcategoriaNome = element.nome;

        if (element.classificacoes) {
          element.classificacoes.forEach((classificacao) => {
            classificacoes = [
              ...classificacoes,
              classificacao.ClassificacaoItem,
            ];
            this.classificacoesTable.data = [
              ...this.classificacoesTable.data,
              [
                classificacao.ClassificacaoItem.idClassificacao,
                classificacao.ClassificacaoItem.nome,
                subcategoriaNome,
                classificacao.ClassificacaoItem.dataInclusao,
                classificacao.ClassificacaoItem.dataAlteracao,
                classificacao.ClassificacaoItem.StatusAtividade == 1
                  ? "Ativo"
                  : "Inativo",
                "Ações",
              ],
            ];
          });
        }
      });

      return classificacoes;
    };
  },
};
</script>

<style lang="scss">
.preloader-loading {
  position: fixed;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  text-align: center;
  background-color: rgba(0, 0, 0, 0.66);
  z-index: 999;

  .loader {
    position: absolute;
    top: 50%;
    transform: translateX(-50%) translateY(-50%);
    left: 50%;
    color: #fff;
  }
}

.accordion {
  padding: 30px 0px 30px 0;
}

.alert-config-item {
  padding-bottom: 0px;
  padding-top: 0px;
}

.recent-orders-box {
  margin-top: 30px;

  .title {
    position: relative;

    h3 {
      margin-bottom: 15px;
      font: {
        size: 20px;
        weight: 600;
      }
    }
    ul {
      padding-left: 0;
      margin-bottom: 0;
      list-style-type: none;
      position: absolute;
      right: 0;
      top: -10px;

      li {
        display: inline-block;
        margin-left: 5px;

        a,
        button {
          display: block;
          background-color: #f2f2f2;
          color: #000000;
          padding: 5px 15px;
          border: none;
          transition: 0.5s;

          &:hover {
            background-color: #000000;
            color: #fff;
          }
        }
        &:nth-child(2) {
          a,
          button {
            &:hover {
              background-color: red;
              color: #fff;
            }
          }
        }
        &:nth-child(3) {
          a,
          button {
            &:hover {
              background-color: green;
              color: #fff;
            }
          }
        }
      }
    }
  }
  table {
    margin-bottom: 0;

    thead {
      th {
        text-align: left;
        white-space: nowrap;
        padding: 15px 15px 15px 0;
        border-bottom: 1px solid #f6f6f7;
        border-color: #f6f6f7;
        font-size: 15px;
      }
    }
    tbody {
      tr {
        td {
          padding: 15px;
          vertical-align: middle;
          white-space: nowrap;
          border-bottom: 1px solid #f6f6f7;
          border-top: none;
          font-size: 14.4px;

          &:first-child {
            padding-left: 0;
          }
          &.name {
            font-weight: 700;
          }
          img {
            width: 50px;
            margin-right: 5px;
          }
        }
      }
    }
  }
}
.sidebar {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  z-index: 100; /* Behind the navbar */
  padding: 48px 0 0; /* Height of navbar */
  box-shadow: inset -1px 0 0 rgba(0, 0, 0, 0.1);
}

.sidebar-sticky {
  position: relative;
  top: 0;
  height: calc(100vh - 48px);
  padding-top: 0.5rem;
  overflow-x: hidden;
  overflow-y: auto; /* Scrollable contents if viewport is shorter than content. */
}

@supports ((position: -webkit-sticky) or (position: sticky)) {
  .sidebar-sticky {
    position: -webkit-sticky;
    position: sticky;
  }
}

.sidebar .nav-link {
  font-weight: 500;
  color: #333;
}

.sidebar .nav-link .feather {
  margin-right: 4px;
  color: #999;
}

.sidebar .nav-link.active {
  color: #007bff;
}

.sidebar .nav-link:hover .feather,
.sidebar .nav-link.active .feather {
  color: inherit;
}

.sidebar-heading {
  font-size: 0.75rem;
  text-transform: uppercase;
}

.breadcrumb-item a {
  display: inline;
}

/*
 * Content
 */

[role="main"] {
  padding-top: 133px; /* Space for fixed navbar */
}

@media (min-width: 768px) {
  [role="main"] {
    padding-top: 48px; /* Space for fixed navbar */
  }
}
</style>