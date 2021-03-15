using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    
    //States
    public float interactionRange;
    public bool playerInInteractionRange;
    
    public LayerMask whatIsEnemy;
    
    private float lookForTargetTimer;
    private float lookForTargetTimerMax = .2f;
    private float shootTimer;
    [SerializeField] private float shootTimerMax;
    
    private Enemy targetEnemy;
    private MineableOre targetOre;
    
    public float health;
    public StatSystem statSystem;
    

    
    [Header("Mine UI System")]
   // [SerializeField] GameObject mineNumPrefab;  ------> IF WE ADD VISUAL SYSTEM WE WILL NEED THIS CODE 
    [SerializeField] TMP_Text oresCount;

   private void Start()
   {
       InvokeRepeating("TextUpdater",1,0.3F);
   }

   

   

   private void Update()
   {
       health = statSystem.playerHealth;
       
       
       
       HandleTargeting();
       HandleShooting();

   }
   
   private void TextUpdater()
   {
       oresCount.text = GameDataSaver.oreAmount.ToString();

   }
   
   
   private void HandleTargeting() {
       lookForTargetTimer -= Time.deltaTime;
       if (lookForTargetTimer < 0f) {
           lookForTargetTimer += lookForTargetTimerMax;
           LookForTargets();
       }
   }
   
   private void LookForTargets() {
       //Gets mask for collider check
       LayerMask maska = LayerMask.GetMask("WhatIsEnemy");
            
        
       //Searchs colliders in layer mask to get enemy component
       Collider[] collider3DArray = Physics.OverlapSphere(transform.position, interactionRange,maska);

       //Get nearby objects with colliders in array
       foreach (Collider collider3D in collider3DArray)
       {

           Enemy enemy = collider3D.GetComponent<Enemy>();
           if (enemy != null) {

               // target yoksa direk aliyor
               if (targetEnemy == null) {
                   targetEnemy = enemy;
               } else { //daha yakin target varsa onu aliyor
                   if (Vector3.Distance(transform.position, enemy.transform.position) <
                       Vector3.Distance(transform.position, targetEnemy.transform.position)) {
                        
                       targetEnemy = enemy;
                        

                   }
               }
           }
           
           //same for ores
           MineableOre ore = collider3D.GetComponent<MineableOre>();

           if (ore != null)
           {
               // ENEMY OLSA DA OREU TARGETLIYOR OLMASI LAZIM ONCELIKLE
               if (targetOre == null) {
                   targetOre = ore;
               } else { //daha yakin target varsa onu aliyor
                   if (Vector3.Distance(transform.position, ore.transform.position) <
                       Vector3.Distance(transform.position, targetOre.transform.position)) {
                        
                       targetOre = ore;
                        

                   }
               }
           }
            
       }

       if (collider3DArray.Length == 0)
       {
           // YAKINDAKI OBJELERDE YOKSA RANGE DISINDA ONCEDEN ALDIGI TARGETA TEKRAR DALMASIN 
           targetEnemy = null;
           targetOre = null;
       }
   }
   
   

   private void HandleShooting() {
       shootTimer -= Time.deltaTime;
       if (shootTimer <= 0f) {
           shootTimer += shootTimerMax;
           if (targetEnemy != null) {
               
                   Debug.Log("Bum Bum");
                   //ATTACK KODU PLAYER ICIN

           }

           if (targetOre != null)
           {
               Debug.Log("Mine Bum");
               //MINE KODU PLAYER ICIN
               targetOre.Shatter();

           }
       }
       
       
   }

   private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ore"))
        {
            GameDataSaver.oreAmount++;
            Destroy(col.gameObject);
            //oresCount.text = GameDataSaver.oreAmount.ToString();
            //Adding mine visual system
        }
    }
   
   
   
   
   private void OnDrawGizmosSelected()
   {
      
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, interactionRange);
   }

}
