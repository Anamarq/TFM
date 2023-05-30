
//Almacena los datos de los intentos y se convierte en Json

using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class TryData 
{
    public string Id;
    public string TotalMovs;
}

public class UserData
{
    public List<string> TotalMovs;
}

public class NameData
{
    //public class Data
    //{
    //    public string Name;
    //    public int Total;
    //}
    public List<string> ListData;
    public List<string> Total;
    //public List<Tuple<string, string>> ListData;
}
