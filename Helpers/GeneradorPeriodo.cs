namespace Web_Api_Auto.Helpers
{
    public class GeneradorPeriodo
    {
        public static string GenerarPeriodoAleatorio()
        {
                int year = new Random().Next(2023, DateTime.Now.Year + 1);
                
                int month = new Random().Next(1, 99);
                
                return $"{year}/{month:D2}";
        
        }
    }
}
