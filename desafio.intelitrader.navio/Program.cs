using System;
using System.Text;

namespace desafio.intelitrader.navio
{
    internal class Program
    {
        private static readonly string? _mensagemCriptografada = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        static void Main(string[] args)
        {
            // garante que a mensagem criptografada não está vazia
            if (string.IsNullOrWhiteSpace(_mensagemCriptografada))
            {
                Console.WriteLine("Não há mensagem criptografada definida!");
                return;
            }

            // quebra os blocos utilizando o "espaço em branco" como separador e remove os itens vazios
            var blocosCriptografados = _mensagemCriptografada.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // cria um StringBuilder para armazenar a mensagem descriptografada
            var sbMensagemDescriptografada = new StringBuilder(blocosCriptografados.Length);

            // aplica o algoritmo de descriptografia para cada bloco obtido
            foreach (var blocoCriptografado in blocosCriptografados)
            {
                // garante que o bloco possui o tamanho esperado de 8 bits
                if (blocoCriptografado.Length != 8)
                {
                    Console.WriteLine("Não é possível aplicar o algoritmo de descriptografia na mensagem!");
                    return;
                }

                // a cada 8 bits, inverte os últimos 2 bits
                var sbTemporario = new StringBuilder(blocoCriptografado);
                sbTemporario[6] = sbTemporario[6] == '0' ? '1' : '0';
                sbTemporario[7] = sbTemporario[7] == '0' ? '1' : '0';

                // a cada 4 bits, troca com os próximos 4 bits
                var strTemporaria = sbTemporario.ToString();
                var parte1 = strTemporaria.Substring(0, 4);
                var parte2 = strTemporaria.Substring(4);
                strTemporaria = parte2 + parte1;

                // converte o bloco para inteiro a partir da base 2
                var blocoInteiro = Convert.ToInt32(strTemporaria, 2);

                // converte o inteiro para seu equivalente da tabela ASCII
                var blocoCaracter = Convert.ToChar(blocoInteiro);

                // adiciona o caracter obtido na mensagem descriptografada
                sbMensagemDescriptografada.Append(blocoCaracter);
            }

            // imprime a mensagem descriptografada
            Console.WriteLine(sbMensagemDescriptografada.ToString());
        }
    }
}
