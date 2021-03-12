using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Create(Vector3 position)
    {
        //spawn noktasi verecegik
        Transform enemyTransform = Instantiate(GameAssets.Instance.pfEnemy, position, Quaternion.identity);
            Enemy enemy = enemyTransform.GetComponent<Enemy>();
            return enemy;

    }

    private HealthSystem healthSystem;

    private void Start() {
        
      //  healthSystem = GetComponent<HealthSystem>();
       // healthSystem.OnDamaged += HealthSystem_OnDamaged;
       // healthSystem.OnDied += HealthSystem_OnDied;

        
    }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e) {
        
        
    }

    private void HealthSystem_OnDied(object sender, System.EventArgs e) {
        
        
        //Instantiate(GameAssets.Instance.pfEnemyDieParticles, transform.position, Quaternion.identity);
        Destroy(gameObject,0.7f);
        
    }

    

    

    


    
}
