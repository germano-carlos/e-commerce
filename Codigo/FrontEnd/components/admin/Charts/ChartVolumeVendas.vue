<template>
    <div>
        <line-chart v-if="loaded" :chartData="datacollection" :height="100"></line-chart>
    </div>
</template>

<script>
import LineChart from '../../common/Chart/LineChart'

export default {
    name: "ChartVolumeVendas",

    components: {
        LineChart
    },

    props: ["chartData"],
    data() {
        return {
            loaded: false,
            datacollection: {
                labels: [],
                datasets: [{
                    label: 'Vendas por mês',
                    data: [],
                    fill: false,
                    borderColor: 'rgb(75, 192, 192)',
                    tension: 0.1
                }]
            }
        }
    },

    methods: {
        translateMonth(index) {
            const monthNames = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
            ];

            return monthNames[index]
        },

        updateData(data) {
            data.forEach(e => {
                this.datacollection.labels.push(this.translateMonth(e.mes))
                this.datacollection.datasets[0].data.push(e.quantidade)
            });

            this.loaded = true;
        }
    }
}

</script>
