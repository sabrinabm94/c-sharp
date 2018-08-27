using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento
{
    class Program
    {
        static void Main(string[] args)
        {
            string primeiraLinha = Console.ReadLine();
            string[] entradaUm = primeiraLinha.Split(' ');
            int comprimentoEstacionamento = Convert.ToInt32(entradaUm[0]);
            int totalEventos = Convert.ToInt32(entradaUm[1]);
            int comprimentoVeiculo = 0;

            Estacionamento estacionamento = new Estacionamento();
            estacionamento.setComprimento(comprimentoEstacionamento);
            //fatura fixa de 10
            estacionamento.setTarifa(10);

            Veiculo[] veiculosEstacionados = new Veiculo[totalEventos];
            Veiculo[] veiculosFila = new Veiculo[totalEventos];

            for (int y = 0; y < totalEventos; y++)
            {
                string segundaLinha = Console.ReadLine();
                string[] entradaDois = segundaLinha.Split(' ');
                string tipoEvento = entradaDois[0];
                string placa = entradaDois[1];

                if (tipoEvento == "C") //chegada de veículo, deve computar o comprimento
                {
                    comprimentoVeiculo = Convert.ToInt32(entradaDois[2]);

                    veiculosFila[y] = new Veiculo();
                    veiculosFila[y].setPlaca(placa);
                    veiculosFila[y].setComprimento(comprimentoVeiculo);

                    estacionamento.LocalParaEstacionar(veiculosFila, veiculosEstacionados, veiculosFila[y]);

                } else if(tipoEvento == "S")
                {
                    veiculosFila[y] = new Veiculo();
                    veiculosFila[y].setPlaca(placa);
                    veiculosFila[y].setComprimento(comprimentoVeiculo);

                    estacionamento.Sair(veiculosFila[y].getPlaca(), veiculosEstacionados);
                }
                
            }

            Console.WriteLine(estacionamento.getFaturamentoTotal());

            Console.WriteLine("Pressione enter para encerrar...");
            Console.ReadLine();
        }

        class Veiculo
        {
            int comprimento;
            double tarifa;
            string placa;

            public void setComprimento(int comprimento)
            {
                this.comprimento = comprimento;
            }

            public int getComprimento()
            {
                return comprimento;
            }

            public void setTarifa(double tarifa)
            {
                this.tarifa = tarifa;
            }

            public double getTarifa()
            {
                return tarifa;
            }

            public void setPlaca(string placa)
            {
                this.placa = placa;
            }

            public string getPlaca()
            {
                return placa;
            }
        }

        class Estacionamento
        {
            double tarifa, faturamentoTotal;
            int localCarroDuplicado, comprimento;

            public void LocalParaEstacionar(Veiculo[] veiculosFila, Veiculo[] veiculosEstacionados, Veiculo veiculoFila)
            {
                bool placaDuplicada = false;

                for (int i = 0; i < veiculosFila.Length; i++)
                {
                    if (veiculosEstacionados[i] != null && veiculosEstacionados[i].getPlaca() == veiculoFila.getPlaca())
                    {
                        placaDuplicada = true;
                        setLocalCarroDuplicado(i);
                    }
                }

                if (placaDuplicada == false)
                {
                    for (int i = 0; i < veiculosFila.Length; i++)
                    {
                        if (veiculosEstacionados[i] == null && veiculosFila[i] != null && veiculoFila.getComprimento() <= getComprimento())
                        {
                            Estacionar(veiculosFila, veiculosEstacionados, i, i);
                            break;
                        } else
                        {
                            //Console.WriteLine("O veículo " + veiculoFila + " não cabe no estacionamento.");
                        }
                    }
                }
                else
                {
                    //Console.WriteLine("O carro com a placa " + veiculoFila.getPlaca() + " já está estacionado na vaga " + getLocalCarroDuplicado());
                }
            }

            public void print(Veiculo[] veiculosEstacionados)
            {
                Console.WriteLine("Carros estacionados: ");
                for (int i = 0; i < veiculosEstacionados.Length; i++)
                {
                    Console.Write(veiculosEstacionados[i].getPlaca() + "; ");
                }
                Console.WriteLine("");
            }

            public void Estacionar(Veiculo[] veiculosFila, Veiculo[] veiculosEstacionados, int localVeiculoFila, int localVeiculoEstacinado)
            {
                veiculosEstacionados[localVeiculoEstacinado] = veiculosFila[localVeiculoFila];
                veiculosEstacionados[localVeiculoEstacinado].setTarifa(getTarifa());
                veiculosFila[localVeiculoFila] = null;

                //adiciona valor no faturamento
                setFaturamentoTotal(faturamentoTotal = faturamentoTotal + veiculosEstacionados[localVeiculoEstacinado].getTarifa());
                //diminui espaço livre do estacionamento
                setComprimento(getComprimento() - veiculosEstacionados[localVeiculoEstacinado].getComprimento());
                //Console.WriteLine("O veículo com placa " + veiculosEstacionados[localVeiculoEstacinado].getPlaca() + " e comprimento " + veiculosEstacionados[localVeiculoEstacinado].getComprimento() + " foi estacionado.");
                
            }

            public void Sair(string placa, Veiculo[] veiculosEstacionados)
            {
                for (int i = 0; i < veiculosEstacionados.Length; i++)
                {
                    if (veiculosEstacionados[i] != null && veiculosEstacionados[i].getPlaca() == placa)
                    {
                        //Console.WriteLine("O veículo com placa " + placa + " saio do estacionamento");

                        //libera espaço no estacionamento
                        setComprimento(getComprimento() + veiculosEstacionados[i].getComprimento());
                        veiculosEstacionados[i] = null;
                    }
                    else
                    {
                        //Console.WriteLine("O veículo não se encontra no estacionamento.");
                    }
                } 
            }

            public void setTarifa(double tarifa)
            {
                this.tarifa = tarifa;
            }

            public double getTarifa()
            {
                return tarifa;
            }

            public void setFaturamentoTotal(double faturamentoTotal)
            {
                this.faturamentoTotal = faturamentoTotal;
            }

            public double getFaturamentoTotal()
            {
                return faturamentoTotal;
            }

            public void setLocalCarroDuplicado(int localCarroDuplicado)
            {
                this.localCarroDuplicado = localCarroDuplicado;
            }

            public int getLocalCarroDuplicado()
            {
                return localCarroDuplicado;
            }

            public void setComprimento(int comprimento)
            {
                this.comprimento = comprimento;
            }

            public int getComprimento()
            {
                return comprimento;
            }

        }
    }
}
