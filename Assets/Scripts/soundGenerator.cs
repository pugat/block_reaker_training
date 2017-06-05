using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundGenerator : MonoBehaviour {

    static soundGenerator instance = null;

    private void Awake()
    {
        
        if (instance != null)
        {            
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
