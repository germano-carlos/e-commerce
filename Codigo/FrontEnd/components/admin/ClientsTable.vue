<template>
  <div>
    <h1>{{ label }}</h1>
    <b-table
      :items="items"
      :fields="fields"
      selectable
      select-mode="single"
      @row-selected="onRowSelected"
    />
    <b-modal ref="my-modal" hide-footer title="Detalhes do usuário" size="xl">
      <b-card title="Endereços">
        <div>
          <b-table-lite
            :items="adresses"
            :fields="addressFields"
          ></b-table-lite>
        </div>
      </b-card>
      <b-card>
        <div>
          <b-button variant="outline-danger" @click="submitToBlackList"
            >Bloquear
          </b-button>
          <b-button variant="outline-success">Desbloquear</b-button>
        </div>
      </b-card>
    </b-modal>
  </div>
</template>

<script>
import WorkAPI from "../../apis/WorkAPI";

export default {
  props: ["label", "items"],
  methods: {
    onRowSelected(rowSelected) {
      this.selected = rowSelected;
      if (typeof rowSelected[0] != "undefined") {
        this.handleShowModal(rowSelected[0]?.usuarioId);
        this.showModal();
      }
    },
    submitToBlackList() {
      WorkAPI.Auth.adicionarClientesBacklist(this.selected);
    },
    showModal() {
      this.$refs["my-modal"].show();
    },
    hideModal() {
      this.$refs["my-modal"].hide();
    },
    async handleShowModal(userId) {
      // chamada de api com userId
      this.selected.enderecos = await WorkAPI.Logradouro.listarLogradourosPorUserId(
        { userId: userId },
        (data) => {
          this.adresses = data;
        },
        () => {

        }
      );
    },
  },
  data() {
    return {
      adresses: [],
      selected: {},
      fields: ["usuarioId", "nomeUsuario", "email", "StatusUsuario"],
      addressFields: [
        "rua",
        "bairro",
        "numero",
        "cep",
        "cidade",
        "estado",
        "complemento",
      ],
    };
  },
};
</script>
