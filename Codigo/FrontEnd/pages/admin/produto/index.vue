<template>
  <div class="container-fluid">
    <div class="row">
      <Sidebar selected="produtos-criar" />
      <main role="main" class="col-md-12 ml-sm-auto col-lg-10 px-4">
        <div
          class="d-md-flex d-lg-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom"
        >
          <h1 class="h2">Produtos</h1>
        </div>

        <div>
          <div>
            <b-breadcrumb>
              <b-breadcrumb-item href="/admin">
                <b-icon
                  icon="house-fill"
                  scale="1.25"
                  shift-v="1.25"
                  aria-hidden="true"
                ></b-icon>
                Home
              </b-breadcrumb-item>
              <b-breadcrumb-item href="#">Produto</b-breadcrumb-item>
              <b-breadcrumb-item href="#" active
                >Criar Produto</b-breadcrumb-item
              >
            </b-breadcrumb>
          </div>

          <b-card footer-tag="footer" title="Criar Produto">
            <b-card-text
              >Bem vindo a área gerencial do seu e-commerce. Abaixo você
              conseguirá fazer o cadastro de produtos.
              <p></p>
            </b-card-text>
          </b-card>
        </div>

        <b-container fluid class="bv-example-row" style="">
          <b-row>
            <b-col cols="8">
              <b-card
                footer-tag="footer"
                class="card-item"
                title="Informações Básicas"
              >
                <hr />
                <b-card-text>
                  <form>
                    <label for="input-live">Nome Produto:</label>
                    <b-form-input
                      id="input-live"
                      v-model="basic.name"
                      :state="nameState"
                      aria-describedby="input-live-help input-live-feedback"
                      placeholder="Insira o nome do produto"
                      trim
                    ></b-form-input>
                    <!-- This will only be shown if the preceding input has an invalid state -->
                    <b-form-invalid-feedback id="input-live-feedback">
                      Insira ao menos 3 caracteres
                    </b-form-invalid-feedback>
                    <div>
                      <vue-pell-editor
                        id="editor-product"
                        v-model="basic.description.editorContent"
                        :actions="basic.description.editorOptions"
                        placeholder="Insira a descrição do seu produto"
                        :style-with-css="true"
                        :classes="basic.description.editorClasses"
                        default-paragraph-separator="p"
                      />
                    </div>
                  </form>
                </b-card-text>
              </b-card>
              <b-card class="card-item" title="Midia">
                <hr />
                <b-card-text>
                  <vue-transmit
                    class="col-12"
                    tag="section"
                    v-bind="options"
                    upload-area-classes="bg-faded"
                    ref="uploader"
                  >
                    <div
                      class="d-flex align-items-center justify-content-center w-100"
                      style="height: 30vh; border-radius: 1rem"
                    >
                      <button class="btn btn-primary" @click="triggerBrowse">
                        Upload Files
                      </button>
                    </div>
                    <!-- Scoped slot -->
                    <template slot="files" slot-scope="props">
                      <div
                        v-for="(file, i) in props.files"
                        :key="file.id"
                        :class="{ 'mt-5': i === 0 }"
                      >
                        <div class="media">
                          <img
                            :src="file.dataUrl"
                            class="img-fluid d-flex mr-3"
                          />
                          <div class="media-body">
                            <h3>{{ file.name }}</h3>
                            <div class="progress" style="width: 50vw">
                              <div
                                class="progress-bar bg-success"
                                :style="{ width: file.upload.progress + '%' }"
                              ></div>
                            </div>
                            <pre>{{ file | json }} </pre>
                          </div>
                        </div>
                      </div>
                    </template>
                  </vue-transmit>
                </b-card-text>
              </b-card>
              <b-card class="card-item" title="Variações">
                <hr />
                <b-card-text>
                  <div>
                    <b-form-checkbox
                      id="checkbox-1"
                      v-model="variacoes.status"
                      name="checkbox-1"
                      value="accepted"
                    >
                      Este produto possui variações
                    </b-form-checkbox>
                  </div>

                  <hr />

                  <div v-if="variacoes.status">
                    <div style="display: flex; justify-content: space-between">
                      <label><h7>Opções</h7></label>
                    </div>
                    <!-- Start Cadastro Vairações -->
                    <div>
                      <div
                        v-for="(opcao, index) in variacoes.combinacoes"
                        :key="index"
                        style="margin: 10px 0 25px 0"
                      >
                        <div
                          style="display: flex; justify-content: space-between"
                        >
                          <label for=""
                            ><h6>Opção {{ index + 1 }}</h6></label
                          >
                          <a href="#" @click="RemoverOpcao(index)">Remover</a>
                        </div>

                        <div class="row">
                          <div class="col-4">
                            <b-form-input
                              id="input-large"
                              size="lg"
                              v-model="variacoes.combinacoes[index].tipo"
                              readonly
                            ></b-form-input>
                          </div>
                          <div class="col-8">
                            <!-- Data: {{ variacoes.combinacoes[index].values.value }} -->
                            <Multiselect
                              :id="`values-${index}`"
                              v-model="
                                variacoes.combinacoes[index].values.value
                              "
                              v-bind="variacoes.combinacoes[index].values"
                            />
                          </div>
                        </div>
                      </div>
                    </div>

                    <div>
                      <div
                        style="display: flex; justify-content: space-between"
                      >
                        <button
                          type="submit"
                          class="btn btn-info"
                          @click="NovaOpcao"
                        >
                          Adicionar Nova Opção
                        </button>
                        <button
                          type="submit"
                          class="btn btn-info"
                          @click="GerarVariaveis"
                        >
                          Gerar Variaveis
                        </button>
                      </div>
                    </div>
                    <hr />
                    <!-- End Cadastro Vairações -->
                    <!-- Start PreVisualização Vairações -->
                    <div v-if="this.variacoes.previsualizacao.gerado">
                      <p>Pré-visualização</p>
                      <hr />
                      <div
                        style="display: flex; justify-content: space-between"
                      >
                        Exibindo
                        {{ this.variacoes.combinacoes.length }} variações
                        <b-dropdown
                          id="dropdown-dropleft"
                          dropleft
                          text="Editar Variáveis"
                          variant="info"
                          class="m-2"
                        >
                          <b-dropdown-item href="#" @click="abrirModal(1)"
                            >Editar Preços</b-dropdown-item
                          >
                          <b-dropdown-item href="#" @click="abrirModal(2)"
                            >Editar Estoques</b-dropdown-item
                          >
                        </b-dropdown>
                      </div>
                      <hr />
                      <div
                        v-for="(opVariant, index) in this.variacoes
                          .previsualizacao.values"
                        :key="index"
                      >
                        <div
                          style="display: flex; justify-content: space-between"
                        >
                          {{ opVariant.nomeVariante }}
                          <div>
                            R$ {{ opVariant.precoVariante }} /
                            {{ opVariant.quantidadeVariante }} disponível(is)
                          </div>
                        </div>
                        <hr />
                      </div>
                      <div
                        style="display: flex; justify-content: space-between"
                      >
                        <span>Estoque total disponível</span>
                        <span
                          >{{
                            this.variacoes.previsualizacao.quantidadeItensTotal
                          }}
                          item(s)</span
                        >
                      </div>
                    </div>
                    <!-- End PreVisualização Vairações -->
                  </div>
                </b-card-text>
              </b-card>
            </b-col>
            <b-col cols="4">
              <b-card class="card-item" title="Tags">
                <hr />
                <b-card-text>
                  <div>
                    <b-alert show dismissible
                      ><b-icon icon="info-circle" />
                      Tags são as palavras chaves vinculadas ao produto na qual
                      se deseja cadastrar.
                    </b-alert>
                    <div>
                      <div class="output">Data: {{ tagsSelect.value }}</div>
                      <label for="tag">Tags</label>
                      <Multiselect
                        id="tag"
                        placeholder="Insira o nome da tag"
                        v-model="tagsSelect.value"
                        v-bind="tagsSelect"
                      />
                    </div>
                  </div>
                </b-card-text>
              </b-card>
              <b-card class="card-item" title="Organização">
                <hr />
                <b-card-text>
                  <div>
                    <b-alert show dismissible
                      ><b-icon icon="info-circle" />
                      Marcas são as fabricantes do produto a ser cadastrado.
                      Caso você não localize em sua pesquisa, crie uma nova
                      marca
                    </b-alert>
                    <div>
                      <div class="output">
                        Data: {{ organizacao.marcas.value }}
                      </div>
                      <label for="organizacao">Marcas</label>
                      <Multiselect
                        id="organizacao"
                        placeholder="Insira o nome da marca"
                        v-model="organizacao.marcas.value"
                        v-bind="organizacao.marcas"
                      />
                    </div>
                  </div>
                </b-card-text>
              </b-card>
              <button
                type="submit"
                class="btn btn-info"
                @click="NovaOpcao"
                style="width: 100%; padding: 25px; margin: 20px 0 0 0"
              >
                SALVAR PRODUTO
              </button>
            </b-col>
          </b-row>
        </b-container>

        <Loader v-if="loading" />
      </main>
    </div>

    <!-- Begin Modal Editar Quantidade -->
    <b-modal
      id="edit-quantidade"
      ref="modal"
      title="Editar Variável - Quantidade"
      @ok="handleOk"
    >
      <form ref="form" @submit.stop.prevent="handleSubmit">
        <b-form-group label="Nome Variante">
          <div
            v-for="(opVariant, index) in this.variacoes.previsualizacao.values"
            :key="index"
          >
            <b-row>
              <b-col>
                {{ opVariant.nomeVariante }}
              </b-col>
              <b-col>
                <b-form-spinbutton
                  :id="`stock-spin-${index}`"
                  min="0"
                  max="100000"
                  step="1"
                  v-model="opVariant.quantidadeVariante"
                  @change="
                    onChangeEstoque($event, opVariant.quantidadeVariante)
                  "
                ></b-form-spinbutton>
              </b-col>
            </b-row>
            <hr />
          </div>
        </b-form-group>
      </form>
    </b-modal>
    <!-- End Modal Editar Quantidade -->
    <!-- Begin Modal Editar Preço -->
    <b-modal
      id="edit-preco"
      ref="modal"
      title="Editar Variável - Preço"
      @ok="handleOk"
    >
      <form ref="form" @submit.stop.prevent="handleSubmit">
        <b-form-group label="Nome Variante">
          <div
            v-for="(opVariant, index) in this.variacoes.previsualizacao.values"
            :key="index"
          >
            <b-row>
              <b-col>
                {{ opVariant.nomeVariante }}
              </b-col>
              <b-col>
                <!-- Using props -->
                <b-input-group size="lg" prepend="$">
                  <b-form-input v-model="opVariant.precoVariante" />
                </b-input-group>
              </b-col>
            </b-row>
          </div>
        </b-form-group>
      </form>
    </b-modal>
    <!-- End Modal Editar Preço -->
  </div>
