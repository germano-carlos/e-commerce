<template>
  <div class="address-card">
    <b-card :title="title">
      <b-list-group>
        <b-list-group-item
          ><strong>Rua: </strong>{{ data.rua }}</b-list-group-item
        >
        <b-list-group-item
          ><strong>Bairro: </strong>{{ data.bairro }}</b-list-group-item
        >
        <b-list-group-item
          ><strong>Numero: </strong>{{ data.numero }}</b-list-group-item
        >
        <b-list-group-item
          ><strong>CEP: </strong>{{ data.cep }}</b-list-group-item
        >
        <b-list-group-item
          ><strong>Cidade: </strong>{{ data.cidade }}</b-list-group-item
        >
      </b-list-group>
      <b-button @click="showModal">Alterar</b-button>
      <b-button v-on:click="handleDelete" variant="danger"
        >Excluir</b-button
      >
    </b-card>
    <b-modal
      ref="address-form-modal"
      title="Alterar dados de endereço"
      size="l"
      :hide-footer="true"
    >
      <AddressForm :data="data" v-on:submit="$emit('address-change')"/>
    </b-modal>
  </div>
</template>
<script>
import WorkAPI from "../../apis/WorkAPI";
import AddressForm from "../../components/modals/AddressForm";
export default {
  components: {
    AddressForm,
  },
  props: ["title", "data"],
  data() {
    return {};
  },
  methods: {
    showModal() {
      this.$refs["address-form-modal"].show();
    },
    async handleDelete() {
      await WorkAPI.Logradouro.deletarLogradouro(
        { id: this.data.logradouroId },
        (data) => {
          this.$toast.success("Seu endereço foi removido com sucesso !");
        },
        (error) => {
          this.$toast.success("Não conseguimos remover seu endereço, tente novamente mais tarde !");
        }
      );
      this.$emit("address-deleted");
    },
  },
};
</script>
<style>
.address-card {
  padding: 20px;
}
</style>