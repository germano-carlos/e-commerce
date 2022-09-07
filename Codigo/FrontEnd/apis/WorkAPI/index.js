import Auth from './Auth';
import Categoria from './Categoria';
import Classificacao from './Classificacao';
import Logradouro from './Logradouro';
import Marca from './Marca';
import Operacao from './Operacao';
import Produto from './Produto';
import Subcategoria from './Subcategoria';
import Tag from './Tag';
import Pedido from './Pedido'

export default class WorkAPI {
    static Auth = new Auth();
    static Categoria = new Categoria();
    static Classificacao = new Classificacao();
    static Logradouro = new Logradouro();
    static Marca = new Marca();
    static Operacao = new Operacao();
    static Produto = new Produto();
    static Subcategoria = new Subcategoria();
    static Tag = new Tag();
    static Pedido = new Pedido();
}