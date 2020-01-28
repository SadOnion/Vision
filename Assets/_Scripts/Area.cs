using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    bool filed = false;
    public static int AreasFiled {get;private set;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(filed == false)
        {
            filed=true;
            AreasFiled++;
        }
        Debug.Log(AreasFiled);
    }
}
