using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFMpegSharp;
using FFMpegSharp.FFMPEG;
using FFMpegSharp.FFMPEG.Enums;
using FFMpegSharp.Enums;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        string pathin;
        string pathout;
        public Form1()
        {
            InitializeComponent();
            // C:/Users/User/Desktop/test/scarlxrd.webm
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pathin = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var video = new VideoInfo(pathin);
            string output = video.ToString();
            textBox2.Text = output;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pathout = textBox3.Text;
            var encoder = new FFMpeg();
            FileInfo outputFile = new FileInfo(pathout);
            var video = VideoInfo.FromPath(pathin);

            // MP4 conversion
            encoder.Convert(
                video,
                outputFile,
                VideoType.Mp4,
                Speed.UltraFast,
                VideoSize.Original,
                AudioQuality.Hd,
                true
            );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pathout = textBox3.Text;
            var encoder = new FFMpeg();
            FileInfo outputFile = new FileInfo(pathout);
            var video = VideoInfo.FromPath(pathin);
            // Webm conversion
            encoder.Convert(
                video,
                outputFile,
                VideoType.WebM,
                Speed.UltraFast,
                VideoSize.Original,
                AudioQuality.Hd,
                true
            );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pathout = textBox3.Text;
            var encoder = new FFMpeg();
            FileInfo outputFile = new FileInfo(pathout);
            var video = VideoInfo.FromPath(pathin);
            // OGV conversion
            encoder.Convert(
                video,
                outputFile,
                VideoType.Ogv
            );
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pathout = textBox3.Text;
            string inputVideoFile = pathin, outputAudioFile = pathout;
            new FFMpeg().ExtractAudio(VideoInfo.FromPath(inputVideoFile),new FileInfo(outputAudioFile));
        }
    }
}
