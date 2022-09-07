<template>
    <div>
        <bar-chart v-if="loaded" :chartData="barChartData" :options="barChartOptions" :height="100" />
    </div>
</template>

<script>
import BarChart from '../../common/Chart/BarChart'

export default {
    name: "ChartMaisVendidos",
    components: {
        BarChart
    },

    data() {
        return {
            loaded: false,
            barChartData: {
                labels: [],
                datasets: [
                    {
                        label: 'Produtos Vendidos',
                        data: [],
                        backgroundColor: '#6495ed'
                    }
                ]
            },

            barChartOptions: {
                responsive: true,
                legend: {
                display: false
                },
                title: {
                display: true,
                text: 'Produtos mais Vendidos',
                fontSize: 24,
                fontColor: '#6b7280'
                },
                tooltips: {
                backgroundColor: '#17BF62'
                },
                scales: {
                xAxes: [
                    {
                    gridLines: {
                        display: false
                    }
                    }
                ],
                yAxes: [
                    {
                    ticks: {
                        beginAtZero: true
                    },
                    gridLines: {
                        display: false
                    }
                    }
                ]
                }
            }
        }
    },

    methods: {
        updateData(data) {
            data.forEach(e => {
                this.barChartData.labels.push(e.nome)
                this.barChartData.datasets[0].data.push(e.totalRegistro)
            });
            
            this.loaded = true;
        }
    },

    mounted() {
    }
}

</script>
