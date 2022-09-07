import Axios, { AxiosRequestConfig, AxiosPromise } from 'axios';
import vue from 'vue';

let context = null;
let auth = null;

export default function (appContext) {
    auth = appContext.$auth;
    context = appContext.app;
}

export async function request(method, url, data, params = {}, destino = "") {

    if (!auth?.loggedIn && !(validaRotas(url))) {
        vue.$toast.error("Sua sessão expirou. Por favor, faça o login novamente !");
        if (destino == 'gerencial') { context.router.push('/admin/auth/login'); }
        else { context.router.push('/login'); }
        return;
    }

    const options = {
        method: method,
        url: url,
        data: data,
        params: params,
        headers: { AuthToken: auth?.user ? auth?.user.token : null }
    }

    let retorno = '';
    try {
        retorno = await Axios(options);
        auth?.$storage.setUniversal('_token_expiration.local', new Date().setMinutes(new Date().getMinutes() + 120));
    } catch (err) {
        if (err.response?.status == 401) {
            vue.$toast.error("Sua sessão expirou. Por favor, faça o login novamente !");
            auth?.logout().then(() => {
                if (destino == 'gerencial') { context.router.push('/admin/auth/login'); }
                else { context.router.push('/login'); }
            });
        } else if (err.response?.status == 403)
            vue.$toast.error("Usuário sem permissão. Você não está habilitado para visualizar este recurso !");
        else {
            const error = err?.response;
            vue.$toast.error(`Ocorreu um erro ao processar sua requisição. Erro: ${JSON.stringify(error?.data)}`);
        }
    }

    return retorno
}

function validaRotas(route) {
    const rotasPermitas = ['Auth/AlterarSenha', 'Auth/CriarUsuario', 'Auth/EsqueciMinhaSenha', 'Produto/ObterUltimosProdutos', 'Produto/ObterProdutosPopulares', 'Produto/ObterProdutosMaisVendidos', 'Produto/ObterProdutoPorId', '&metadata=true'];
    const result = rotasPermitas.find(routeP => route.endsWith(routeP));

    return typeof result === 'undefined' ? false : true;
}


