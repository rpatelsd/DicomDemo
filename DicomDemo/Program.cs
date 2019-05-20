using System;

namespace DicomDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Overlay.OverlayFile(@"c:\temp\Anonymized20190519.dcm");

            TagUpdate.UpdatePatientTag(@"c:\temp\Anonymized20190519.dcm", "FirstName LastName");

            TagUpdate.ReadPatientTag(@"c:\temp\Anonymized20190519-tagupdate.dcm");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
