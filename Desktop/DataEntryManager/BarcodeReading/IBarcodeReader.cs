using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarcodeReading
{
    interface IBarcodeReader
    {
        /// <summary>
        /// Opens the webcam of computer
        /// </summary>
        /// <returns>Boolean true if camera is open successfuly, false if some error happened and not open</returns>
        bool openCamera();

        /// <summary>
        /// Take a frame from camera and try to convert it into a barcode if succeeded then fire the onBarcodeDetected event
        /// </summary>
        void readBarcodes();
    }
}
