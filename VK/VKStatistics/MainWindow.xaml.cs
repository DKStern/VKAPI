using System;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VKStatistics
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// API VK
        /// </summary>
        private static VkApi API;
        public MainWindow()
        {
            InitializeComponent();

            string file = "", accesToken = "";
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                file = dialog.FileName;
            }
            if (!string.IsNullOrEmpty(file))
            {
                using (var sr = new StreamReader(file))
                {
                    accesToken = sr.ReadLine();
                }
            }

            API = new VkApi();

            API.Authorize(new ApiAuthParams
            {
                AccessToken = accesToken
            });
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
