namespace Exercicios_H1_02.models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        public double IMC
        {
            get
            {
                return Peso / (Altura * Altura);
            }
        }
    }
}