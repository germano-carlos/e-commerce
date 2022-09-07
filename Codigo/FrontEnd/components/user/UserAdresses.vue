<template>
  <b-card title="Endereços" >
    <b-card-group>
      <div v-for="address in addresses" v-bind:key="address.id">
        <AddressCard v-on:address-deleted="onDelete" :title="address.apelido" :data="address" v-on:address-change="handleChange"/>
      </div>
    </b-card-group>
  </b-card>
</template>
<script>
import WorkAPI from "../../apis/WorkAPI";
import AddressCard from "../../components/user/AddressCard";
import AddressForm from "../../components/modals/AddressForm";
export default {
  components: {
    AddressCard,
    AddressForm,
  },
  mounted() {
    this.fetchData(this.$auth.state.user.usuarioId);
  },
  methods: {
    async fetchData(userId) {
      await WorkAPI.Logradouro.listarLogradourosPorUserId(
        { userId: userId },
        (data) => {
          this.addresses = data;
        },
        () => {}
      )
    },
    onDelete(){
      this.fetchData(this.$auth.state.user.usuarioId)
    },
    handleChange(){
      this.fetchData(this.$auth.state.user.usuarioId)
    }
  },
  data() {
    return {
      addresses: [],
    };
  },
};
</script>