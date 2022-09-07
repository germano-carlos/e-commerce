<template>
  <div>
    <b-table
      :striped="striped"
      :bordered="bordered"
      :borderless="borderless"
      :outlined="outlined"
      :small="small"
      :hover="hover"
      :dark="dark"
      :fixed="fixed"
      :foot-clone="footClone"
      :no-border-collapse="noCollapse"
      :items="items"
      :fields="fields"
      :head-variant="headVariant"
      :table-variant="tableVariant"
      :per-page="perPage"
      :current-page="currentPage"
    >
      <template v-if="checkbox" v-slot:cell(selected)="row">
        <b-form-group>
          <input type="checkbox" v-model="row.item.selected" />
        </b-form-group>
      </template>
      ></b-table
    >
    <b-pagination
      v-model="currentPage"
      :total-rows="rows"
      :per-page="perPage"
      aria-controls="my-table"
    ></b-pagination>
  </div>
</template>


<script>
export default {
  props: {
    items: {
      type: Array,
    },
    striped: { default: false },
    bordered: { default: false },
    borderless: { default: false },
    outlined: { default: false },
    small: { default: false },
    hover: { default: false },
    dark: { default: false },
    fixed: { default: false },
    footClone: { default: false },
    headVariant: { default: "" },
    tableVariant: { default: "" },
    noCollapse: { default: false },
    checkbox: { default: false },
    tableVariants: {
      type: Array,
      default: () => {
        return [];
      },
    },
    fields: {
      type: Array,
      default: () => {
        return [];
      },
    },
  },
  data() {
    return {
      perPage: 5,
      currentPage: 1,
    };
  },
  computed: {
      rows() {
        return this.items.length
      }
    }
};
</script>