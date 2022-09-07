<template>
    <b-modal ref="pedidos-modal">
        <h3>Lista de produtos</h3>

        <!-- Table Body -->
        <b-table
        id="table-pedidos"
        outlined
        :items="getProdutos"
        :fields="keyFields">

        </b-table>

        <!-- Subtotal -->
        <span>Subtotal: {{this.getSubTotal}} </span> <br>
        <span>Desconto: {{this.getDesconto}} </span> <br>
        <span>Frete: {{this.getFrete}} </span> <br>
        <span><b>Total:</b> {{this.getTotal}} </span> <br><br>
        <span>Status Pedido: <b>{{getPedidoStatus}}</b> </span> <br>

        <!-- endereco entrega -->
        <h3 class="pt-3">Endereço de Entrega</h3>
        <span>Destinatário: {{this.getDestinatario}}</span> <br>
        <span>Rua: {{this.getRua}}</span> <br>
        <span>Bairro: {{this.getBairro}}</span> <br>
        <span>Número: {{this.getNumero}}</span> <br>
        <span>{{this.getCidade}}, {{this.getEstado}}, {{this.getCep}}</span> <br>
    </b-modal>
</template>

<script>
export default {
    data() {
        return {
            listaProduto: null,
            endereco: null,
            pedido_info: null,
            keyFields: [
                {key: "nome", label: "Nome Produto", sortable: true},
                {key: "qtd", label: "Quantidade", sortable: true},
                {key: "preco", label: "Preço", sortable: true}
            ]
        }
    },
    mounted() {

    },
    methods: {
        show(produto, pedido_info, endereco) {
            this.listaProduto = produto;
            this.endereco = endereco;
            this.pedido_info = pedido_info;
            this.$refs['pedidos-modal'].show()
        },
        strMoneyFormat(value) {
            return "R$ " + value + ".00"
        }
    },
    computed: {
        getDestinatario() {
            return this.endereco?.destinatario;
        },
        getRua() {
            return this.endereco?.rua;
        },
        getBairro() {
            return this.endereco?.bairro;
        },
        getNumero() {
            return this.endereco?.numero;
        },
        getCidade() {
            return this.endereco?.cidade;
        },
        getEstado() {
            return this.endereco?.estado;
        },
        getCep() {
            return this.endereco?.cep;
        },
        getSubTotal() {
            return this.strMoneyFormat(this.pedido_info?.subtotal);
        },
        getDesconto() {
            return this.strMoneyFormat(this.pedido_info?.desconto);
        },
        getFrete() {
            return this.strMoneyFormat(this.pedido_info?.frete);
        },
        getTotal() {
            return this.strMoneyFormat(this.pedido_info?.total);
        },
        getPedidoStatus() {
            let pedido_status = this.pedido_info?.status;
            switch(pedido_status)
            {
                case 1:
                    return "Carrinho".toUpperCase();
                case 2:
                    return "Analise".toUpperCase();
                case 3:
                    return "Finalizado".toUpperCase();
                case 4:
                    return "Cancelado".toUpperCase();
                case 5:
                    return "Estornado".toUpperCase();
            }
            return "";
        },
        getProdutos() {
            if(this.listaProduto) {
                this.listaProduto.forEach(e => {
                    e.preco = this.strMoneyFormat(e.preco)
                });
            }

            return this.listaProduto;
        }
    }
}
</script>

<style>

</style>