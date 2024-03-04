using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesAyarı : MonoBehaviour
{
    private static GameObject instance;
    private void Awake()
    { 
        DontDestroyOnLoad(gameObject); // objenın sahneler arasında yok olmadan çalışmasını sağlar
        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
