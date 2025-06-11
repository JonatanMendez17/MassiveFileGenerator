namespace GeneradorArchivo.GeneradorProcesos
{
    internal class GeneradorBajaFraude : IGenerador
    {
        public string GenerarLineas(Random? random)
        {
            var customerIntegrationId = (long)(random!.NextDouble() * 99999999999999999);
            var reason = "FRAUDE";

            return $"{customerIntegrationId:D18}|{reason}";
        }

        public string ObtenerIdentificador(Random? random)
        {
            var assetId = (long)(random!.NextDouble() * 999999999999999999);
            return $"{assetId:D18}";
        }

        public string DuplicacionIdentificador => "1234567890123456789";

        public int Columnas => 3;
    }
}


