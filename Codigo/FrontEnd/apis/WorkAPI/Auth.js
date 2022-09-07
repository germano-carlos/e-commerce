import HttpsHelper, { request } from '../../helpers/HttpsHelper';
import Endpoints from '../Endpoints';

class Auth {
    constructor() {
        this.endpoints = new Endpoints().endpoints;
    }

    async adicionarClientesBacklist(parametros, callbackSuccess, callbackError) {

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Auth/AdicionarClientesBlacklist`, parametros, null, 'gerencial');
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

    async listarClientes(parametros, callbackSuccess, callbackError) {

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Auth/ListarUsuarios`, parametros, null, 'gerencial');
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

    async recuperarSenha(parametros, callbackSuccess, callbackError) {

        let form = new FormData();
        form.append("email", parametros?.email);
        form.append("urlRecuperar", parametros?.urlRecuperar);
        form.append("TipoPermissao", parametros?.TipoPermissao);

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Auth/EsqueciMinhaSenha`, form , null, 'gerencial');
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
        form.append("TipoPermissao", parametros?.TipoPermissao);

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Auth/AlterarSenha`, form , null, 'gerencial');
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

    async criarUsuario(parametros, callbackSuccess, callbackError) {

        let form = {
                nomeUsuario: parametros?.nome,
                TipoPermissao: parametros?.TipoPermissao,
                email: parametros?.email,
                senhaUsuario: parametros?.senha
        };

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Auth/CriarUsuario`, form , null, 'usuario');
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