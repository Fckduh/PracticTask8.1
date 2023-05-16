using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Aspose.BarCode;
using Microsoft.Win32;
using System.IO;
using Path = System.IO.Path;
using System.Drawing;
using System.Drawing.Imaging;
using Color = System.Drawing.Color;
using Aspose.BarCode.Generation;
using System.Runtime.InteropServices.ComTypes;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Data.Entity;
using PracticTask8.Ado;
using System.ComponentModel;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Interop;
using static System.Net.Mime.MediaTypeNames;

namespace PracticTask8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public static lolEntities lol = new lolEntities();
        public static ObservableCollection<Images3> images3s = new ObservableCollection<Images3>(lol.Images3);
        public class Barcode
    {
           
            
        public string text { get; set; }
        public BaseEncodeType BarcodeType { get; set; }
        public BarCodeImageFormat ImageType { get; set; }
           
    }
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        public MainWindow()
        {
            InitializeComponent();
            for (int i = images3s.Count - 1; i >= 0; i--)
            {
                lol.Images3.Remove(images3s[i]);
                lol.SaveChanges();
                images3s.Remove(images3s[i]);
            }
            Images3 s = new Images3();
            s.GenerateBarcode();
            foreach (var coun in images3s)
                lol.Images3.Add(coun);
            lol.SaveChanges();
           foreach(var i in images3s)
            listochek.Items.Add(i.Num);
        }
       
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listochek_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var stream = new MemoryStream(images3s[int.Parse(listochek.SelectedItem.ToString())].Barcodes);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            imgdynamic.Source = image;

        }
    }
}
