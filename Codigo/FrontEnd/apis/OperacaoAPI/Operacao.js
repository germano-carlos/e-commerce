import HttpsHelper, { request } from '../../helpers/HttpsHelper';
import Endpoints from '../Endpoints';

class Operacao {
    constructor() {
        this.endpoints = new Endpoints().endpoints;
    }

    async SalvarConfiguracao(parametros, callbackSuccess, callbackError) {
        try {
            let ret = await request("POST", `${this.endpoints.operacao}/SalvarConfiguracoesProduto`, parametros, null, 'gerencial');
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
            let ret = await request("POST", `${this.endpoints.operacao}/ListarConfiguracoesProduto`, [], null, "gerencial");

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
            let ret = await request("POST", `${this.endpoints.operacao}/ListarTags`, form, null, 'gerencial');
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

    async ListarEnderecosPorUserId(parameters, callback) {
        let data = await request("POST", `${this.endpoints.operacao}/enderecos`, null, parameters);
        if (callback) {
            callback();
        }

        return data.data;
    }

    async listarProdutos(parametros, callbackSuccess, callbackError) {
        try {
            let ret = await request("POST", `${this.endpoints.operacao}/ListarProdutos`, null, null, 'gerencial');
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

export default Operacao;