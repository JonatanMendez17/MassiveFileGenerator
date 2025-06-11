using GeneradorArchivo.GeneradorProcesos;

namespace GeneradorArchivo
{
    internal class Program
    {
        const int _cntRegistros = 10;
        const TipoProceso _tipoProceso = TipoProceso.BajaFraude;
        const string _guardar = "C:\\";

        static void Main()
        {
            var random = new Random();

            // Generar Lineas
            var lineas = new string[_cntRegistros];
            var lineasConDuplicados = new string[_cntRegistros];

            var generador = ObtenerGeneradorPorProceso(_tipoProceso, random);

            for (var i = 0; i < lineas.Length; i++)
            {
                var identificador = generador.ObtenerIdentificador(random);
                var lineaSinIdentificar = generador.GenerarLineas(random);

                if (generador.Columnas > 1)
                {
                    lineasConDuplicados[i] = $"{(i > (lineasConDuplicados.Length / 2) ? generador.DuplicacionIdentificador : identificador)}|{lineaSinIdentificar}";
                    lineas[i] = $"{identificador}|{lineaSinIdentificar}";
                }
                else
                {
                    lineasConDuplicados[i] = $"{(i > (lineasConDuplicados.Length / 2) ? generador.DuplicacionIdentificador : identificador)}";
                    lineas[i] = $"{identificador}";
                }
            }

            // Cambiar la ubicacion de guardadp del archivo
            File.WriteAllLines($"{_guardar}\\{_tipoProceso}_volumetria_{_cntRegistros}_{DateTime.Now:yyyyMMddhhmmss}.txt",lineas);
            File.WriteAllLines($"{_guardar}\\{_tipoProceso}_volumetriaConDuplicador_{_cntRegistros}_{DateTime.Now:yyyyMMddhhmmss}.txt", lineasConDuplicados);

        }

        private static IGenerador ObtenerGeneradorPorProceso(TipoProceso tipoProceso, Random? random)
        {
            return tipoProceso switch
            {
                TipoProceso.BajaFraude => new GeneradorBajaFraude(),
                _ => throw new NotImplementedException(),
            };
        }

    }

    internal interface IGenerador
    {
        string GenerarLineas(Random? randon);
        string ObtenerIdentificador(Random? randon);
        string DuplicacionIdentificador { get; }
        int Columnas { get; }
    }

    internal enum TipoProceso
    {
        BajaFraude,
        BajaMora,

    }
}