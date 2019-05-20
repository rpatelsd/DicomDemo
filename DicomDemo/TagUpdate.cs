using Dicom;
using System;

namespace DicomDemo
{
    public class TagUpdate
    {
        public static void UpdatePatientTag(string fileName, string patientName)
        {
            DicomFile file = Utility.OpenFile(fileName);
            file.Dataset.AddOrUpdate(DicomTag.PatientName, patientName);
            file.Save(fileName.Replace(".dcm", "") + "-tagupdate.dcm");
            Console.WriteLine("Updated dicomtag patientname to : " + patientName);
        }

        public static void ReadPatientTag(string fileName)
        {
            Console.WriteLine("Reading Patient Tag");
            DicomFile file = Utility.OpenFile(fileName);
            var tag = file.Dataset.GetSingleValue<string>(DicomTag.PatientName);
            Console.WriteLine("Dicomtag patientname is : " + tag);
        }
    }
}
