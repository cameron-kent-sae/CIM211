using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DataType
{
    Allegiant, Divegent, Insurgent
}

public class DataPacket : ScriptableObject
{
    public DataType dataType;
    public string url;
    public string description;
}
