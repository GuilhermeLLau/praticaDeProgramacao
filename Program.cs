using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praticaDeProg
{
    internal class Program
    {
        class Cliente
        {
            public string nome;

            public Cliente(string str)
            {
                this.nome = str;
            }
        }

        class MovimentoBancario
        {
            public string descricao;
            public float valor;

            public MovimentoBancario(string str, float num)
            {
                this.descricao = str;
                this.valor = num;
            }
        }

        class ContaCorrente
        {
            public Cliente conta;
            public string tipoDaConta;
            //MaxiContaTotal MaxiContaSimples MaxiContaEconomica
            public MovimentoBancario[] movimentoBancarios;
            public int contadorDeMovimentos = 0;

            public void realizaDeposito(MovimentoBancario transacao)
            {
                movimentoBancarios[contadorDeMovimentos] = transacao;
                contadorDeMovimentos++;
            }

            public void realizaSaque(MovimentoBancario transacao)
            {
                movimentoBancarios[contadorDeMovimentos] = transacao;
                contadorDeMovimentos++;
            }

            public void MudaTipo(string str)
            {
                tipoDaConta = str;
            }

            public float obtemSaldo()
            {
                float valorTotal = 0;
                for (int i = 0; i < movimentoBancarios.Length; i++)
                {
                    if(movimentoBancarios[i] == null)
                    {
                        return valorTotal;
                    }
                    if (movimentoBancarios[i].descricao == "deposito")
                    {
                        valorTotal += movimentoBancarios[i].valor;
                    }
                    else if (movimentoBancarios[i].descricao == "saque")
                    {
                        valorTotal -= movimentoBancarios[i].valor;
                    }
                }
                return valorTotal;
            }

            public float CalculaValorMensalidade()
            {
                double mensalidade = 0;
                float saldo = obtemSaldo();
                if (tipoDaConta == "MaxiContaEconomica")
                {
                    mensalidade = contadorDeMovimentos * 1.5 + 10;
                } else if(tipoDaConta == "MaxiContaTotal")
                {
                    float desconto = 50 * ((saldo - 200) / 1800);
                    mensalidade = 50 - desconto;

                }else if(tipoDaConta == "MaxiContaSimples")
                {
                    float desconto = 20 * ((saldo - 100) / 1400);
                    if(contadorDeMovimentos <= 5)
                    {
                        mensalidade = 20 - desconto;
                    } else
                    {
                        desconto = (20 + contadorDeMovimentos - 5) * ((saldo - 100) / 1400);
                        mensalidade = (20 + contadorDeMovimentos - 5) - desconto;
                        Console.WriteLine(desconto);
                    }
                }
                return (float)mensalidade;
            }

            public ContaCorrente(Cliente cliente)
            {
                this.conta = cliente;
                movimentoBancarios = new MovimentoBancario[15];
            }
        }

        

        static void Main(string[] args)
        {
            Cliente guilherme = new Cliente("Guilherme");
            ContaCorrente contaCorrente = new ContaCorrente(guilherme);
            contaCorrente.tipoDaConta = "MaxiContaEconomica";
            MovimentoBancario deposito = new MovimentoBancario("deposito", 1000);
            MovimentoBancario saque = new MovimentoBancario("saque", 13000);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(deposito);
            contaCorrente.realizaDeposito(saque);
            Console.WriteLine(contaCorrente.obtemSaldo());
            Console.WriteLine(contaCorrente.tipoDaConta);
            Console.WriteLine(contaCorrente.contadorDeMovimentos);
            Console.WriteLine(contaCorrente.CalculaValorMensalidade());
            Console.ReadKey();
        }
    }
}
