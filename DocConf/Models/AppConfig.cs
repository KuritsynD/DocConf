using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DocConf.Models;

public class AppConfig
{
    public List<Devices> Devices { get; set; }
}

public class Devices
{
    public bool? Use { get; set; }
    public int IdDevice { get; set; }
    public string? Name { get; set; }
    public List<Docs> Docs { get; set; }
    public List<DBConnectionStrings> DbConnectionStrings { get; set; }
}       

public class Docs
{
    public bool? Use { get; set; }
    public int IdDoc { get; set; }
    public string? Name { get; set; }
    public List<TemplateDocs> TemplateDocs { get; set; }
}

public class TemplateDocs
{
    public bool? Use { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class DBConnectionStrings
{
    public bool? Use { get; set; }
    public string? Server { get; set; }
}

public class ReadAndParseJsonFile
{
    
}