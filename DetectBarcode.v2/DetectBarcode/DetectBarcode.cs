using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing;

namespace DataEntryManager
{
    public delegate void OnBarcodeDetectedDelegate();

    public partial class DetectBarcode : Form
    {
        public DetectBarcode()
        {
            InitializeComponent();
        }

        /// <summary>
        /// One of the functions to be fired when OnBarcodeDetectedDelegate fired as an example
        /// </summary>
        public void testDelegateFunction() {
            label1.Text = "Delegate fired";
        }

        /// <summary>
        /// Fired when Decode button clicked as an example of using BarcodeReader class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OnBarcodeDetectedDelegate testD = testDelegateFunction; //Testing variable for OnBarcodeDetectedDelegate
            BarcodeReader bcr = new BarcodeReader(ref txtDecoderType, ref txtDecoderContent, ref pictureBox1); //Testing variable for BarcodeReader class ( see constructor documentation )
            bcr.onBarcodeDetected += testD; //Adding the delegate function to onBarcodeDetected variable at bcr to fire it after detecting barcode emplicitily
            //If camera opened successfully read barcode and fire onBarcodeDetected delegate
            if (bcr.openCamera() == true)
                bcr.readBarcodes();
        }
    }

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

    public class BarcodeReader : IBarcodeReader
    {
        private WebCam wCam;                //WebCam object to manage conection with Web Camera
        private Timer webCamTimer;          //A timer object to manage amount of time between a capture of one frame and another
        //The form interface private elements
        private Label _txtDecoderType;
        private Label _txtDecoderContent;
        private PictureBox _pictureBox;
        //Event is called whenever the barcode is detected
        public OnBarcodeDetectedDelegate onBarcodeDetected { get; set; }

        /// <summary>
        /// Constructor of BarcodeReader class
        /// </summary>
        /// <param name="txtDecoderType">Referrence to a label which will hold the barcode detected type</param>
        /// <param name="txtDecoderContent">Referrence to a label which will hold the barcode detected content (id number)</param>
        /// <param name="pictureBox">Referrence to a PictureBox which will hold the Web Camera stream</param>
        public BarcodeReader(ref Label txtDecoderType, ref Label txtDecoderContent, ref PictureBox pictureBox)
        {
            _txtDecoderType = txtDecoderType;
            _txtDecoderContent = txtDecoderContent;
            _pictureBox = pictureBox;
        }

        /// <summary>
        /// Fired each tick to capture a frame and decode it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webCamTimer_Tick(object sender, EventArgs e)
        {
            var bitmap = wCam.GetCurrentImage();                        //Get an image and convert it to bitmap
            if (bitmap == null)                                         //Terminate if getting an image or converting failed
                return;
            var reader = new ZXing.BarcodeReader();                     //Initiate BarcodeReader object

            var result = reader.Decode(bitmap);                         //Decode the captured image
            
            //If decoding succeed put results on the form interface
            if (result != null)                                         
            {
                _txtDecoderType.Text = result.BarcodeFormat.ToString();
                _txtDecoderContent.Text = result.Text;
            }
        }

        public bool openCamera()
        {
            //If wCam has not initiated, inititate it with appropriate Picturebox and open connection with it
            if (wCam == null)
            {
                wCam = new WebCam { Container = _pictureBox };
                if(wCam == null)
                    return false;
                wCam.OpenConnection();
                return true;
            }
            //If wCam alread initiated, clear the previous data and reopen the connection with the camera
            else {
                webCamTimer.Stop();
                webCamTimer = null;
                wCam.Dispose();
                wCam = null;
                return openCamera();
            }
        }

        public void readBarcodes()
        {
            //If there is a connection with camera
            if (wCam != null)
            {
                webCamTimer = new Timer();              //Create a timer object
                webCamTimer.Tick += webCamTimer_Tick;   //Assign the decoder function to fire it each amount of time (interval)
                webCamTimer.Interval = 200;             //Assign interval of 200 milliseconds
                webCamTimer.Start();                    //Start the timer
                //Fire OnBarcodeDetectedDelegate
                onBarcodeDetected();
            }
        }

        
    }
}
