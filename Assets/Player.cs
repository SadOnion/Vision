using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int clicks =1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool Use()
    {
        if(clicks > 0)
        {
            clicks--;
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