</template>

<script>
import Loader from "~/components/common/Loader";
import Sidebar from "~/components/admin/Sidebar";
import Multiselect from "@vueform/multiselect/dist/multiselect.vue2.js";
import OperacaoAPI from "../../../apis/OperacaoAPI";
import WorkAPI from "../../../apis/WorkAPI";

export default {
  layout: "admin",
  methods: {
    async fetchTags(query) {
      let retorno = [];
      WorkAPI.Tag.listarTagsPorCaracter(query, (data) => {
        data.map((item) => {
          retorno.push({
            value: item.TagId,
            label: item.nome,
          });
        });
      });
      return retorno;
    },
    triggerBrowse() {
      this.$refs.uploader.triggerBrowseFiles();
    },
    NovaOpcao() {
      const opcoes = ["Tamanho", "Cor"];
      let contador = this.variacoes.combinacoes.length;
      let context = opcoes[contador] ? opcoes[contador] : null;

      if (context != null) {
        this.variacoes.combinacoes = [
          ...this.variacoes.combinacoes,
          {
            tipo: context,
            values: {
              mode: "tags",
              value: [],
              options: [],
              searchable: true,
              createTag: true,
              filterResults: false,
              minChars: 1,
              resolveOnLoad: false,
              delay: 0,
            },
          },
        ];
      } else {
        this.$toast.error(
          "Não possuimos nenhum outro parametro de variação configurado"
        );
      }
    },
    RemoverOpcao(index) {
      this.variacoes.combinacoes.splice(index, 1);
    },
    GerarVariaveis() {
      this.variacoes.previsualizacao.quantidadeItensTotal = 0;
      let nPreenchido = false;
      let parametrizacao = {
        array: [],
        tipo: [],
      };

      this.variacoes.previsualizacao.values = [];

      for (let i = 0; i < this.variacoes?.combinacoes.length; ++i) {
        nPreenchido = false;
        if (!this.variacoes.combinacoes[i].values.value) continue;

        parametrizacao.array = [
          ...parametrizacao.array,
          ...this.variacoes.combinacoes[i].values.value,
        ];
        parametrizacao.tipo = [
          ...parametrizacao.tipo,
          {
            nome: this.variacoes.combinacoes[i].tipo,
            quantidade: this.variacoes.combinacoes[i].values.value.length,
          },
        ];

        for (
          let k = 0;
          k < this.variacoes.combinacoes[i].values.value.length;
          ++k
        ) {
          if (this.variacoes.combinacoes[i].values.value[k]) {
            nPreenchido = true;
          }
        }
      }

      if (!nPreenchido || !this.variacoes) {
        this.$toast.error(
          "Você deve preencher ao menos uma variação em cada opção"
        );
        return;
      }

      let multi = parametrizacao.tipo.length > 1 ? true : false;
      let tamanhoArray = [];
      let corArray = [];
      if (multi) {
        tamanhoArray = parametrizacao.array.slice(
          0,
          parametrizacao.tipo[0].quantidade
        );
        corArray = parametrizacao.array.slice(
          parseInt(parametrizacao.tipo[0].quantidade),
          parseInt(parametrizacao.array.length)
        );

        for (let a = 0; a < corArray.length; ++a) {
          for (let b = 0; b < tamanhoArray.length; ++b) {
            let nome = corArray[a] + "/" + tamanhoArray[b];
            this.variacoes.previsualizacao.values = [
              ...this.variacoes.previsualizacao.values,
              {
                precoVariante: 0,
                nomeVariante: nome,
                quantidadeVariante: 0,
                tamanho: tamanhoArray[b],
                cor: corArray[a],
              },
            ];
          }
        }
      } else {
        parametrizacao.array.forEach((element) => {
          this.variacoes.previsualizacao.values = [
            ...this.variacoes.previsualizacao.values,
            {
              precoVariante: 0,
              nomeVariante: element,
              quantidadeVariante: 0,
            },
          ];
        });
      }

      this.variacoes.previsualizacao.gerado = true;
    },
    handleOk(bvModalEvt) {
      // Hide the modal manually
      this.$nextTick(() => {
        this.$bvModal.hide("modal-prevent-closing");
      });
    },
    abrirModal(idModal) {
      if (idModal === 1) {
        this.$nextTick(() => {
          this.$bvModal.show("edit-preco");
        });
      } else {
        this.$nextTick(() => {
          this.$bvModal.show("edit-quantidade");
        });
      }
    },
    onChangeEstoque(value, parametro) {
      let soma = 0;
      this.variacoes.previsualizacao.values.forEach((element) => {
        soma += element.quantidadeVariante;
      });

      parametro = value;
      this.variacoes.previsualizacao.quantidadeItensTotal = soma;
    },
  },
  filters: {
    json(value) {
      return JSON.stringify(value, null, 2);
    },
  },
  components: {
    Loader,
    Sidebar,
    Multiselect,
  },
  computed: {
    nameState() {
      return this.basic.name.length > 2 ? true : false;
    },
  },
  data() {
    return {
      options: {
        acceptedFileTypes: ["image/*"],
        clickable: false,
      },
      loading: true,
      tagsSelect: {
        mode: "tags",
        value: [],
        options: async (query) => {
          return await this.fetchTags(query);
        },
        searchable: true,
        createTag: true,
        filterResults: false,
        minChars: 1,
        resolveOnLoad: false,
        delay: 0,
      },
      organizacao: {
        marcas: {
          mode: "tags",
          value: [],
          options: async (query) => {
            return await this.fetchTags(query);
          },
          searchable: true,
          createTag: true,
          filterResults: false,
          minChars: 1,
          resolveOnLoad: false,
          delay: 0,
        },
      },
      basic: {
        name: "",
        description: {
          editorOptions: [
            "bold",
            "underline",
            {
              name: "italic",
              result: () => window.pell.exec("italic"),
            },
            {
              name: "custom",
              icon: "<b><u><i>C</i></u></b>",
              title: "Custom Action",
              result: () => console.log("YOLO"),
            },
          ],
          editorPlaceholder: "Write something amazing...",
          editorContent: "",
          editorClasses: {
            actionbar: "pell-actionbar",
            button: "pell-button",
            content: "pell-content",
            selected: "pell-button-selected",
          },
        },
      },
      variacoes: {
        status: false,
        combinacoes: [],
        previsualizacao: {
          gerado: false,
          checkAll: false,
          quantidadeItensTotal: 0,
          values: [],
        },
      },
    };
  },
  mounted() {
    this.loading = false;
  },
  watch: {},
};
</script>

