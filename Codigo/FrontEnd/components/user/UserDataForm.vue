<template>
  <div class="user-data-container">
    <b-card title="Dados Pessoais">
      <b-form @submit="onSubmit" @reset="onReset" v-if="show">
        <b-form-group id="input-group-1" label="Nome:">
          <b-form-input
            id="input-1"
            v-model="form.nomeUsuario"
            placeholder="Digite seu nome"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Email:" >
          <b-form-input
            id="input-2"
            v-model="form.email"
            type="email"
            placeholder="Digite seu Email"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-3" label="Senha:" >
          <b-form-input
            id="input-3"
            v-model="form.senha"
            placeholder="Nova senha"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-4" label="Data de nascimento:">
          <b-form-input
            id="input-4"
            v-model="form.dataNascimento"
            placeholder="Digite sua data de nascimento"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-5" label="Gênero: ">
          <b-form-input
            id="input-5"
            v-model="form.genero"
            placeholder="Digite seu gênero"
            required
          ></b-form-input>
        </b-form-group>

        <b-button type="submit" variant="success">Enviar</b-button>
      </b-form>
    </b-card>
  </div>
</template>

<script>
export default {
  data() {
    var user = this.$auth.state.user ? this.$auth.state.user : null
    return {
      user: user,
      form: {
        email: user.email,
        nomeUsuario: user.nomeUsuario,
        dataNascimento: "01/11/1997",
        senha: "",
        genero: "Masculino",
        checked: [],
      },
      show: true,
    };
  },
  methods: {
    onSubmit(event) {
      event.preventDefault();
    },
    onReset(){

    }
  },
  mounted() {},
}
</script>

<style>
.user-data-header {
  padding-bottom: 50px;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
}
.list-group {
  padding-bottom: 20px;
}
</style>