<template>
  <section class="login-area ptb-60 bg-gradient-default">
    <Loader v-if="loading" />
    <div class="container">
      <div class="row">
        <div
          class="d-flex align-items-center justify-content-center w-100"
        >
          <div class="col-lg-6 col-md-12">
            <div class="login-content">
              <div class="section-title">
                <h2><span class="dot" /> Login</h2>
              </div>

              <b-card>
                <form class="login-form" @submit.prevent="Logar">
                  <div class="form-group">
                    <label>Email</label>
                    <input
                      id="name"
                      v-model="usuario.email"
                      type="email"
                      class="form-control"
                      placeholder="Enter your name"
                      name="name"
                    >
                  </div>

                  <div class="form-group">
                    <label>Password</label>
                    <input
                      id="password"
                      v-model="usuario.senha"
                      type="password"
                      class="form-control"
                      placeholder="Enter your password"
                      name="password"
                    >
                  </div>

                  <button type="submit" class="btn btn-primary">
                    Login
                  </button>

                  <nuxt-link
                    to="/admin/auth/recuperar-senha"
                    class="forgot-password"
                  >
                    Esqueceu a senha?
                  </nuxt-link>
                </form>
              </b-card>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import Loader from '~/components/common/Loader';

export default {
  components: { Loader },
  layout: 'admin',
  data () {
    return {
      loading: true,
      usuario: { email: null, senha: null }
    }
  },
  head () {
    return {
      title: 'Login - Portal Ecommerce'
    }
  },
  mounted () {
    this.loading = false
  },
  created () {
    if (this.$auth.loggedIn) { this.$router.push('/admin') }
  },
  methods: {
    Logar (e) {
      this.loading = true
      if (!(this.usuario.email && this.usuario.senha)) {
        this.loading = false
        if (!this.usuario.email) {
          this.$toast.error('Email Inválido, favor inserir novamente')
          return
        }
        if (!this.usuario.senha) {
          this.$toast.error('Senha Inválida, favor inserir novamente')
          return
        }
      }

      const formData = new FormData()
      formData.append('email', this.usuario.email)
      formData.append('senha', this.usuario.senha)
      formData.append("TipoPermissao", 1);

      this.$auth
        .loginWith('gerencial', {
          data: formData
        })
        .then((response) => {
          if (response && response.status === 200 && response.data) {
            if (response?.data.TipoPermissao === 1) {
              this.$auth.setUser(response.data)
              if (this.$auth.loggedIn) { this.$router.push('/admin') }
            } else {
              this.$auth.logout().then(() => {
                this.$router.push('/admin/auth/login')
                this.$toast.error('Usuário não permitido !')
              })
            }
          } else if (
            response &&
            response.status === 200 &&
            response.data == null
          ) {
            this.$toast.error('Falha de Login. Usuário ou senha inválidos!')
          }
        }) 

      this.loading = false
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
