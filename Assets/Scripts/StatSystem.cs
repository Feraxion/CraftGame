using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatSystem : MonoBehaviour
{

    public float enemyHealth, playerHealth;
    public float enemyAttack, playerAttack;
    public float enemyDamage, PlayerDamage;
    public int coinDropAmount;

    private void Awake()
    {
        CalculateStats();
    }

    void CalculateStats()
    {
        playerHealth = 100 + (GameDataSaver.forgeHealthLevel * 10);
        playerAttack = 10 + (GameDataSaver.forgeAttackLevel * 5);

        enemyAttack = 10 + (GameDataSaver.forgeHealthLevel * 8);
        enemyHealth = 10 + (GameDataSaver.forgeAttackLevel * 8);

        enemyDamage = Random.Range(enemyAttack -5, enemyAttack + 5);
        enemyHealth = Random.Range(enemyHealth -5, enemyHealth + 5);

    }

    void DropsCalculator()
    {
        coinDropAmount = UnityEngine.Random.Range(1,5) * GameDataSaver.currentZoneLevel;
    }
    
    
}
