using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }


    private void Update()
    {
        if(Global.vidas == 0)
        {
            Debug.Log("Dead");

        }

    }

    public void Choque()
    {
        Global.vidas--;
        AudioManger.Instance.DeathSound();
        
    }


}
