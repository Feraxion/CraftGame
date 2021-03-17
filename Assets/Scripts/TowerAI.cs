using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
     [SerializeField] private float shootTimerMax;

    private float shootTimer;
    private Enemy targetEnemy;
    private float lookForTargetTimer;
    private float lookForTargetTimerMax = .2f;
    private Vector3 projectileSpawnPosition;
    



    [SerializeField] private float targetMaxRadius; 
    private void Awake() {
        projectileSpawnPosition = transform.Find("projectileSpawnPosition").position;

    }

    private void Update() {
        HandleTargeting();
        HandleShooting();
        
    }

    private void HandleTargeting() {
        lookForTargetTimer -= Time.deltaTime;
        if (lookForTargetTimer < 0f) {
            lookForTargetTimer += lookForTargetTimerMax;
            LookForTargets();
        }
    }

    private void HandleShooting() {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f) {
            shootTimer += shootTimerMax;
            if (targetEnemy != null) {
                if (gameObject.name.Contains("Arrow"))
                {
                    ArrowProjectile.Create(projectileSpawnPosition, targetEnemy);

                }
                else if (gameObject.name.Contains("Cannon"))
                {
                   // CannonProjectile.Create(projectileSpawnPosition, targetEnemy);
                   Debug.Log("Bum Bum");

                }

                
                
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        //elle ayarladim degisir
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position,targetMaxRadius);
        
    }

    private void LookForTargets() {
        //Gets mask for collider check
        LayerMask maska = LayerMask.GetMask("WhatIsEnemy");
            
        
        //Searchs colliders in layer mask to get enemy component
        Collider[] collider3DArray = Physics.OverlapSphere(transform.position, targetMaxRadius,maska);

        foreach (Collider collider3D in collider3DArray) {

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
            
        }

        if (collider3DArray.Length == 0)
        {
            targetEnemy = null;
        }
    }
}
