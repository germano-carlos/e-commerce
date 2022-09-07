<template>
  <div class="container-fluid">
    <div class="row">
      <Sidebar selected="produtos-conf"/>
      <main role="main" class="col-md-12 ml-sm-auto col-lg-10 px-4">
        <div
          class="d-md-flex d-lg-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom"
        >
          <h1 class="h2">Produtos</h1>
          <div class="btn-toolbar">
            <div class="btn-group mr-2">
              <button
                v-b-tooltip.hover
                title="Coming Soon"
                type="button"
                class="btn btn-sm btn-outline-secondary"
              >
                Share
              </button>
              <button
                v-b-tooltip.hover
                title="Coming Soon"
                type="button"
                class="btn btn-sm btn-outline-secondary ml-2"
              >
                Export
              </button>
            </div>
            <button
              v-b-tooltip.hover
              title="Coming Soon"
              type="button"
              class="btn btn-sm btn-outline-secondary dropdown-toggle"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                stroke-width="2"
                stroke-linecap="round"
                stroke-linejoin="round"
                class="feather feather-calendar"
              >
                <rect x="3" y="4" width="18" height="18" rx="2" ry="2"></rect>
                <line x1="16" y1="2" x2="16" y2="6"></line>
                <line x1="8" y1="2" x2="8" y2="6"></line>
                <line x1="3" y1="10" x2="21" y2="10"></line>
              </svg>
              This week
            </button>
          </div>
        </div>

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
              <b-breadcrumb-item href="#foo">Produto</b-breadcrumb-item>
              <b-breadcrumb-item href="#bar" active
                >Criar Configuração</b-breadcrumb-item
              >
            </b-breadcrumb>
          </div>

          <b-card footer-tag="footer" title="Configurações de Produto">
            <b-card-text
              >Bem vindo a área gerencial do seu e-commerce. Abaixo você
              conseguirá visualizar as telas na qual será possível criar as
              categorias, subcategorias e classificação e vinculá-las.
              <p></p>
            </b-card-text>
          </b-card>
        </div>

        <!-- Accordion Starts -->
        <div role="tablist" class="accordion">
          <b-card no-body class="mb-1">
            <b-card-header
              header-tag="header"
              href="#"
              role="tab"
              v-b-toggle.accordion-1
            >
              <div style="display: flex; justify-content: space-between">
                <h5 class="mb-0">Categorias</h5>
                <b-icon icon="chevron-down" class="teste" />
              </div>
            </b-card-header>
            <b-collapse
              id="accordion-1"
              visible
              accordion="my-accordion"
              role="tabpanel"
            >
              <b-card-body>
                <b-card-text>
                  <div>
                    <p v-if="this.categoria.nome">
                      <b-alert
                        show
                        dismissible
                        variant="success"
                        class="alert-config-item"
                      >
                        <div
                          style="justify-content: space-between; display: flex"
                        >
                          <p>
                            Categoria
                            <strong>{{ this.categoria.nome }} </strong> foi
                            adicionado com sucesso !
                          </p>
                          <a href="#" style="font-size: 25px"
                            ><b-icon icon="trash"
                          /></a>
                        </div>
                      </b-alert>
                    </p>
                    <b-alert show dismissible variant="info">
                      <h4 class="alert-heading">Categorias</h4>
                      <hr />
                      <p>Explicar o que são categorias !</p>
                    </b-alert>
                  </div>
                  <div>
                    <form action="#" method="post" @submit="checkCategorias">
                      <p v-if="errorsCategoria.length">
                        <b-alert show dismissible variant="danger">
                          <b>Por favor, corrija o(s) seguinte(s) erro(s):</b>
                          <ul>
                            <li
                              v-for="(error, i) in errorsCategoria"
                              :key="i"
                              :error="error"
                            >
                              {{ error }}
                            </li>
                          </ul>
                        </b-alert>
                      </p>
                      <div class="input-form">
                        <div>
                          <label for="name">Nome: </label>
                          <b-form-input
                            name="name"
                            v-model="categoriaDTO.nome"
                            placeholder="Insira o nome da categoria"
                          ></b-form-input>
                        </div>
                      </div>

                      <p>
                        <b-button type="submit" variant="info"
                          >Criar Categoria</b-button
                        >
                      </p>
                    </form>
                  </div>
                </b-card-text>
              </b-card-body>
            </b-collapse>
          </b-card>

          <b-card no-body class="mb-1">
            <b-card-header
              header-tag="header"
              href="#"
              role="tab"
              v-b-toggle.accordion-2
            >
              <div style="display: flex; justify-content: space-between">
                <h5 class="mb-0">SubCategorias</h5>
                <b-icon icon="chevron-down" class="teste" />
              </div>
            </b-card-header>
            <b-collapse
              id="accordion-2"
              visible
              accordion="my-accordion"
              role="tabpanel"
            >
              <b-card-body>
                <b-card-text>
                  <div>
                    <p v-if="this.categoria.subcategorias">
                      <b-alert
                        show
                        dismissible
                        variant="success"
                        v-for="(sub, k) in this.categoria.subcategorias"
                        :key="k"
                        :sub="sub"
                        class="alert-config-item"
                      >
                        <div
                          style="justify-content: space-between; display: flex"
                        >
                          <p>
                            Subcategoria
                            <strong>{{ sub.text }} </strong>
                            foi adicionado com sucesso !
                          </p>
                          <a href="#" style="font-size: 25px"
                            ><b-icon icon="trash"
                          /></a>
                        </div>
                      </b-alert>
                    </p>
                    <b-alert show dismissible variant="info">
                      <h4 class="alert-heading">Subcategorias</h4>
                      <hr />
                      <p>Explicar o que são Subcategorias !</p>
                    </b-alert>
                  </div>
                  <div>
                    <form @submit.prevent="checkSubCategorias">
                      <p v-if="errorsSCategoria.length">
                        <b-alert show dismissible variant="danger">
                          <b>Por favor, corrija o(s) seguinte(s) erro(s):</b>
                          <ul>
                            <li
                              v-for="(error, i) in errorsSCategoria"
                              :key="i"
                              :error="error"
                            >
                              {{ error }}
                            </li>
                          </ul>
                        </b-alert>
                      </p>
                      <div class="input-form">
                        <div>
                          <label for="name">Nome: </label>
                          <b-form-input
                            name="name"
                            v-model="subcategoriasDTO.nome"
                            placeholder="Insira o nome da subcategoria"
                          ></b-form-input>
                        </div>
                      </div>

                      <p>
                        <b-button type="submit" variant="info"
                          >Criar Sub-Categoria</b-button
                        >
                      </p>
                    </form>
                  </div>
                </b-card-text>
              </b-card-body>
            </b-collapse>
          </b-card>

          <b-card no-body class="mb-1">
            <b-card-header
              header-tag="header"
              href="#"
              role="tab"
              v-b-toggle.accordion-3
            >
              <div style="display: flex; justify-content: space-between">
                <h5 class="mb-0">Classificação da categoria</h5>
                <b-icon icon="chevron-down" />
              </div>
            </b-card-header>
            <b-collapse
              id="accordion-3"
              visible
              accordion="my-accordion"
              role="tabpanel"
            >
              <b-card-body>
                <b-card-text>
                  <div>
                    <div v-if="this.categoria.subcategorias">
                      <div
                        v-for="(sub, k) in this.categoria.subcategorias"
                        :key="k"
                        :sub="sub"
                      >
                        <b-alert
                          show
                          dismissible
                          variant="success"
                          class="alert-config-item"
                          v-if="sub.classificacoes"
                        >
                          <div
                            style="
                              justify-content: space-between;
                              display: flex;
                            "
                          >
                            <p
                              v-for="(classf, l) in sub.classificacoes"
                              :key="l"
                              :classf="classf"
                            >
                              Classificação
                              <strong>{{ classf.nome }} </strong>
                              foi adicionada com sucesso !
                            </p>
                            <a href="#" style="font-size: 25px"
                              ><b-icon icon="trash"
                            /></a>
                          </div>
                        </b-alert>
                      </div>
                    </div>
                    <b-alert show dismissible variant="info">
                      <h4 class="alert-heading">Classificação da categoria</h4>
                      <hr />
                      <p>Explicar o que são Classificação da categoria !</p>
                    </b-alert>
                  </div>
                  <div>
                    <form @submit.prevent="checkClassificacoes">
                      <p v-if="errorsClassf.length">
                        <b-alert show dismissible variant="danger">
                          <b>Por favor, corrija o(s) seguinte(s) erro(s):</b>
                          <ul>
                            <li
                              v-for="(error, i) in errorsClassf"
                              :key="i"
                              :error="error"
                            >
                              {{ error }}
                            </li>
                          </ul>
                        </b-alert>
                      </p>
                      <div class="input-form">
                        <div class="input-form-item">
                          <label for="name">Nome: </label>
                          <b-form-input
                            name="name"
                            v-model="classificacoesDTO.nome"
                            placeholder="Insira o nome da sua classificação"
                          ></b-form-input>
                        </div>
                        <div
                          class="input-form-item"
                          v-if="categoria.subcategorias"
                        >
                          <label for="name">Sub-Categorias: </label>
                          <multi-select
                            :options="categoria.subcategorias"
                            :selected-options="items"
                            placeholder="Insira a sub-categoria"
                            @select="onSelectSelect"
                          >
                          </multi-select>
                        </div>
                      </div>

                      <p>
                        <b-button type="submit" variant="info"
                          >Criar Classificação</b-button
                        >
                      </p>
                    </form>
                  </div>
                </b-card-text>
              </b-card-body>
            </b-collapse>
          </b-card>
        </div>
        <!-- Accordion end -->

        <Loader v-if="loading" />
        <b-card no-body class="mb-1" style="padding-bottom: 65px">
          <b-card-header header-tag="header">
            <h5 class="mb-0">Registros Salvos</h5>
          </b-card-header>
          <b-card-body>
            <div>
              <vue-table-dynamic
                :params="params"
                @select="onSelect"
                @selection-change="onSelectionChange"
                ref="table"
              ></vue-table-dynamic>
            </div>
            <div class="row buttons-itens">
              <b-button @click="teste" variant="danger" class="btn-space"
                >Remover Itens Selecionados</b-button
              >
              <b-button @click="SalvarConfiguracao" variant="info" class="btn-space"
                >Salvar Alterações</b-button
              >
            </div>
          </b-card-body>
        </b-card>
      </main>
    </div>
  </div>
