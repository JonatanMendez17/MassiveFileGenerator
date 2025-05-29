namespace FileGenerator
{
    internal class Program
    {
        const int _cntRegistros = 1000;
        const TipoProceso _tipoProceso = TipoProceso.Conciliar;
        const string _folderSinBarritaFinal = "C:\\FileGenerator";

        static void Main()
        {
            var random = new Random();

            // Generar líneas
            var lineas = new string[_cntRegistros];
            var lineasConDuplicados = new string[_cntRegistros];

            var generador = GetGeneradorPorProceso(_tipoProceso, random);

            for (var i = 0; i < lineas.Length; i++)
            {
                var identifier = generador.GetIdentifier(random);
                var lineaSinIdentifier = generador.GenerarLinea(random);

                if (generador.Columns > 1)
                {
                    lineasConDuplicados[i] = $"{(i > (lineasConDuplicados.Length / 2) ? generador.DuplicateIdentifier : identifier)}|{lineaSinIdentifier}";
                    lineas[i] = $"{identifier}|{lineaSinIdentifier}";
                }
                else
                {
                    lineasConDuplicados[i] = $"{(i > (lineasConDuplicados.Length / 2) ? generador.DuplicateIdentifier : identifier)}";
                    lineas[i] = $"{identifier}";
                }

            }

            // Cambiar la ubicación de guardado del archivo
            File.WriteAllLines($"{_folderSinBarritaFinal}\\{_tipoProceso}_Volumetria_{_cntRegistros}_{DateTime.Now:yyyyMMddhhmmss}.txt", lineas);
            File.WriteAllLines($"{_folderSinBarritaFinal}\\{_tipoProceso}_VolumetriaConDuplicados_{_cntRegistros}_{DateTime.Now:yyyyMMddhhmmss}.txt", lineasConDuplicados);

            Console.WriteLine("Archivo generado correctamente.");
        }

        private static IGenerador GetGeneradorPorProceso(TipoProceso tipoProceso, Random? random)
        {
            return tipoProceso switch
            {
                _ => throw new NotImplementedException(),
            };
        }
    }

    internal interface IGenerador
    {
        string GenerarLinea(Random? random);
        string GetIdentifier(Random? random);
        string DuplicateIdentifier { get; }
        int Columns { get; }
    }

    internal enum TipoProceso
    {
        Conciliar,
        OtroProceso
    }
}