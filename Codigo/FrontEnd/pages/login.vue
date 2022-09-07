<template>
  <div>
    <Loader v-if="loading" />
    <div class="page-title-area">
      <div class="container">
        <ul>
          <li><nuxt-link to="/">Home</nuxt-link></li>
          <li>Login</li>
        </ul>
      </div>
    </div>

    <section class="login-area ptb-60">
      <div class="container">
        <div class="row">
          <div class="col-lg-6 col-md-12">
            <div class="login-content">
              <div class="section-title">
                <h2><span class="dot"></span> Login</h2>
              </div>

              <form class="login-form" @submit.prevent="Logar">
                <div class="form-group">
                  <label>Email</label>
                  <input
                    type="email"
                    class="form-control"
                    placeholder="Insira seu nome"
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

                <button type="submit" class="btn btn-primary">Login</button>

                <nuxt-link to="/" class="forgot-password"
                  >Esqueceu sua senha?</nuxt-link
                >
              </form>
            </div>
          </div>

          <div class="col-lg-6 col-md-12">
            <div class="new-customer-content">
              <div class="section-title">
                <h2><span class="dot"></span> Novo Cliente</h2>
              </div>

              <span>Crie uma conta</span>
              <p>
                Se cadastre gratuitamente em nosso e-commerce. Se registrar é
                rápido e facíl. Isso permitirá que você seja capaz de comprar
                pela nossa loja online. Para iniciar suas compras, clique para
                se cadastrar.
              </p>
              <nuxt-link to="/signup" class="btn btn-light"
                >Criar uma Conta</nuxt-link
              >
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import Loader from "../layouts/SiteLoder";

export default {
  components: { Loader },
  data() {
    return {
      loading: true,
      usuario: { email: null, senha: null },
    };
  },
  head() {
    return {
      title: "Login",
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
      this.$router.push("/usuario/minha-area");
    }
  },
  methods: {
    Logar(e) {
      this.loading = true;
      if (!(this.usuario.email && this.usuario.senha)) {
        this.loading = false;
        if (!this.usuario.email) {
          this.$toast.error("Email Inválido, favor inserir novamente");
          return;
        }
        if (!this.usuario.senha) {
          this.$toast.error("Senha Inválida, favor inserir novamente");
          return;
        }
      }

      const formData = new FormData();
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
              this.$router.push("/usuario/minha-area");
            }
          } else if (
            response &&
            response.status === 200 &&
            response.data == null
          ) {
            this.$toast.error("Falha de Login. Usuário ou senha inválidos!");
          }
        });

      this.loading = false;
    },
  },
};
</script>

