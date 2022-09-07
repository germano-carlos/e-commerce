<template>
  <section class="login-area ptb-60 bg-gradient-default">
    <Loader v-if="loading" />
    <div class="container">
      <div class="row">
        <div class="d-flex align-items-center justify-content-center w-100">
          <div class="col-lg-6 col-md-12">
            <div class="login-content">
              <div class="section-title">
                <h2><span class="dot"></span> Recuperar senha</h2>
              </div>
              <div v-if="this.stage">
                <b-card>
                  <form class="login-form" @submit.prevent="RecuperarSenha">
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

                    <button type="submit" class="btn btn-primary">
                      Recuperar Senha
                    </button>

                    <nuxt-link to="/admin/auth/login" class="forgot-password"
                      >Já possui uma conta?</nuxt-link
                    >
                  </form>
                </b-card>
              </div>
              <div v-else>
                <b-card>
                  <form class="login-form" @submit.prevent="AlterarSenha">
                    <div class="form-group">
                      <label>Email</label>
                      <input
                        type="email"
                        class="form-control"
                        placeholder="Enter your name"
                        id="name"
                        name="name"
                        v-model="usuario.email"
                      />
                    </div>
                    <div class="form-group">
                      <label>Nova Senha</label>
                      <input
                        type="password"
                        class="form-control"
                        placeholder="Insira sua senha"
                        id="password"
                        name="password"
                        v-model="usuario.password"
                      />
                    </div>
                    <div class="form-group">
                      <label>Repetir Nova Senha</label>
                      <input
                        type="password"
                        class="form-control"
                        placeholder="Insira sua senha novamente"
                        id="password_repeat"
                        name="password_repeat"
                        v-model="usuario.password_repeat"
                      />
                    </div>

                    <button type="submit" class="btn btn-primary">
                      Recuperar Senha
                    </button>

                    <nuxt-link to="/admin/auth/login" class="forgot-password"
                      >Já possui uma conta?</nuxt-link
                    >
                  </form>
                </b-card>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

    
<script>
import Sidebar from "~/components/admin/Sidebar";
import Loader from "~/components/common/Loader";
import AuthAPI from "../../../apis/AuthAPI";

export default {
  layout: "admin",
  components: { Sidebar, Loader },
  methods: {
    RecuperarSenha() {
      if (!this.usuario.email) {
        this.$toast.error(
          "O email deve ser inserido para a devida recuperação de senha"
        );
        return;
      }

      let parametros = {
        email: this.usuario.email,
        urlRecuperar: "http://localhost:3000/admin/auth/recuperar-senha",
        TipoPermissao: 1
      };

      AuthAPI.Auth.recuperarSenha(
        parametros,
        () => {
          this.$toast.success("Email enviado com sucesso !");
        },
        () => {
          this.$toast.error("Usuário não encontrado !");
        }
      );
    },
    AlterarSenha() {
      if (
        !(
          this.usuario.email ||
          this.usuario.password ||
          this.usuario.password_repeat
        )
      ) {
        if (!this.usuario.email) {
          this.$toast.error("O endereço de email deve ser Obrigatório !");
        }
        if (!this.usuario.password) {
          this.$toast.error("A senha deve ser obrigatória !");
        }
        if (!this.usuario.password_repeat) {
          this.$toast.error("A validação da senha deve ser obrigatória !");
        }
        return;
      }

      if (this.usuario.password !== this.usuario.password_repeat) {
        this.$toast.error("As senhas devem ser coincidentes");
        return;
      }

      let parametros = {
        email: this.usuario.email,
        password: this.usuario.password,
        lastPassword: "",
        TipoPermissao: 1
      };

      AuthAPI.Auth.alterarSenha(
        parametros,
        () => {
          this.$toast.success("Senha atualizada com sucesso !");
        },
        () => {
          this.$toast.error("Usuário não encontrado ! ");
        }
      );
    },
  },
  head() {
    return {
      title: "Recuperar Senha - Portal Ecommerce",
    };
  },
  data() {
    return {
      loading: true,
      usuario: { email: null, password: null, password_repeat: null },
      stage: true,
    };
  },
  mounted() {
    this.loading = false;
    if (this.$route.query?.email && this.$route.query?.tokenTemp) {
      this.stage = false;
      var expiration = new Date(0);
      expiration.setUTCSeconds(this.$route.query?.tokenTemp);

      if (expiration < new Date()) {
        this.stage = true;
        this.$toast.error(
          "Link expirado, favor solicitar uma nova recuperação de senha"
        );
        this.$router.push("/admin/auth/recuperar-senha");
      }

      this.usuario.email = this.$route.query?.email;
    }
  },
  created() {
    if (this.$auth.loggedIn) this.$router.push("/admin");
  },
};
</script>

<style lang="scss">
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

.bg-gradient-default {
  background: linear-gradient(87deg, #b3c5e6 0, #6f69e4 100%) !important;
}
.bg-gradient-default {
  background: linear-gradient(87deg, #e9aeae 0, #8783ce 100%) !important;
}

.container {
  position: relative;
  padding-top: 15rem;
  padding-bottom: 16rem;
  height: 100%;
  align-items: center;
  align-self: center;
  justify-content: center;
}
</style>