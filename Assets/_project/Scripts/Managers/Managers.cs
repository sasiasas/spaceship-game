using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // singleton patern:
    static Managers _instance;

    // when the script instance is being loaded
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;  
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
