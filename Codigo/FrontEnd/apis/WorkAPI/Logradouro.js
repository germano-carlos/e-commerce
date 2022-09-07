import HttpsHelper, { request } from '../../helpers/HttpsHelper';
import Endpoints from '../Endpoints';

class Logradouro {
    constructor() {
        this.endpoints = new Endpoints().endpoints;
    }

    async modelo(parametros, callbackSuccess, callbackError) {

        try {
            let ret = await request("POST", `ENDPOINT_HERE !`, parametros, null, 'FLUXO_HERE');
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

    async listarLogradourosPorUserId(parameters, callbackSuccess, callbackError) {
        let form = new FormData();
        form.append("userId", parameters.userId);

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Logradouro/ListarLogradourosPorUserId`, form, null, 'gerencial');
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

    async atualizarLogradouro(parameters, callbackSuccess, callbackError) {

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Logradouro/AtualizarLogradouro`, parameters, null, 'gerencial');
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

    async deletarLogradouro(parameters, callbackSuccess, callbackError) {

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Logradouro/DeletarLogradouro`, null, parameters, 'gerencial');
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

export default Logradouro;