﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSaver : MonoBehaviour
{

    //OYUN BASINDA VARIABLELAR BURADAN ALINIYOR KAYIT EDILDI ISE, EDILMEDIYSE DEFAULT VALUE 0
    public static void GetData()
    {
        oreAmount = PlayerPrefs.GetInt("oreAmount", 0);
    }
    
    //DOKUNMA////////////////////////
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void RuntimeInit()
    {
        if (GameObject.FindWithTag("DataSaver") != null)
            return;

        var go = new GameObject { name = "[DataSaver]" };
        go.AddComponent<GameDataSaver>();
        DontDestroyOnLoad(go);
    }

    //YENI VARIABLELAR
    public static int oreAmount;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void SaveData()
    {
        //Yeni variablelar burada kaydediliyor
        PlayerPrefs.SetInt("oreAmount",oreAmount);
        PlayerPrefs.Save();
        
    }    
    

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
