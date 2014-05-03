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
using System.Windows.Threading;
using WpfCap;
using ZXing;

using BarcodeReader = ZXing.Presentation.BarcodeReader;
using BarcodeWriter = ZXing.Presentation.BarcodeWriter;
using BarcodeWriterGeometry = ZXing.Presentation.BarcodeWriterGeometry;

namespace BarcodeReading
{
    public delegate void OnBarcodeDetectedDelegate();

    public class BarcodeReader : IBarcodeReader
    {
        private DispatcherTimer webCamTimer;          //A timer object to manage amount of time between a capture of one frame and another
        //The form interface private elements
        private Label _txtDecoderType;
        private Label _txtDecoderContent;
        private CapPlayer _player;
        private TextBox _txtDecoderTypeBox;
        private TextBox _txtDecoderContentBox;
        private readonly ZXing.Presentation.BarcodeReader reader = new ZXing.Presentation.BarcodeReader(); //Initiate BarcodeReader object
        //Event is called whenever the barcode is detected
        public OnBarcodeDetectedDelegate onBarcodeDetected { get; set; }

        /// <summary>
        /// Constructor of BarcodeReader class
        /// </summary>
        /// <param name="txtDecoderType">Referrence to a label which will hold the barcode detected type</param>
        /// <param name="txtDecoderContent">Referrence to a label which will hold the barcode detected content (id number)</param>
        /// <param name="pictureBox">Referrence to a PictureBox which will hold the Web Camera stream</param>
        public BarcodeReader(ref Label txtDecoderType, ref Label txtDecoderContent, ref CapPlayer player)
        {
            _txtDecoderType = txtDecoderType;
            _txtDecoderContent = txtDecoderContent;
            _player = player;
        }

        public BarcodeReader(ref Label txtDecoderContent, ref CapPlayer player)
        {
            _txtDecoderContent = txtDecoderContent;
            _player = player;
        }

        public BarcodeReader(ref TextBox txtDecoderTypeBox, ref TextBox txtDecoderContentBox, ref CapPlayer player)
        {
            _txtDecoderTypeBox = txtDecoderTypeBox;
            _txtDecoderContentBox = txtDecoderContentBox;
            _player = player;
        }

        public BarcodeReader(ref TextBox txtDecoderContentBox, ref CapPlayer player)
        {
            _txtDecoderContentBox = txtDecoderContentBox;
            _player = player;
        }

        /// <summary>
        /// Fired each tick to capture a frame and decode it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webCamTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                var result = reader.Decode((BitmapSource)_player.Source);   //Get an image, convert it to bitmap and decode it
                if (result != null) //Terminate if getting an image, converting or decoding process failed
                {
                    if (_txtDecoderType != null)
                        _txtDecoderType.Content = result.BarcodeFormat.ToString();
                    if (_txtDecoderContent != null)
                        _txtDecoderContent.Content = result.Text;
                    if (_txtDecoderTypeBox != null)
                        _txtDecoderTypeBox.Text = result.BarcodeFormat.ToString();
                    if (_txtDecoderContentBox != null)
                        _txtDecoderContentBox.Text = result.Text;
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Camera is being used by another application !");
            }
        }

        public bool openCamera()
        {
            return _player.IsEnabled;
        }

        public void readBarcodes()
        {
            webCamTimer = new DispatcherTimer();                    //Create a timer object
            webCamTimer.Tick += webCamTimer_Tick;                   //Assign the decoder function to fire it each amount of time (interval)
            webCamTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);   //Assign interval of 200 milliseconds
            webCamTimer.Start();                                    //Start the timer
            //Fire OnBarcodeDetectedDelegate
            onBarcodeDetected();
        }
        ~BarcodeReader() {
            _player.Dispose();
        }
    }
}
