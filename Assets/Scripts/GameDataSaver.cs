using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSaver : MonoBehaviour
{

    //OYUN BASINDA VARIABLELAR BURADAN ALINIYOR KAYIT EDILDI ISE, EDILMEDIYSE DEFAULT VALUE 0
    public static void GetData()
    {
        oreAmount = PlayerPrefs.GetInt("oreAmount", 0);
        stoneMineLevel = PlayerPrefs.GetInt("stoneMineLevel", 1);
        currentZoneLevel = PlayerPrefs.GetInt("currentZoneLevel", 1);
        forgeAttackLevel = PlayerPrefs.GetInt("forgeAttackLevel", 1);
        forgeHealthLevel = PlayerPrefs.GetInt("forgeHealthLevel", 1);
        coinAmount = PlayerPrefs.GetInt("coinAmount", 555);
        stoneMineStoredOreAmount = PlayerPrefs.GetInt("stoneMineStoredOreAmount", 1);
        healingBuildingLevel = PlayerPrefs.GetInt("healingBuildingLevel", 1);


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
    
    public static int coinAmount;
    public static int stoneMineLevel;
    public static int currentZoneLevel;
    public static int forgeAttackLevel,forgeHealthLevel;
    public static int healingBuildingLevel;

    public static int oreAmount;
    public static int stoneMineStoredOreAmount;




    private void Awake()
    {
        GetData();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void SaveData()
    {
        //Yeni variablelar burada kaydediliyor
        PlayerPrefs.SetInt("coinAmount",coinAmount);

        PlayerPrefs.SetInt("oreAmount",oreAmount);
        PlayerPrefs.SetInt("stoneMineLevel",stoneMineLevel);
        PlayerPrefs.SetInt("currentZoneLevel",currentZoneLevel);
        PlayerPrefs.SetInt("forgeAttackLevel",forgeAttackLevel);
        PlayerPrefs.SetInt("forgeHealthLevel",forgeHealthLevel);
        PlayerPrefs.SetInt("stoneMineStoredOreAmount",stoneMineStoredOreAmount);
        PlayerPrefs.SetInt("healingBuildingLevel",healingBuildingLevel);


        PlayerPrefs.Save();
        
    }    
    

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
