namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // DONE: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // EXTRA: Adidionada expressão regular para aceitar apenas 7 díditos e formato específico de placa
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string? input = Console.ReadLine();
            string placa = input?.Trim().ToUpper() ?? string.Empty;

            if (!string.IsNullOrEmpty(placa))
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(placa, @"^[A-Z]{3}[0-9]{4}$|^[A-Z]{3}[0-9][A-Z][0-9]{2}$"))
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"Veículo com placa {placa} adicionado com sucesso.");
                }
                else
                {
                    Console.WriteLine("A placa deve ter sete caracteres e estar no formato correto (ABC1D23).");
                }
            }
            else
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
            }   
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string? input = Console.ReadLine();
            string placa = input?.Trim().ToUpper() ?? string.Empty;

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // DONE: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // DONE: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
            string? horasInput = Console.ReadLine();
                
                if (int.TryParse(horasInput, out int horas) && horas > 0)
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    // DONE: Remover a placa digitada da lista de veículos
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                }   
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // DONE: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
