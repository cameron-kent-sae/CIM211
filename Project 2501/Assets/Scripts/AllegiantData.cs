using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Packet", menuName = "DataPacket/AllegiantData") ]
public class AllegiantData : DataPacket
{
    private void Awake()
    {
        dataType = DataType.Allegiant;
    }
}