import HttpsHelper, { request } from '../../helpers/HttpsHelper';
import Endpoints from '../Endpoints';

class Categoria {
    constructor() {
        this.endpoints = new Endpoints().endpoints;
    }

    async modelo(parametros, callbackSuccess, callbackError) {

        try {
            let ret = await request("POST", `ENDPOINT_HERE !`, parametros , null, 'FLUXO_HERE');
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

    async SalvarConfiguracao(parametros, callbackSuccess, callbackError) {
        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Categoria/SalvarConfiguracoesProduto`, parametros, null, 'gerencial');
            if (ret && ret.status == 200 && callbackSuccess) {
                callbackSuccess()
            } else if (!ret || (ret.status != 200 && callbackError)) {
                callbackError()
            }
        } catch {
            if (callbackError) {
                callbackError()
            }
        }
    }

    async ListarConfiguracoes(callbackSuccess, callbackError) {
        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Categoria/ListarConfiguracoesProduto`, [], null, "gerencial");

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

export default Categoria;