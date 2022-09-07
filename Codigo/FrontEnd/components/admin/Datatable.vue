<template>
  <div class="datatable">

    <!-- Table Body -->
    <b-table
      id="table-body"
      outlined
      :busy="loading"
      :items="getFilteredItems"
      :fields="fields"
      :per-page="optionSelected"
      :current-page="curPage"
      selectable
      select-mode="single"
      @row-selected="onRowClicked"
    >

    <template slot="thead-top" >
        <tr v-show="!loading">

            <th v-if="this.filterCallback" :colspan="Object.keys(fields).length - 1">
                <b-input-group>
                    <b-input-group-prepend class="icon-search" is-text>
                        <b-icon icon="search"></b-icon>
                    </b-input-group-prepend>

                    <b-form-input
                    class="rounded-search"
                    v-model="searchParam" 
                    id="input-search" 
                    placeholder="Pesquisar...">
                    </b-form-input>
                </b-input-group>
            </th>

            <th v-if="this.filterCallback" colspan="1">
                 <b-form-select
                    v-model="optionSelected" 
                    :options="options">
                </b-form-select>
            </th>

            <th v-else :colspan="Object.keys(fields).length">
                <b-form-select
                    v-model="optionSelected" 
                    :options="options">
                </b-form-select>
            </th>

            
        </tr>
    </template>

    
    <!-- Loading template -->
     <template #table-busy>
        <div class="text-center text-danger my-2">
          <b-spinner class="align-middle"></b-spinner>
          <strong>Carregando...</strong>
        </div>
      </template>

    </b-table>

    <!-- Table pagination -->
    <b-form v-show="!loading">
        <b-form-group>
            <b-pagination 
                v-model="curPage" 
                :total-rows="itemsSize" 
                :per-page="optionSelected" 
                aria-controls="table-body">
            </b-pagination>
        </b-form-group>
    </b-form>
    
  </div>
</template>

<script>
export default {
    name: "datatable",
    props: {
        items: Array,
        fields: Array,
        loading: Boolean,
        filterCallback: Function
    },
    data() {
        return {
            curPage: 1,
            searchParam: "",
            itemsSize: 5,
            optionSelected: 5,
            options: [
                {value: 5,   text: '5 resultados.'},
                {value: 10,  text: '10 resultados.'},
                {value: 25,  text: '25 resultados.'},
                {value: 50,  text: '50 resultados.'},
                {value: 100, text: '100 resultados.'},
                {value: 200, text: '200 resultados.'},
            ],
        };
    },
    methods: {
        onRowClicked(selecteds) {
            if(Array.isArray(selecteds) && selecteds.length) {
                this.$emit('onRowClicked', selecteds[0]);
            }
        },
        defaultFilter(items, search_param) {
            return items;
        }
    },

    computed: {
        pageRows() {
            return this.items.length;
        },
        getFilteredItems() {
            let res = null;
            let search_param = this.searchParam.toLowerCase();

            if(this.filterCallback) {
                res = this.filterCallback(this.items, search_param);
            } else {
                res = this.defaultFilter(this.items, search_param);
            }

            this.itemsSize = res.length;
            return res;
        }
    }
}
</script>

<style>
.datatable {
    margin-top: 2%;
}

.input-group-text {
    border: none !important;
}

.rounded-search {
    border-radius: 32px;
}

</style>