<style lang="scss">
#editor-product {
  border: 0.5px solid;
}
.card-item {
  margin: 20px 0 0 0;
}

.bv-example-row {
  padding: 20px 0 0 0;
  padding-left: 0;
}

.btn-space {
  margin-right: 5px;
}

.buttons-itens {
  position: absolute;
  bottom: 8px;
  right: 16px;
  font-size: 15px;
}
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

.accordion {
  padding: 30px 0px 30px 0;
}
.input-form-item {
  padding: 0px 0 9px 0px;
}

.alert-config-item {
  padding-bottom: 0px;
  padding-top: 0px;
}

.recent-orders-box {
  margin-top: 30px;

  .title {
    position: relative;

    h3 {
      margin-bottom: 15px;
      font: {
        size: 20px;
        weight: 600;
      }
    }
    ul {
      padding-left: 0;
      margin-bottom: 0;
      list-style-type: none;
      position: absolute;
      right: 0;
      top: -10px;

      li {
        display: inline-block;
        margin-left: 5px;

        a,
        button {
          display: block;
          background-color: #f2f2f2;
          color: #000000;
          padding: 5px 15px;
          border: none;
          transition: 0.5s;

          &:hover {
            background-color: #000000;
            color: #fff;
          }
        }
        &:nth-child(2) {
          a,
          button {
            &:hover {
              background-color: red;
              color: #fff;
            }
          }
        }
        &:nth-child(3) {
          a,
          button {
            &:hover {
              background-color: green;
              color: #fff;
            }
          }
        }
      }
    }
  }
  table {
    margin-bottom: 0;

    thead {
      th {
        text-align: left;
        white-space: nowrap;
        padding: 15px 15px 15px 0;
        border-bottom: 1px solid #f6f6f7;
        border-color: #f6f6f7;
        font-size: 15px;
      }
    }
    tbody {
      tr {
        td {
          padding: 15px;
          vertical-align: middle;
          white-space: nowrap;
          border-bottom: 1px solid #f6f6f7;
          border-top: none;
          font-size: 14.4px;

          &:first-child {
            padding-left: 0;
          }
          &.name {
            font-weight: 700;
          }
          img {
            width: 50px;
            margin-right: 5px;
          }
        }
      }
    }
  }
}
.sidebar {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  z-index: 100; /* Behind the navbar */
  padding: 48px 0 0; /* Height of navbar */
  box-shadow: inset -1px 0 0 rgba(0, 0, 0, 0.1);
}

.sidebar-sticky {
  position: relative;
  top: 0;
  height: calc(100vh - 48px);
  padding-top: 0.5rem;
  overflow-x: hidden;
  overflow-y: auto; /* Scrollable contents if viewport is shorter than content. */
}

@supports ((position: -webkit-sticky) or (position: sticky)) {
  .sidebar-sticky {
    position: -webkit-sticky;
    position: sticky;
  }
}

.sidebar .nav-link {
  font-weight: 500;
  color: #333;
}

.sidebar .nav-link .feather {
  margin-right: 4px;
  color: #999;
}

.sidebar .nav-link.active {
  color: #007bff;
}

.sidebar .nav-link:hover .feather,
.sidebar .nav-link.active .feather {
  color: inherit;
}

.sidebar-heading {
  font-size: 0.75rem;
  text-transform: uppercase;
}

.breadcrumb-item a {
  display: inline;
}

/*
 * Content
 */

[role="main"] {
  padding-top: 133px; /* Space for fixed navbar */
}

@media (min-width: 768px) {
  [role="main"] {
    padding-top: 48px; /* Space for fixed navbar */
  }
}
</style>