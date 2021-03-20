using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance; 
    public static GameAssets Instance { 
        get {
            if (instance == null) {
                instance = Resources.Load<GameAssets>("GameAssets");
            }
            return instance;
        }
    }
    
    
    public Transform pfArrowProjectile;
   
    public Transform pfCannonProjectile;
    
    public Transform pfEnemy;
    public Transform pfArrowTower;


    //public Transform pfMineParticles;
    // public Transform pfEnemyDieParticles;
    // public Transform pfBuildingConstruction;

}
