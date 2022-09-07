<template>
  <div class="sidebar-sticky side-bar">
    <b-nav vertical>
      <b-img src="../../static/logo.png" class="p-4"></b-img>
      <b-nav-item
        v-for="(item, index) in items"
        :key="index"
        :to="item.children ? '#' : item.to"
        v-b-toggle="item.children ? `collapse-${index}` : ''"
        :active="selected && item.id === selected && true"
      >
        <b-icon :icon="item.icon" />
        <span> {{ item.title }}</span>
        <div v-if="item.children">
          <b-collapse
            :id="`collapse-${index}`"
            :class="item.children ? 'sub-menu' : ''"
          >
            <b-nav-item
              v-for="(subItem, suIndex) in item.children"
              :key="suIndex"
              :to="subItem.to"
              :active="selected && subItem.id === selected && true"
            >
              <b-icon :icon="subItem.icon" />
              <span> {{ subItem.title }}</span>
            </b-nav-item>
          </b-collapse>
        </div>
      </b-nav-item>
    </b-nav>
    <div class="footer">
      <b-media>
        <template #aside>
          <b-img src="../../static/carlos.jpg"></b-img>
        </template>
        <div class="d-flex align-items-center">
          <section>
            <strong class="mt-0 d-block">Carlos Germano</strong>
            <p class="mb-0">Administrador</p>
          </section>
          <b-dropdown
            dropup
            variant="link"
            align="left"
            no-caret
            toggle-class="text-decoration-none p-0"
          >
            <template #button-content>
              <b-icon icon="gear" />
            </template>
            <b-dropdown-item href="#">Action</b-dropdown-item>
          </b-dropdown>
        </div>
      </b-media>
    </div>
  </div>
</template>

<script>
export default {
  name: "DashboardCoreDrawer",
  data() {
    return {
      items: [],
    };
  },
  props: {
    selected: String
  },
  mounted() {
    this.items = [
      {
        id: "main",
        icon: "house-door",
        title: "Dashboard",
        to: "/admin",
      },
      {
        id: "produtos",
        icon: "box",
        title: "Produtos",
        to: "",
        children: [
          {
            id: "produtos-criar",
            title: "Criar Produto",
            icon: "box-arrow-in-down-right",
            to: "/admin/produto/",
          },
          {
            id: "produtos-gerenciar",
            title: "Gerenciar Produtos",
            icon: "inboxes",
            to: "/admin/produto/gerenciar",
          },
          {
            id: "produtos-conf",
            title: "Criar Configuração",
            icon: "tools",
            to: "/admin/produto/configuracoes",
          },
          {
            id: "produtos-gerenconf",
            title: "Gerenciar Configurações",
            icon: "inboxes",
            to: "/admin/produto/gerenciar-configuracoes",
          },
          {
            id: "produtos-estoque",
            title: "Estoque",
            icon: "box",
            to: "/admin/produto/estoque"
          }
        ],
      },
      {
        id: "clientes",
        title: "Clientes",
        icon: "person-bounding-box",
        to: "/admin/clientes",
      },
      {
        id: "pedidos",
        title: "Pedidos",
        icon: "minecart-loaded",
        to: "/admin/pedidos",
      },
      {
        id: "relatorio",
        title: "Relatórios",
        icon: "layers",
        to: "/admin/relatorio",
      },
    ];
  },
  created() {
    if (!this.$auth.loggedIn) this.$router.push("/admin/auth/login");
  },
};
</script>
<style lang="scss" scoped>
.side-bar {
  background: #fff;
  min-height: 100vh;
  width: 240px;
  padding: 0;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  border-right: 1px solid #eaeaea;
  ul {
    padding: 0 !important;
    margin: 0;
    li {
      margin: 4px 0;
      width: 100%;
      display: flex;
      align-items: center;
      align-items: center;
      padding: 0px 12px;
      &:hover {
        background: #f1f1f1;
        * {
          color: #333;
        }
      }
      a {
        white-space: nowrap;
        color: #333;
        align-items: center !important;
        svg {
          top: 8px !important;
          color: #333;
        }
      }
    }
  }
  .sub-menu {
    margin-bottom: -12px;
  }
  .footer {
    position: relative;
    padding: 12px 4px;
    color: #3333;
    img {
      height: 30px;
      width: 30px;
      object-fit: cover;
      border-radius: 50px;
    }
    strong {
      color: #333;
    }
    p {
      color: #333;
      line-height: 1;
    }
    svg {
      color: #333;
      bottom: 2px;
      right: -8px;
      cursor: pointer;
      font-size: 18px;
      position: relative;
    }
  }
}

.sidebar-sticky {
  position: relative;
  top: 0;
  height: calc(100vh - 48px);
  padding-top: .5rem;
  overflow-x: hidden;
  overflow-y: auto; 
}

@supports ((position: -webkit-sticky) or (position: sticky)) {
  .sidebar-sticky {
    position: -webkit-sticky;
    position: sticky;
  }
}

</style>