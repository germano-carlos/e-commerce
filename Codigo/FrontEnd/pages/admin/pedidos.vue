<template>
  <div class="container-fluid">
    <div class="row">
      <Sidebar selected="pedidos" />
      <main role="main" class="col-md-12 ml-sm-auto col-lg-10 px-4">
        <div class="d-md-flex d-lg-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
          <h1 class="h2">
            Dashboard
          </h1>
          <div class="btn-toolbar">
            <div class="btn-group mr-2">
              <button v-b-tooltip.hover title="Coming Soon" type="button" class="btn btn-sm btn-outline-secondary">
                Share
              </button>
              <button v-b-tooltip.hover title="Coming Soon" type="button" class="btn btn-sm btn-outline-secondary ml-2">
                Export
              </button>
            </div>
            <button v-b-tooltip.hover title="Coming Soon" type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
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
              ><rect
                x="3"
                y="4"
                width="18"
                height="18"
                rx="2"
                ry="2"
              /><line x1="16" y1="2" x2="16" y2="6" /><line x1="8" y1="2" x2="8" y2="6" /><line x1="3" y1="10" x2="21" y2="10" /></svg>
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
              <b-breadcrumb-item href="#foo">Pedidos</b-breadcrumb-item>
            </b-breadcrumb>
          </div>

          <b-card footer-tag="footer" title="Pedidos">
            <b-card-text
              >Bem vindo a área gerencial do seu e-commerce. Abaixo você
              conseguirá visualizar as telas na qual será possível gerenciar as informações relacionadas aos pedidos.
              <p></p>
            </b-card-text>
          </b-card>
        </div>

        <Datatable 
          :items="pedidos"
          :fields="keyFields"
          @onRowClicked="rowClicked"
          :filterCallback="filterSearch"
          v-bind:loading="tableLoading"
         />

        <Loader v-if="loading" />
      </main>
    </div>
  </div>
</template>

<script>
import Loader from '../../components/common/Loader'
import Sidebar from '../../components/admin/Sidebar'
import AuthAPI from '../../apis/AuthAPI/'
import Datatable from '../../components/admin/Datatable.vue'

export default {
  components: {
    Loader,
    Sidebar,
    Datatable
  },
  layout: 'admin',
  data () {
    return {
      tableLoading: true,
      pedidos: [
        {
            fatura_id: 1,
            nome_cliente: "lucas",
            data_criacao: "5/3/2021",
            total: "R$37,00",
            status: "PAGO"
        },
        {
            fatura_id: 2,
            nome_cliente: "Carlos",
            data_criacao: "8/3/2021",
            total: "R$84,00",
            status: "CANCELADO"
        },
        {
            fatura_id: 3,
            nome_cliente: "Fabiano",
            data_criacao: "12/3/2021",
            total: "R$65,00",
            status: "PAGO"
        },
        {
            fatura_id: 4,
            nome_cliente: "josue",
            data_criacao: "18/3/2021",
            total: "R$28,00",
            status: "PAGO"
        },
        {
            fatura_id: 5,
            nome_cliente: "caio",
            data_criacao: "25/3/2021",
            total: "R$147,00",
            status: "CANCELADO"
        },
        {
            fatura_id: 6,
            nome_cliente: "Rodrigo",
            data_criacao: "28/3/2021",
            total: "R$63,00",
            status: "PAGO"
        },
        {
            fatura_id: 7,
            nome_cliente: "Fernando",
            data_criacao: "3/4/2021",
            total: "R$48,00",
            status: "PENDENTE"
        }
      ],
      keyFields: [
          {key: "fatura_id", label: "Fatura", sortable: true},
          {key: "nome_cliente", label: "Nome Cliente", sortable: true},
          {key: "data_criacao", label: "Data de Criação", sortable: true},
          {key: "total", label: "Preço Total", sortable: true},
          {key: "status", label: "Status Pedido", sortable: true}
      ],
    }
  },
  mounted () {
    this.loading = false,
    this.tableLoading = false;
  },
  methods: {
    rowClicked(row) {

    },
    filterSearch(elements, search_param) {
      return elements.filter((e) => {
          return e.nome_cliente.toLowerCase().includes(search_param);
      });
    }
  }
}
</script>

<style lang="scss">

.preloader-loading {
    position: fixed;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    text-align: center;
    background-color: rgba(0,0,0,.66);
    z-index: 999;

    .loader {
        position: absolute;
        top: 50%;
        transform: translateX(-50%) translateY(-50%);
        left: 50%;
        color: #fff;
    }
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

                a, button {
                    display: block;
                    background-color: #f2f2f2;
                    color: #000000;
                    padding: 5px 15px;
                    border: none;
                    transition: .5s;

                    &:hover {
                        background-color: #000000;
                        color: #fff;
                    }
                }
                &:nth-child(2) {
                    a, button {
                        &:hover {
                            background-color: red;
                            color: #fff;
                        }
                    }
                }
                &:nth-child(3) {
                    a, button {
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

.breadcrumb-item a {
  display: inline;
}

/*
 * Content
 */
// [role="main"] {
//   padding-top: 133px; /* Space for fixed navbar */
// }

@media (min-width: 768px) {
  [role="main"] {
    padding-top: 48px; /* Space for fixed navbar */
  }
}

</style>
