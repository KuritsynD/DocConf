using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using DocConf.Models;
using DocConf.ViewModels;
using DynamicData;
using MsBox.Avalonia;
using Splat.ApplicationPerformanceMonitoring;

namespace DocConf.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Load(object? sender, RoutedEventArgs e)
    {
        var clickLoad = new MainWindowViewModel();
        var devices = clickLoad.GetDevicesDefineObject();

        foreach (var device in devices)
        {
            switch (device.IdDevice)
            {
                case 0: 
                    useIVK1.IsChecked = device.Use == true;
                    connect1IVK1.IsChecked = device.DbConnectionStrings[0].Use == true;
                    server1IVK1.Text = device.DbConnectionStrings[0].Server;
                    connect2IVK1.IsChecked = device.DbConnectionStrings[1].Use == true;
                    server2IVK1.Text = device.DbConnectionStrings[1].Server;
                    foreach (var doc in device.Docs)
                    {
                        switch (doc.IdDoc)
                        {
                            case 0: 
                            useReportIVK1.IsChecked = doc.Use == true;
                            foreach (var template in doc.TemplateDocs)
                            {
                                switch (template.Id)
                                {
                                    case 0: reportIVK1.IsChecked = template.Use == true; break;
                                    case 1: reportUstLugaIVK1.IsChecked = template.Use == true; break;
                                }
                            }
                            break;
                            case 1: 
                                usePasportsIVK1.IsChecked = doc.Use == true;
                                foreach (var template in doc.TemplateDocs)
                                {
                                    switch (template.Id)
                                    {
                                        case 0: pasportIVK1.IsChecked = template.Use == true; break;
                                        case 1: pasportExpIVK1.IsChecked = template.Use == true; break;
                                        case 2: pasportGostGIVK1.IsChecked = template.Use == true; break;
                                        case 3: pasportGostIIVK1.IsChecked = template.Use == true; break;
                                        case 4: pasportMI13IVK1.IsChecked = template.Use == true; break;
                                        case 5: pasportMI14IVK1.IsChecked = template.Use == true; break;
                                        case 6: pasportProductIVK1.IsChecked = template.Use == true; break;
                                        case 7: pasportMI15IVK1.IsChecked = template.Use == true; break;
                                    }
                                }
                                break;
                            case 2: 
                                useActsIVK1.IsChecked = doc.Use == true;
                                foreach (var template in doc.TemplateDocs)
                                {
                                    switch (template.Id)
                                    {
                                        case 0: ActValIVK1.IsChecked = template.Use == true; break;
                                        case 1: ActPartiyIVK1.IsChecked = template.Use == true; break;
                                        case 2: ActProductIVK1.IsChecked = template.Use == true; break;
                                        case 3: ActPriemSdachaIVK1.IsChecked = template.Use == true; break;
                                        case 4: ActValPrilGIVK1.IsChecked = template.Use == true; break;
                                    }
                                }
                                break;
                            case 3: 
                                useJournalsIVK1.IsChecked = doc.Use == true;
                                foreach (var template in doc.TemplateDocs)
                                {
                                    switch (template.Id)
                                    {
                                        case 0: JournalNeftIVK1.IsChecked = template.Use == true; break;
                                        case 1: JournalProductIVK1.IsChecked = template.Use == true; break;
                                    }
                                }
                                break;
                            case 4: 
                                useMI3287IVK1.IsChecked = doc.Use == true;
                                foreach (var template in doc.TemplateDocs)
                                {
                                    switch (template.Id)
                                    {
                                        case 0: MI3287WorkPRIVK1.IsChecked = template.Use == true; break;
                                        case 1: MI3287ControlPRIVK1.IsChecked = template.Use == true; break;
                                    }
                                }
                                break;
                            case 5: 
                                useKMHPPCIIVK1.IsChecked = doc.Use == true;
                                foreach (var template in doc.TemplateDocs)
                                {
                                    switch (template.Id)
                                    {
                                        case 0: KMHCIIVK1.IsChecked = template.Use == true; break;
                                        case 1: KMHCITDVIVK1.IsChecked = template.Use == true; break;
                                    }
                                }
                                break;                  
                        }
                    }
                    break;
                case 1: 
                    useIVK2.IsChecked = device.Use == true;
                    break;
                case 2: 
                    useIVKRsu.IsChecked = device.Use == true; 
                    break;
            }
        }
    }

    private void Button_Save(object? sender, RoutedEventArgs e)
    {
        var clickSave = new MainWindowViewModel();
        
        var app = new AppConfig();
        var listDevices = new List<Devices>();
        
        var devices = new Devices();
        devices.Use = useIVK1.IsChecked;
        

        listDevices.Add(devices);
        app.Devices = listDevices;

        clickSave.SetDevicesDefineObject(app);

    }
}