</template>

<script>
import Loader from "~/components/common/Loader";
import OrderPerson from "~/components/admin/OrderPerson";
import Sidebar from "~/components/admin/Sidebar";
import OperacaoAPI from "~/apis/OperacaoAPI";
import WorkAPI from "../../../apis/WorkAPI";
import HelperObjects from "~/helpers/ObjectsHelper";
import Table from "~/components/common/Tables/SimpleTable";
import { ModelSelect, ModelListSelect, MultiSelect } from "vue-search-select";

export default {
  layout: "admin",
  methods: {
    checkCategorias: function (e) {
      this.errorsCategoria = [];

      if (this.categoria.nome) {
        this.errorsCategoria.push(
          "Você já adicionou uma categoria anteriormente"
        );
      }

      if (this.categoriaDTO.nome && !this.categoria.nome) {
        this.categoria.nome = this.categoriaDTO.nome;
      }

      if (!this.categoriaDTO.nome) {
        this.errorsCategoria.push("É obrigatório a inclusão de um nome");
      }

      e.preventDefault();
    },
    checkSubCategorias: function (e) {
      this.errorsSCategoria = [];

      let bloqueia = false;
      if (
        this.categoria.subcategorias &&
        this.categoria.subcategorias.length > 0
      ) {
        this.categoria.subcategorias.forEach((element) => {
          if (
            element.text.trim().toUpperCase() ==
            this.subcategoriasDTO.nome.trim().toUpperCase()
          ) {
            bloqueia = true;
            this.errorsSCategoria.push(
              "Esta categoria já foi Inserida anteriormente"
            );
          }
        });
      }

      if (this.subcategoriasDTO.nome && this.categoria.nome && !bloqueia) {
        let id = 0;
        if (
          this.categoria.subcategorias &&
          this.categoria.subcategorias.length > 0
        ) {
          const newObj = {
            value: parseInt(this.categoria.subcategorias.length) + 1,
            text: this.subcategoriasDTO.nome,
          };

          this.categoria.subcategorias = [
            ...this.categoria.subcategorias,
            newObj,
          ];
        } else {
          this.categoria.subcategorias = [];
          this.categoria.subcategorias.push({
            value: parseInt(id) + 1,
            text: this.subcategoriasDTO.nome,
          });
        }
      }

      if (!this.subcategoriasDTO.nome) {
        this.errorsSCategoria.push(
          "Você deve passar um nome para a sub-categoria"
        );
      }
      if (!this.categoria.nome) {
        this.errorsSCategoria.push("Você ainda não criou uma categoria.");
      }

      e.preventDefault();
    },
    checkClassificacoes: function (e) {
      this.errorsClassf = [];

      let repetido = false;
      let subcategoriasValue = this.selected;

      if (
        subcategoriasValue.length > 0 &&
        this.categoria.subcategorias &&
        this.classificacoesDTO.nome
      ) {
        // Valida duplicata
        this.categoria.subcategorias.forEach((subcategoria, index) => {
          subcategoria.classificacoes?.forEach((classificacao) => {
            if (
              classificacao.nome.trim().toUpperCase() ==
              this.classificacoesDTO.nome.trim().toUpperCase()
            ) {
              repetido = true;
            }
          });
        });
        if (!repetido) {
          // Percore o array e adiciona em caso positivo
          this.categoria.subcategorias.forEach((subcategoria, index) => {
            subcategoriasValue.forEach((element) => {
              if (parseInt(element) == subcategoria.value) {
                if (
                  this.categoria.subcategorias[index].classificacoes?.length &&
                  this.categoria.subcategorias[index].classificacoes.length > 0
                ) {
                  this.categoria.subcategorias[index].classificacoes = [
                    ...this.categoria.subcategorias[index].classificacoes,
                    {
                      nome: this.classificacoesDTO.nome,
                    },
                  ];
                } else {
                  this.categoria.subcategorias[index].classificacoes = [];
                  this.categoria.subcategorias[index].classificacoes.push({
                    nome: this.classificacoesDTO.nome,
                  });
                }
              }
            });
          });
        }
      }

      if (repetido) {
        this.errorsClassf.push("A Classificação já foi inserida anteriormente");
      }
      if (subcategoriasValue.length == 0) {
        this.errorsClassf.push(
          "Você deve escolher ao menos uma subcategoria para prosseguir"
        );
      }
      if (!this.classificacoesDTO.nome) {
        this.errorsClassf.push("Você deve passar um nome para a classificação");
      }
      if (
        !this.categoria.nome ||
        (!this.categoria.subcategorias &&
          this.categoria.subcategorias.length == 0)
      ) {
        this.errorsClassf.push(
          "Você ainda não criou uma categoria e sub-categoria."
        );
      }

      e.preventDefault();
    },
    SalvarConfiguracao: async function (e) {
      this.loading = true;
      let parametros = this.categoria;

      this.errorsCategoria = [];
      this.errorsSCategoria = [];
      this.errorsClassf = [];
      this.categoria = {};
      this.subcategorias = [];
      this.classificacoes = [];
      this.categoriaDTO = {};
      this.subcategoriasDTO = {};
      this.classificacoesDTO = {};
      this.selected = [];

      await WorkAPI.Categoria.SalvarConfiguracao(
        parametros,
        () => {
          this.loading = false;
          this.$bvToast.toast(
            "O seu formulário foi enviado com sucesso e já inserimos as informações.",
            {
              title: `Sucesso !`,
              variant: "success",
              solid: true,
            }
          );
        },
        () => {
          this.loading = false;
          this.$bvToast.toast(
            "O sistema não esta operante neste momento, ou a categoria já está cadastrada em nosso sistema",
            {
              title: `Ocorreu um erro`,
              variant: "danger",
              solid: true,
            }
          );
        }
      );
    },
    onSelect(isChecked, index, data) {
    },
    onSelectionChange(checkedDatas, checkedIndexs, checkedNum) {
    },
    onSelectSelect(items, lastSelectItem) {
      this.items = items;
      this.lastSelectItem = lastSelectItem;
    },
    teste() {
      this.loading = true;
      this.loading = false;
    }
  },
  components: {
    OrderPerson,
    Loader,
    Sidebar,
    OperacaoAPI,
    Table,
    ModelSelect,
    ModelListSelect,
    MultiSelect,
  },
  data() {
    return {
      params: {
        data: [
          ["Tipo", "Nome"],
          ["Categoria", "Esportes"],
          ["SubCategoria", "Futebol"],
          ["Classificacao", "Chuteira"],
        ],
        header: "row",
        border: true,
        stripe: true,
        showCheck: true,
        enableSearch: true,
        sort: [0, 1, 2],
        pagination: true,
      },
      loading: true,
      errorsCategoria: [],
      errorsSCategoria: [],
      errorsClassf: [],
      categoria: {},
      subcategorias: [],
      classificacoes: [],
      categoriaDTO: {},
      subcategoriasDTO: {},
      classificacoesDTO: {},
      selected: [],
      searchText: "", // If value is falsy, reset searchText & searchItem
      items: [],
      lastSelectItem: {},
    };
  },
  mounted() {
    this.loading = false;
  },
};
</script>

<style lang="scss">
.btn-space {
    margin-right: 5px;
}

.buttons-itens {
  position: absolute;
  bottom: 8px;
  right: 16px;
  font-size: 15px;
}
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
.input-form-item {
  padding: 0px 0 9px 0px;
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