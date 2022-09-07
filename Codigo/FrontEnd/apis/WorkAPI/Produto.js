import HttpsHelper, { request } from '../../helpers/HttpsHelper';
import Endpoints from '../Endpoints';

class Produto {
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

    async listarProdutos(parametros, callbackSuccess, callbackError, dest) {
        let tamanho = parametros.queryParams.tamanhoPagina;

        let numeroPagina = "";
        if(parametros.queryParams.numeroPagina) {
            numeroPagina = `&numeroPagina=${parametros.queryParams.numeroPagina}`;
        }

        let body = null;
        if(parametros.filtros) {
            body = parametros.filtros
        }

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Produto/ListarProdutos?tamanhoPagina=${tamanho}${numeroPagina}&metadata=true`, body, null, dest);
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

    async obterUltimosProdutos(parametros, callbackSuccess, callbackError) {
        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Produto/ObterUltimosProdutos`, null, null, 'usuario');
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

    async obterProdutosMaisVendidos(parametros, callbackSuccess, callbackError) {
        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Produto/ObterProdutosMaisVendidos`, null, null, 'usuario');
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

    async obterProdutosPopulares(parametros, callbackSuccess, callbackError) {
        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Produto/ObterProdutosPopulares`, null, null, 'usuario');
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

    async obterProdutoPorId(parametros, callbackSuccess, callbackError) {
        let form = new FormData();
        form.append("id", parametros);

        try {
            let ret = await request("POST", `${this.endpoints.workAPI}/Produto/ObterProdutoPorId`, form, null, 'usuario');
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

export default Produto;