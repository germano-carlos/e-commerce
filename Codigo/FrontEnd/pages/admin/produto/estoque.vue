<template>
  <div class="container-fluid">
    <div class="row">
      <Sidebar selected="produtos-gerenciar" />
      <main role="main" class="col-md-12 ml-sm-auto col-lg-10 px-4">
        <div
          class="d-md-flex d-lg-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom"
        >
          <h1 class="h2">Gerenciar Produtos</h1>
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
                >Gerenciar Produtos</b-breadcrumb-item
              >
            </b-breadcrumb>
          </div>

          <b-card footer-tag="footer" title="Estoque">
            <b-card-text
              >Bem vindo a área gerencial do seu e-commerce. Abaixo você
              conseguirá fazer a gestão de estoque de produtos previamente
              cadastrados.
              <p></p>
            </b-card-text>
          </b-card>
        </div>

        <Datatable
          :items="produtos"
          :fields="keyFields"
          @onRowClicked="rowClicked"
          :filterCallback="filterSearch"
          v-bind:loading="tableLoading"
        />

        <b-modal
          ref="stock-modal"
          title="Controle de estoque"
          @ok="changeHandler"
        >
          <label for="stock-spin">{{productSelected.name}}</label>
          <b-form-spinbutton
            id="stock-spin"
            min="0"
            max="100000"
            step="1"
            v-model="value"
            @change="value = $event"
          ></b-form-spinbutton>
        </b-modal>

        <Loader v-if="loading" />
      </main>
    </div>
  </div>
</template>

<script>
import Loader from "~/components/common/Loader";
import OrderPerson from "~/components/admin/OrderPerson";
import Sidebar from "~/components/admin/Sidebar";
import Datatable from "../../../components/admin/Datatable";

export default {
  props: [],
  layout: "admin",
  methods: {
    changeHandler() {
      for (let produto of this.produtos) {
        if (produto.nome_produto == this.productSelected.name) {
          produto.quantidade = this.value;
        }
      }
    },
    rowClicked(row) {
      this.handleShowModal(row);
    },
    filterSearch(elements, search_param) {
      return elements.filter((e) => {
        return e.nome_produto.toLowerCase().includes(search_param);
      });
    },
    handleShowModal(row) {
      this.productSelected.amount = row.quantidade;
      this.productSelected.name = row.nome_produto;
      this.value = row.quantidade;
      this.showModal();
    },
    showModal() {
      this.$refs["stock-modal"].show();
    },
    hideModal() {
      this.$refs["stock-modal"].hide();
    },
    toggleModal() {
      // We pass the ID of the button that we want to return focus to
      // when the modal has hidden
      this.$refs["stock-modal"].toggle("#toggle-btn");
    },
  },
  components: {
    OrderPerson,
    Loader,
    Sidebar,
    Datatable,
  },
  data() {
    return {
      productSelected: {
        name: "0",
        amount: 0,
      },
      value: 0,
      loading: true,
      tableLoading: true,
      produtos: [
        {
          id: 1,
          nome_produto: "Nike - Tênis",
          data_criacao: "14/04/2021 02:57:57",
          data: "14/04/2021 02:57:57",
          quantidade: 30,
        },
        {
          id: 2,
          nome_produto: "Adidas - Camisa Cruzeiro",
          data_criacao: "14/04/2021 02:57:57",
          data: "14/04/2021 02:57:57",
          quantidade: 40,
        },
        {
          id: 3,
          nome_produto: "Puma - Tênis Basquete",
          data_criacao: "14/04/2021 02:57:57",
          data: "14/04/2021 02:57:57",
          quantidade: 23,
        },
        {
          id: 4,
          nome_produto: "Nike - Air Max",
          data_criacao: "14/04/2021 02:57:57",
          data: "14/04/2021 02:57:57",
          quantidade: 12,
        },
        {
          id: 5,
          nome_produto: "Patins - Criança 11 anos",
          data_criacao: "14/04/2021 02:57:57",
          data: "14/04/2021 02:57:57",
          quantidade: 5,
        },
      ],
      keyFields: [
        { key: "id", label: "ID", sortable: true },
        { key: "nome_produto", label: "Nome Produto", sortable: true },
        { key: "data_criacao", label: "Data Inclusão", sortable: true },
        { key: "quantidade", label: "Quantidade", sortable: true },
      ],
    };
  },
  mounted() {
    (this.loading = false), (this.tableLoading = false);
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