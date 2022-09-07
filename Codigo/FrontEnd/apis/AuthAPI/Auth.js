import HttpsHelper, { request } from '../../helpers/HttpsHelper';
import Endpoints from '../Endpoints';

class Auth {
    constructor() {
        this.endpoints = new Endpoints().endpoints;
    }

    async adicionarClientesBacklist(parametros, callback) {
        let data = await request("POST", `${this.endpoints.auth}/AdicionarClientesBlacklist`, parametros, 'gerencial');
        if (callback) {
            callback();
        }

        return data;
    }

    async listarClientes(parametros, callback) {

        let data = await request("POST", `${this.endpoints.auth}/ListarUsuarios`, parametros, 'gerencial');
        if (callback) {
            callback();
        }

        return data;
    }

    async recuperarSenha(parametros, callbackSuccess, callbackError) {

        let form = new FormData();
        form.append("email", parametros?.email);
        form.append("urlRecuperar", parametros?.urlRecuperar);

        try {
            let ret = await request("POST", `${this.endpoints.auth}/EsqueciMinhaSenha`, form , null, 'gerencial');
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

    async alterarSenha(parametros, callbackSuccess, callbackError) {

        let form = new FormData();
        form.append("email", parametros?.email);
        form.append("senha", parametros?.password);
        form.append("senhaAntiga", parametros?.lastPassword);

        try {
            let ret = await request("POST", `${this.endpoints.auth}/AlterarSenha`, form , null, 'gerencial');
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

export default Auth;