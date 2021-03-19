using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatSystem : MonoBehaviour
{

    public float enemyHealth, playerHealth,maxPlayerHealth;
    public float enemyAttack, playerAttack;
    public float enemyDamage, PlayerDamage;
    public int coinDropAmount;

    public int PlayerHealthModifier;
    public int EnemyHealthModifier;
    

    public void Awake()
    {
    
       
    }


    private void Start()
    {
        CalculateStats();

    }

    private void Update()
    {
        if (playerHealth >= maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
    }


    void CalculateStats()
    {
        maxPlayerHealth = 100 + (GameDataSaver.forgeHealthLevel * PlayerHealthModifier);
        playerHealth = maxPlayerHealth;
        playerAttack = 10 + (GameDataSaver.forgeAttackLevel * 5);

        enemyAttack = 10 + (GameDataSaver.forgeHealthLevel * 8);
        enemyHealth = 10 + (GameDataSaver.forgeAttackLevel * EnemyHealthModifier);
        
        PlayerDamage = Random.Range(playerAttack -5, playerAttack + 5);


        enemyDamage = Random.Range(enemyAttack -5, enemyAttack + 5);
        enemyHealth = Random.Range(enemyHealth -5, enemyHealth + 5);

        
    }

    void DropsCalculator()
    {
        coinDropAmount = UnityEngine.Random.Range(1,5) * GameDataSaver.currentZoneLevel;
    }
    
    
}
