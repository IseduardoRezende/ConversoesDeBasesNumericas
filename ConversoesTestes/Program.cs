Console.WriteLine("Hello, World!");

Console.ReadLine();

static void SessaoDeConversoesParaDec()
{
    Console.WriteLine("Conversão de várias bases para base decimal: ");
    Console.WriteLine(ConverteBinToDec(1100001001));
    Console.WriteLine(ConverteHexaToDec("309"));
    Console.WriteLine(ConverteOctalToDec(1411));
    Console.ReadLine();
    Console.Clear();
}

static void SessaoDeConversoesParaBin()
{
    Console.WriteLine("Conversão de várias bases para base binária: ");
    ConverteDecToBin(777);
    ConverteHexaToBin("ABC1");
    ConverteOctalToBin(123);
    Console.ReadLine();
    Console.Clear();
}

static void SessaoDeConversoesParaOctal()
{
    Console.WriteLine("Conversão de várias bases para base octal: ");
    ConverteDecToOctal(83);
    ConverteHexaToOctal("53");
    ConverteBinToOctal(1010011);
    Console.ReadLine();
    Console.Clear();
}

static void SessaoDeConversoesParaHexa()
{
    Console.WriteLine("Conversão de várias bases para base hexadecimal: ");
    ConverteDecToHexa(655);
    ConverteBinToHexa(10000110101);
    ConverteOctalToHexa(2065);
    Console.ReadLine();
    Console.Clear();
}

#region Conversões para base Hexadecimal

static void ConverteOctalToHexa(int valor)
{
    int valorDecimal = ConverteOctalToDec(valor);
    ConverteDecToHexa(valorDecimal);
}

static void ConverteBinToHexa(long valor)
{
    int valorDecimal = ConverteBinToDec(valor);
    ConverteDecToHexa(valorDecimal);
}

static void ConverteDecToHexa(int valor)
{
    int resultado = 1;
    int resto = 0;
    string restoHexa = " ";
    List<string> hexas = new();

    while (resultado > 0)
    {
        resto = valor % 16;

        restoHexa = ValorDecimalParaLetrasHexadecimais(resto);

        hexas.Add(restoHexa);

        resultado = valor /= 16;
    }
    hexas.Reverse();

    Console.Write(string.Join('\0', hexas));
}

#endregion

#region Conversões para base Octal

static void ConverteHexaToOctal(string valor)
{
    int valorDecimal = ConverteHexaToDec(valor);
    ConverteDecToOctal(valorDecimal);
}

static void ConverteBinToOctal(long valor)
{
    int valorDecimal = ConverteBinToDec(valor);
    ConverteDecToOctal(valorDecimal);
}

static void ConverteDecToOctal(int valor)
{
    int resultado = 1;
    int resto = 0;
    List<int> octals = new();

    while (resultado > 0)
    {
        resto = valor % 8;
        octals.Add(resto);
        resultado = valor /= 8;
    }
    octals.Reverse();

    Console.Write(string.Join('\0', octals));
}

#endregion

#region Conversões para base Binária

static void ConverteHexaToBin(string valor)
{
    int valorDecimal = ConverteHexaToDec(valor);
    ConverteDecToBin(valorDecimal);
}

static void ConverteOctalToBin(int valor)
{
    int valorDecimal = ConverteOctalToDec(valor);
    ConverteDecToBin(valorDecimal);
}

static void ConverteDecToBin(int valor)
{
    int resultado = 1;
    int resto = 0;
    List<int> binarios = new();

    while (resultado > 0)
    {
        resto = valor % 2;
        binarios.Add(resto);
        resultado = valor /= 2;
    }
    binarios.Reverse();

    Console.Write(string.Join('\0', binarios));
}

#endregion

#region Conversões para base Decimal

static int ConverteHexaToDec(string valor)
{
    int valorDecimal = 0;
    char[] hexas = valor.ToString().ToCharArray();

    ReverseCharArray(hexas);

    for (int i = 0; i < hexas.Length; i++)
    {
        if (hexas[i] == 'A')
            valorDecimal += 10 * Potenciacao(16, i);
        else if (hexas[i] == 'B')
            valorDecimal += 11 * Potenciacao(16, i);
        else if (hexas[i] == 'C')
            valorDecimal += 12 * Potenciacao(16, i);
        else if (hexas[i] == 'D')
            valorDecimal += 13 * Potenciacao(16, i);
        else if (hexas[i] == 'E')
            valorDecimal += 14 * Potenciacao(16, i);
        else if (hexas[i] == 'F')
            valorDecimal += 15 * Potenciacao(16, i);
        else
            valorDecimal += Convert.ToInt32(hexas[i].ToString()) * Potenciacao(16, i);
    }

    return valorDecimal;
}

static int ConverteOctalToDec(int valor)
{
    int valorDecimal = 0;
    char[] charOctals = valor.ToString().ToCharArray();
    int[] intOctals = Array.ConvertAll(charOctals, c => Convert.ToInt32(c.ToString()));

    ReverseIntArray(intOctals);

    for (int i = 0; i < intOctals.Length; i++)
        valorDecimal += intOctals[i] * Potenciacao(8, i);

    return valorDecimal;
}

static int ConverteBinToDec(long valor)
{
    int valorDecimal = 0;
    char[] binarios = valor.ToString().ToCharArray();

    ReverseCharArray(binarios);

    for (int i = 0; i < binarios.Length; i++)
    {
        if (binarios[i] == '1')
            valorDecimal += 1 * Potenciacao(2, i);
        else
            valorDecimal += 0;
    }

    return valorDecimal;
}

#endregion

#region MétodosUtilizadosDentroDasConversoes

static string ValorDecimalParaLetrasHexadecimais(int valor)
{
    if (valor == 10)
        return "A";
    else if (valor == 11)
        return "B";
    else if (valor == 12)
        return "C";
    else if (valor == 13)
        return "D";
    else if (valor == 14)
        return "E";
    else if (valor == 15)
        return "F";
    else
        return valor.ToString();
}

static int Potenciacao(int baseN, int expoente)
{
    int acumulador = 1;

    for (int i = 0; i < expoente; i++)
        acumulador *= baseN;

    return acumulador;
}

static int[] ReverseIntArray(int[] array)
{
    int cont = 1;
    int[] novoArray = new int[array.Length];

    Array.Copy(array, novoArray, novoArray.Length);

    for (int i = 0; i < array.Length; i++)
        array[i] = novoArray[novoArray.Length - cont++];

    return array;
}

static char[] ReverseCharArray(char[] array)
{
    int cont = 1;
    char[] novoArray = new char[array.Length];

    Array.Copy(array, novoArray, novoArray.Length);

    for (int i = 0; i < array.Length; i++)
        array[i] = novoArray[novoArray.Length - cont++];

    return array;
}

#endregion