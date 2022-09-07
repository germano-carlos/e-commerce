<template>
  <b-card :title="data.apelido">
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group id="input-group-1" label="Rua:">
        <b-form-input
          id="input-1"
          v-model="form.rua"
          placeholder="Digite sua rua"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Bairro:">
        <b-form-input
          id="input-2"
          v-model="form.bairro"
          placeholder="Digite seu bairro"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Numero:">
        <b-form-input
          id="input-3"
          v-model="form.numero"
          placeholder="Digite o número"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-4" label="CEP:">
        <b-form-input
          id="input-4"
          v-model="form.cep"
          placeholder="Digite o CEP"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-5" label="Cidade: ">
        <b-form-input
          id="input-5"
          v-model="form.cidade"
          placeholder="Digite a cidade"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-6" label="Estado: ">
        <b-form-input
          id="input-6"
          v-model="form.estado"
          placeholder="Digite o estado"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-7" label="Complemento: ">
        <b-form-input
          id="input-7"
          v-model="form.complemento"
          placeholder="Digite o complemento"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-8" label="UF: ">
        <b-form-input
          id="input-8"
          v-model="form.uf"
          placeholder="Digite a UF"
          required
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-9" label="Apelido: ">
        <b-form-input
          id="input-9"
          v-model="form.apelido"
          placeholder="Digite o apelido do endereco"
          required
        ></b-form-input>
      </b-form-group>

      <b-button type="submit" variant="success">Enviar</b-button>
    </b-form>
  </b-card>
</template>
<script>
import WorkAPI from '../../apis/WorkAPI'
export default {
  props: ["data"],
  data() {
    var user = this.$auth.state.user ? this.$auth.state.user : null;
    return {
      user: user,
      form: {
        logradouroId: this.data.logradouroId,
        rua: this.data.rua,
        bairro: this.data.bairro,
        numero: this.data.numero,
        cep: this.data.cep,
        cidade: this.data.cidade,
        estado: this.data.estado,
        complemento: this.data.complemento,
        uf: this.data.uf,
        apelido: this.data.apelido
      },
      show: true,
    };
  },
  methods: {
    async onSubmit(event) {
      event.preventDefault();
      await WorkAPI.Logradouro.atualizarLogradouro(this.form,()=>{},()=> {})
      this.$emit('submit');
    },
    onReset() {},
  },
  mounted() {},
};
</script>