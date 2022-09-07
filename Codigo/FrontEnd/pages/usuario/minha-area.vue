<template>
  <!-- Main content -->
  <div class="main-content" id="panel">
    <div
      class="header pb-6 d-flex align-items-center"
      style="
        min-height: 150px;
        background-size: cover;
        background-position: center top;
      "
    >
      <!-- Mask -->
      <span class="mask bg-gradient-default opacity-8"></span>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
      <div class="row" style="margin-top: 25px">
        <div class="col-xl-4 order-xl-2">
          <div class="card card-profile">
            <b-img
              src="../../static/carlos-2.jpg"
              alt="Image placeholder"
              class="card-img-top"
            />
            <div class="row justify-content-center">
              <div class="col-lg-3 order-lg-2">
                <div class="card-profile-image">
                  <a href="#">
                    <b-img
                      src="../../static/carlos-2.jpg"
                      class="rounded-circle"
                    />
                  </a>
                </div>
              </div>
            </div>
            <div
              class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4"
            >
              <div class="d-flex justify-content-between"></div>
            </div>
            <div class="card-body pt-0">
              <div class="row">
                <div class="col">
                  <div
                    class="card-profile-stats d-flex justify-content-center"
                  ></div>
                </div>
              </div>
              <div class="text-center">
                <h5 class="h3">
                  {{ this.getMyUsername
                  }}<span class="font-weight-light">, 21</span>
                </h5>
                <div class="h5 font-weight-300">
                  <b-icon icon="geo-fill" /> Belo Horizonte, Minas Gerais
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-xl-8 order-xl-1">
          <!-- TODO adicionar-->
          <div class="card">
            <div class="card-body">
              <UserDataForm />
            </div>
          </div>

          <div class="card">
            <div class="card-body">
              <UserAdresses />
            </div>
          </div>

          <div class="card">
            <div class="card-header">
              <div class="row align-items-center">
                <div class="col-8">
                  <h3 class="mb-0">Meus Pedidos</h3>
                </div>
              </div>
            </div>
            <div class="card-body">
              <Datatable
                :items="pedidos"
                :fields="keyFields"
                @onRowClicked="rowClicked"
                v-bind:loading="tableLoading"
              />

              <PedidoModal ref="pedido_modal" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import UserDataForm from "../../components/user/UserDataForm.vue";
import AddressCard from "../../components/user/AddressCard.vue";
import UserAddresses from "../../components/user/UserAdresses";
import PedidoModal from "../../components/modals/PedidoModal.vue";
import Datatable from "../../components/admin/Datatable.vue";
import WorkAPI from "../../apis/WorkAPI";

export default {
  components: {
    PedidoModal,
    Datatable,
    UserDataForm,
    AddressCard,
    UserAddresses,
  },

  data() {
    return {
      tableLoading: true,
      pedidos: [],
      keyFields: [
        { key: "fatura_id", label: "#", sortable: true },
        { key: "data_criacao", label: "Data", sortable: true },
        { key: "destinatario", label: "Destinatário", sortable: false },
        { key: "total", label: "R$", sortable: true },
        { key: "status", label: "Status", sortable: false },
      ],
    };
  },
  mounted() {
    this.ajaxRequestPedidos();
  },
  methods: {
    ajaxRequestPedidos() {
      WorkAPI.Pedido.getMyPedidos(
        null,
        (data) => {
          let user_nome = this.$auth.$state.user.nomeUsuario;

          if (user_nome && user_pedidos) {
            data.forEach((p) => {
              this.pedidos.push({
                fatura_id: p.Pedido.pedidoId,
                data_criacao: p.Pedido.dataInclusao,
                destinatario: user_nome,
                total: "R$ 80.00",
                status: p.Pedido.StatusPedido,
              });
            });
          }

          this.tableLoading = false;
        },
        () => {
          this.tableLoading = false;
        }
      );

      let user_pedidos = this.$auth.$state.user.pedidos;
    },
    ajaxRequestPedidoInfo(pedido) {
      this.tableLoading = true;

      // simulate request timeout
      setTimeout(() => {
        // fake responde data :)
        let produtos = [
          {
            nome: "Nike Air Max 100",
            qtd: 1,
            preco: 30.0,
          },
          {
            nome: "Camisa Social",
            qtd: 1,
            preco: 50.0,
          },
        ];

        let pedido_info = {
          subtotal: 80.0,
          desconto: 0,
          frete: 30,
          total: 110,
          status: 3,
        };

        let user_endereco = {
          destinatario: "Andre Murilo",
          rua: "Rua Teste",
          bairro: "Bairro Teste",
          numero: 300,
          cidade: "Belo Horizonte",
          estado: "Minas Gerais",
          cep: 320980210,
        };

        // open modal
        this.tableLoading = false;
        this.$refs.pedido_modal.show(produtos, pedido_info, user_endereco);
      }, 400);
    },
    rowClicked(row) {
      this.ajaxRequestPedidoInfo(row);
    },
  },
  computed: {
    getMyUsername() {
      let user = this.$auth.$state.user?.nomeUsuario;
      if (user) return user;
      else return "";
    },
  },
};
</script>
<style lang="css" scoped>
html,
body,
div,
span,
applet,
object,
iframe,
h1,
h2,
h3,
h4,
h5,
h6,
p,
blockquote,
pre,
a,
abbr,
acronym,
address,
big,
cite,
code,
del,
dfn,
em,
img,
ins,
kbd,
q,
s,
samp,
small,
strike,
b,
sub,
sup,
tt,
var,
b,
u,
i,
center,
dl,
dt,
dd,
ol,
ul,
li,
fieldset,
form,
label,
legend,
table,
caption,
tbody,
tfoot,
thead,
tr,
th,
td,
article,
aside,
canvas,
details,
embed,
figure,
figcaption,
footer,
header,
hgroup,
menu,
nav,
output,
ruby,
section,
summary,
time,
mark,
audio,
video {
  margin: 0;
  padding: 0;
  border: 0;
  font-size: 100%;
  font: inherit;
  vertical-align: baseline;
}
/* HTML5 display-role reset for older browsers */
article,
aside,
details,
figcaption,
figure,
footer,
header,
hgroup,
menu,
nav,
section {
  display: block;
}
body {
  line-height: 1;
}
ol,
ul {
  list-style: none;
}
blockquote,
q {
  quotes: none;
}
blockquote:before,
blockquote:after,
q:before,
q:after {
  content: "";
  content: none;
}
table {
  border-collapse: collapse;
  border-spacing: 0;
}
</style>
<style src="../../assets/scss/styles/second-template/style.css" scoped></style>