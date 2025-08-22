public class CertificadoHelper
{
    public static string GenerarCodigoCertificado(int nroCertificado, int anioCertificado, int nroSucursal)
    {
        return $"{nroCertificado}/{anioCertificado}{nroSucursal}";
    }


    public static string GenerarCodigoQR(int nroCertificado, int anioCertificado, int nroSucursal)
    {
        return $"{nroCertificado}{anioCertificado}{nroSucursal}";
    }

}