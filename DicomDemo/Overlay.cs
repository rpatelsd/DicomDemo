using Dicom;
using Dicom.Imaging;
using Dicom.Imaging.Mathematics;
using Dicom.IO.Buffer;
using System;
using System.Drawing;

namespace DicomDemo
{
    public class Overlay
    {
        private static int overlayHeight = 100;
        private static int overlayWidth = 100;
        public static void OverlayFile(string fileName)
        {
            Color color = Color.Red;

            ImageManager.SetImplementation(WinFormsImageManager.Instance);

            DicomFile file = Utility.OpenFile(fileName);

            DicomDataset dataset = new DicomDataset();
            dataset = file.Dataset.Clone();

            var overlay = GenerateOverlay(dataset);

            var image = new DicomImage(overlay.Dataset);
            image.OverlayColor = Convert.ToInt32(color.ToArgb());

            image.RenderImage().AsClonedBitmap().Save(fileName + "-overlay.bmp");
            Console.WriteLine("Saved image with overlay as :" + fileName + "-overlay.bmp");
        }

        //TODO : Add quadrant for overlay?
        private static DicomOverlayData GenerateOverlay(DicomDataset dataSet)
        {
            ushort group = 0x6000;
            while (dataSet.Contains(new DicomTag(group, DicomTag.OverlayBitPosition.Element)))
            {
                group += 2;
            }

            var overlay = new DicomOverlayData(dataSet, group)
            {
                Type = DicomOverlayType.Graphics,
                Rows = overlayHeight,
                Columns = overlayWidth,
                OriginX = 1,
                OriginY = 1,
                BitsAllocated = 1,
                BitPosition = 1
            };

            var array = new BitList { Capacity = overlay.Rows * overlay.Columns };

            var position = 0;
            while (position < (overlay.Rows * overlay.Columns))
            {
                array[position] = true;
                position++;
            }

            overlay.Data = EvenLengthBuffer.Create(new MemoryByteBuffer(array.Array));
            return overlay;
        }
    }
}
