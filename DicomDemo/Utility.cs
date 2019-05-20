using Dicom;
using System;

namespace DicomDemo
{
    public class Utility
    {
        public static DicomFile OpenFile(string fileName)
        {
            DicomFile file = null;
            try
            {
                file = DicomFile.Open(fileName);
            }
            catch (DicomFileException)
            {
                throw new Exception(String.Format("Issue opening file. Please verify that file exists. {0}", fileName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return file;
        }

    }
}
