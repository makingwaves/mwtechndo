using System.Security.Cryptography.X509Certificates;

namespace WebApp.NETCore20.GraphAPI.Helpers
{
    public static class CertificateHelper
    {
        public static X509Certificate2 FindCertificateBySubjectName(string subjectName)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            try
            {
                store.Open(OpenFlags.OpenExistingOnly);
                X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, false);
                if (col == null || col.Count == 0)
                    return null;

                return col[0];
            }
            finally
            {
                store.Close();
            }
        }
    }
}
