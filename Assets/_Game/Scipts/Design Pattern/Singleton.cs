using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<singletonClass> : MonoBehaviour where singletonClass : MonoBehaviour
{
    private static singletonClass instance;
    public static singletonClass Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<singletonClass>();
                if(instance== null)
                {
                    instance = new GameObject().AddComponent<singletonClass>();
                }
            }
            return instance;
        }
    }
}
