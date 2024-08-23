using DocConf.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using MsBox.Avalonia;
using Newtonsoft.Json.Linq;

namespace DocConf.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private const string sampleJsonFilePath = "CfgApp.json";

    
    public List<Devices> GetDevicesDefineObject()
    {
        using StreamReader reader = new(sampleJsonFilePath);
        var listDevices = JsonConvert.DeserializeObject<AppConfig>(reader.ReadToEnd());
        return listDevices.Devices;
    }
    
    public void SetDevicesDefineObject(AppConfig app)
    {
        
        var json =
            @"{
 ""Devices"": 
[{
 ""Use"": false,
""IdDevice"": 0
 }]
 }";
        
        using StreamReader reader = new(sampleJsonFilePath);
        var listDevices = JsonConvert.DeserializeObject<AppConfig>(reader.ReadToEnd());
        var jsonInDir = listDevices.Devices;
        reader.Close();

        var jsonEdit = app.Devices;

        var resultJson = jsonInDir.Join(jsonEdit,
            d => d.IdDevice,
            e => e.IdDevice,
            (d, e) => new Devices());

        using StreamWriter writer = new StreamWriter(sampleJsonFilePath, false);
        writer.WriteLineAsync(JsonConvert.SerializeObject(resultJson));
        var box = MessageBoxManager.GetMessageBoxStandard("Внимание", "Файл успешно сохранен!");
        box.ShowAsync();
        
        
        // using StreamReader reader = new(sampleJsonFilePath);
        // var jsonInDir = JObject.Parse(reader.ReadToEnd());
        // reader.Close();
        //
        // var jsonEdit = JObject.Parse(json);
        //
        // jsonInDir.Merge(jsonEdit);
        //
        // using StreamWriter writer = new StreamWriter(sampleJsonFilePath, false);
        // writer.WriteLineAsync(JsonConvert.SerializeObject(jsonInDir));
        // var box = MessageBoxManager.GetMessageBoxStandard("Внимание", "Файл успешно сохранен!");
        // box.ShowAsync();
  
    }
}