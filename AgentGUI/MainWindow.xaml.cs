﻿using System;
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

namespace AlfaBank.AlfaRobot.ControlAgent
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon TrayIcon = null;
        private ContextMenu TrayMenu = null;
        private WindowState fCurrentWindowState = WindowState.Normal;

        private bool CanCloseWindow = false;

        public WindowState CurrentWindowState
        {
            get { return fCurrentWindowState; }
            set { fCurrentWindowState = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool CreateTrayIcon()
        {
            bool result = false;
            if (TrayIcon == null)
            { 
                TrayIcon = new System.Windows.Forms.NotifyIcon();
                TrayIcon.Icon = AlfaBank.AlfaRobot.ControlAgent.Properties.Resources.switch_tray_m; 
                TrayIcon.Text = "AlfaRobot Control Agent."; 
                TrayMenu = Resources["trayMenu"] as ContextMenu;

                TrayIcon.Click += delegate(object sender, EventArgs e)
                {
                    if ((e as System.Windows.Forms.MouseEventArgs).Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        ShowHideMainWindow(sender, null);
                    }
                    else
                    {
                        TrayMenu.IsOpen = true;
                        Activate(); 
                    }
                };
                result = true;
            }
            else
            { 
                result = true;
            }
            TrayIcon.Visible = true;
            return result;
        }

        private void ShowHideMainWindow(object sender, RoutedEventArgs e)
        {
            TrayMenu.IsOpen = false; 
            if (IsVisible)
            {
                Hide();
            }
            else
            { 
                Show();
                WindowState = CurrentWindowState;
                Activate();
            }
        }

        private void showWinContextMenuItemClick(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void stopContextMenuItemClick(object sender, RoutedEventArgs e)
        {
            CanCloseWindow = true;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CanCloseWindow)
            {
                e.Cancel = true;
                ShowHideMainWindow(this, new RoutedEventArgs());
            }
            else 
            {
                TrayIcon.Visible = false;
            }
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            CreateTrayIcon();
        }
    }
}