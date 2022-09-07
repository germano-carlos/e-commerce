export default {
  // Global page headers: https://go.nuxtjs.dev/config-head
  head: {
    title: 'nuxttemplate',
    htmlAttrs: {
      lang: 'en'
    },
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: '' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }
    ]
  },
  auth: {
    strategies: {
      gerencial: {
        scheme: 'local',
        token: {
          property: 'token',
          // required: true,
          type: false,
          maxAge: 200000,
          name: 'TokenAuth'
        },
        refreshToken: false,
        user: {
          property: false
        },
        endpoints: {
          login: { url: `http://localhost:1858/api/v1/Auth/Logar`, method: 'post' },
          logout: false,
          refresh: false,
          user: { url: `http://localhost:1858/api/v1/Auth/ObterUsuarioLogado`, method: 'post' }
        }
      },
      usuario: {
        scheme: 'local',
        token: {
          property: 'token',
          type: false,
          maxAge: 200000,
          name: 'TokenAuth'
        },
        refreshToken: false,
        user: {
          property: false
        },
        endpoints: {
          login: { url: `http://localhost:1858/api/v1/Auth/Logar`, method: 'post' },
          logout: false,
          refresh: false,
          user: { url: `http://localhost:1858/api/v1/Auth/ObterUsuarioLogado`, method: 'post' }
        }
      }
    },
    redirect: {
      login: '/aaaaaaaaaaaaaaaaaaaaa',
      logout: '/',
      callback: false,
      home: '/admins'
    },
    plugins: ['~/helpers/HttpsHelper.js']
  },
  loading: { color: '#fff' },
 /*
  /*
  ** Global CSS
  */
  css: [
    './assets/scss/styles/animate.min.css',
    './assets/scss/styles/fontawesome.min.css',
    './assets/scss/styles/style.scss',
    './assets/scss/styles/admin.scss',
    './assets/scss/styles/responsive.scss',
    '@vueform/multiselect/themes/default.css',
  ],
  // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
  plugins: [
    { src: '~/plugins/vue-carousel', ssr: false },
    { src: '~/plugins/vue-backtotop', ssr: false },
    { src: '~/plugins/vue-toastification', ssr: false },
    { src: '~/plugins/vueperslides', ssr: false },
    { src: '~/plugins/vue-bootstrap-icons', ssr: false },
    { src: '~/plugins/vue-bootstrap-pagination', ssr: false },
    { src: '~/plugins/vue-datatable', ssr: false },
    { src: '~/plugins/vue-select', ssr: false },
    { src: "~/plugins/vue-editor", ssr: false},
    { src: "~/plugins/vue-dropzone", ssr: false},
    { src: "~/plugins/vue-checkbox", ssr: false},
  ],
  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
  buildModules: [
    // https://go.nuxtjs.dev/eslint
    '@nuxtjs/composition-api'
  ],

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: [
    // https://go.nuxtjs.dev/bootstrap
    'bootstrap-vue/nuxt',
    // https://go.nuxtjs.dev/axios
    '@nuxtjs/axios',
    //https://auth.nuxtjs.org/guide/setup/#installation
    '@nuxtjs/auth-next'
  ],

  // Axios module configuration: https://go.nuxtjs.dev/config-axios
  axios: {},

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {
    transpile: ['@nuxtjs/composition-api', '@vueform/multiselect/dist/multiselect.vue2', '@vueform/multiselect', '@vueform'],
  }
}
