namespace AplMovilBexsolucionesApi.Helpers;

/// <summary>Utilidades para identificaciones (NIT/cédula).</summary>
public static class Identificacion
{
    private static readonly int[] Pesos = { 3, 7, 13, 17, 19, 23, 29, 37, 41, 43, 47, 53, 59, 67, 71 };


    public static int CalcularDigito(string? identificacion)
    {
        if (string.IsNullOrWhiteSpace(identificacion))
            return 0;

        var soloDigitos = new string(identificacion.Where(char.IsDigit).ToArray());
        if (soloDigitos.Length == 0)
            return 0;

        long suma = 0;
        var peso = 0;
        for (var i = soloDigitos.Length - 1; i >= 0 && peso < Pesos.Length; i--, peso++)
        {
            suma += (soloDigitos[i] - '0') * (long)Pesos[peso];
        }

        var residuo = (int)(suma % 11);
        return residuo > 1 ? 11 - residuo : residuo;
    }
}
