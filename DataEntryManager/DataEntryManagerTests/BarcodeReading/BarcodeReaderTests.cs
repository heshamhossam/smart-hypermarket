using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BarcodeReading;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BarcodeReading.Tests
{
    [TestClass()]
    public class BarcodeReaderTests
    {
        class FakeLabel
        {
            public string Text;

            public void readBarcodes()
            {
                this.Text = "Ok";
            }
        }

        [TestMethod()]
        public void readBarcodesTest()
        {
            
            //BarcodeReader target = new BarcodeReader(;
        }

        [TestMethod()]
        public void openCameraTest()
        {
            //FakeLabel txtDecoderType = new FakeLabel(), txtDecoderContent = new Label();
            //WpfCap.CapPlayer player = new WpfCap.CapPlayer();
            //BarcodeReader barcodeReader = new BarcodeReader(ref (Label)txtDecoderType, ref txtDecoderContent, ref player);
            //Assert.AreEqual(false,barcodeReader.openCamera());
            //Assert.Fail();
        }

        [TestMethod()]
        public void BarcodeReaderTest()
        {
            Assert.Fail();
        }
    }
}
