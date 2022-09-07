<template>
  <div>
    <Loader v-if="loading" />
    <div class="page-title-area">
      <div class="container">
        <ul>
          <li><nuxt-link to="/">Signup</nuxt-link></li>
          <li>404 Not Found</li>
        </ul>
      </div>
    </div>

    <section class="signup-area ptb-60">
      <div class="container">
        <div class="signup-content">
          <div class="section-title">
            <h2><span class="dot"></span> Criar uma nova conta</h2>
          </div>

          <form class="signup-form" @submit.prevent="Cadastrar">
            <div class="form-group">
              <label>Nome Completo</label>
              <input
                type="text"
                class="form-control"
                placeholder="Insira seu Nome Completo"
                id="fname"
                name="fname"
                v-model="usuario.nome"
              />
            </div>

            <div class="form-group">
              <label>Email</label>
              <input
                type="email"
                class="form-control"
                placeholder="Insira seu email"
                id="name"
                name="name"
                v-model="usuario.email"
              />
            </div>

            <div class="form-group">
              <label>Senha</label>
              <input
                type="password"
                class="form-control"
                placeholder="Insira sua senha"
                id="password"
                name="password"
                v-model="usuario.senha"
              />
            </div>

            <div class="form-group">
              <label>Confirme sua senha</label>
              <input
                type="password"
                class="form-control"
                placeholder="Insira sua senha novamente"
                id="password-repeat"
                name="password-repeat"
                v-model="usuario.senha_repeat"
              />
            </div>

            <button type="submit" class="btn btn-primary">
              Criar Cadastro
            </button>

            <nuxt-link to="/" class="return-store"
              >ou Retorne para a Loja</nuxt-link
            >
          </form>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import Loader from "../layouts/SiteLoder";
import WorkAPI from "../apis/WorkAPI";

export default {
  components: { Loader },
  data() {
    return {
      loading: true,
      usuario: {
        email: null,
        senha: null,
        nome: null,
        senha_repeat: null,
        TipoPermissao: 2,
      },
    };
  },
  head() {
    return {
      title: "Cadastro",
    };
  },
  mounted() {
    this.loading = false;
  },
  created() {
    //this.$auth.logout();
    if (
      this.$auth.loggedIn &&
      this.$auth.strategy.options.name === "gerencial"
    ) {
      this.$auth.logout();
    } else if (
      this.$auth.loggedIn &&
      this.$auth.strategy.options.name === "usuario"
    ) {
      this.$router.push("/minha-area");
    }
  },
  methods: {
    Cadastrar(e) {
      this.loading = true;
      if (
        !(
          this.usuario.email &&
          this.usuario.senha &&
          this.usuario.nome &&
          this.usuario.senha_repeat
        )
      ) {
        this.loading = false;
        if (!this.usuario.email) {
          this.$toast.error("Email Inválido, favor inserir novamente");
          return;
        }
        if (!this.usuario.senha) {
          this.$toast.error("Senha Inválida, favor inserir novamente");
          return;
        }
        if (!this.usuario.nome) {
          this.$toast.error("Nome Inválido, favor inserir novamente");
          return;
        }
        if (!this.usuario.senha_repeat) {
          this.$toast.error(
            "Repetição de senha inválida, favor inserir novamente"
          );
          return;
        }
      }

      if (this.usuario.senha !== this.usuario.senha_repeat) {
        this.loading = false;
        this.$toast.error("As senhas devem ser coincidentes");
        return;
      }

      WorkAPI.Auth.criarUsuario(this.usuario, (data) => {
        this.$toast.success("Usuario criado com sucesso, você será redirecionado");

        let formData = new FormData();
        formData.append("email", this.usuario.email);
        formData.append("senha", this.usuario.senha);
        formData.append("TipoPermissao", 2);

        this.$auth
          .loginWith("usuario", {
            data: formData,
          })
          .then((response) => {
            if (response && response.status === 200 && response.data) {
              this.$auth.setUser(response.data);
              if (this.$auth.loggedIn) {
                this.$router.push("/minha-area");
              }
            }
          });

      });

      this.loading = false;
    },
  },
};
</script>
