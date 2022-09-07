import HttpsHelper, { request } from '../../helpers/HttpsHelper';
import Endpoints from '../Endpoints';

class Pedido {
    constructor() {
        this.endpoints = new Endpoints().endpoints;
    }

    async getMyPedidos(parameters, callbackSuccess, callbackError) {
        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Pedido/GetUsuarioPedidos`, null, null, 'usuario');
            if (ret && ret.status == 200 && callbackSuccess) {
                callbackSuccess(ret.data)
            } else if (!ret || (ret.status != 200 && callbackError)) {
                callbackError()
            }
        } catch {
            if (callbackError) {
                callbackError()
            }
        }
    }

    async obterPedidosPorMes(parametros, callbackSuccess, callbackError) {
        try {
            let ret = await request("GET", `${this.endpoints.workAPI}/Pedido/ObterPedidosPorMes`, null, null, 'gerencial');
            if (ret && ret.status == 200 && callbackSuccess) {
                callbackSuccess(ret.data)
            } else if (!ret || (ret.status != 200 && callbackError)) {
                callbackError()
            }
        } catch {
            if (callbackError) {
                callbackError()
            }
        }
    }

}

export default Pedido;