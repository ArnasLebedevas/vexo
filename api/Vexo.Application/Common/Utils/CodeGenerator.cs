namespace Vexo.Application.Common.Utils;

public static class CodeGenerator
{
    private static readonly Random _rng = new();

    public static string Generate6DigitCode() => _rng.Next(100000, 999999).ToString();
}