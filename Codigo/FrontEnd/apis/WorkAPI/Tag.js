import HttpsHelper, { request } from '../../helpers/HttpsHelper';
import Endpoints from '../Endpoints';

class Tag {
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

    async listarTagsPorCaracter(parametros, callbackSuccess, callbackError) {
        let form = new FormData();
        form.append("caracteres", parametros);

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Tags/ListarTags`, form, null, 'gerencial');
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

export default Tag;