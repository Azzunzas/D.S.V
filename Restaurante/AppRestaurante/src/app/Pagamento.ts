export class Pagamento {

    public id: number;
    public dinheiroPagamentos: Array<Dinheiro>;
    public cartaoPagamentos: Array<Cartao>;

    public constructor(id: number) {
        this.id = id;
        this.dinheiroPagamentos = new Array<Dinheiro>();
        this.cartaoPagamentos = new Array<Cartao>();
    }
}

export class Dinheiro {

    public notas: string;

    public constructor(notas: string) {
        this.notas = notas;
    }
}

export class Cartao {

    public nomeDoDono: string;
    public numCartao: number;
    public bandeira: string;

    public constructor(nomeDoDono: string, numCartao: number, bandeira: string) {
        this.nomeDoDono = nomeDoDono;
        this.numCartao = numCartao;
        this.bandeira = bandeira;
    }
}
