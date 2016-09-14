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
using GalaSoft.MvvmLight.Messaging;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<BuildingInvoice>(this, "AddBuildingInvoiceWindow", (buildingInvoice) =>
            {
                var addBuildingInvoice=new AddBuildingInvoiceWindow(buildingInvoice);
                addBuildingInvoice.ShowDialog();
            });
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "AddServiceWindow")
            {
                var addservice = new AddServiceWindow();
                addservice.Show();
            }
            if (msg.Notification == "AddMainMeterWindow")
            {
                var addmainmeter = new AddMainMeterWindow();
                addmainmeter.Show();
            }
        }
    }
}
