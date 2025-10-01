namespace Wpm.SharedKernel.ValueObjects
{
    public record Weight
    {
        public decimal Value { get; init; }
        public Weight(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("Weight value is not valid");
            Value = value;
        }
        //private Weight(){}
        // Esse é um operador de conversão implícita(implicit operator) do C#.
        //Ele permite que um valor do tipo double seja automaticamente convertido em um objeto Weight, sem precisar chamar o construtor explicitamente.
        //O método estático implicit operator Weight(double value) é um atalho do compilador que transforma double automaticamente em Weight,
        //permitindo usar valores numéricos diretamente no domínio, mas garantindo que eles sempre passem pelas regras de validação do Weight.
        public static implicit operator Weight(decimal value)
        {
            return new Weight(value);
        }
        public static implicit operator decimal(Weight value)
        {
            return value.Value;
        }
    }
}
