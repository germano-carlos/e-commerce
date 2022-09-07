import HttpsHelper, { request } from '../../helpers/HttpsHelper';
import Endpoints from '../Endpoints';

class Marca {
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

    async obterMarcasMaisVendidas(parametros, callbackSuccess, callbackError) {
        try {
            let ret = await request("GET", `${this.endpoints.workAPI}/Marca/ObterMaisVendidas`, null, null, 'gerencial');
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

export default Marca;