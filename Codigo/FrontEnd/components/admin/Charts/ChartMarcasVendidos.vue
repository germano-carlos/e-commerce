<template>
    <div>
        <bar-chart v-if="loaded" :chartData="barChartData" :options="barChartOptions" :height="100" />
    </div>
</template>

<script>
import BarChart from '../../common/Chart/BarChart'

export default {
    name: "ChartMarcasVendidos",

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
                        label: 'Marcas mais Vendidos',
                        data: [],
                        backgroundColor: '#FCAB60'
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
                text: 'Marcas Mais Vendidas',
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
                this.barChartData.datasets[0].data.push(e.quantidade)
            });

            this.loaded = true;
        }
    }
}

</script>
