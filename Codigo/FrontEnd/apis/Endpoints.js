class Endpoints {
    constructor() {
        this.endpoints = {
            correio: "https://www.correios.com.br/enviar-e-receber/ferramentas/calculador-remoto-de-precos-e-prazos/pdf/manual-de-implementacao-do-calculo-remoto-de-precos-e-prazos",
            operacao: "http://localhost:1858/api/v1/Operacao",
            auth: "http://localhost:1858/api/v1/Auth",
            relatorio: "http://localhost:1858/api/v1/Relatorio",
            logs: "http://localhost:1858/api/v1/Logs",
            sender: "http://localhost:1858/api/v1/Sender",
            workAPI: "http://localhost:1858/api/v1"
        };        
    }

}
    
export default Endpoints;