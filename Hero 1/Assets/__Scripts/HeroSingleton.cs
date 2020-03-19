using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSingleton : MonoBehaviour
{
    private static HeroSingleton instance = null;

    // Game Instance Singleton
    public static HeroSingleton Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
