using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour {

    public static ArrowProjectile Create(Vector3 position, Enemy enemy) {
        Transform arrowTransform = Instantiate(GameAssets.Instance.pfArrowProjectile, position,Quaternion.Euler(-45,0,0)) ;
        ArrowProjectile arrowProjectile = arrowTransform.GetComponent<ArrowProjectile>();
        arrowProjectile.SetTarget(enemy);

        return arrowProjectile;
    }




    private Enemy targetEnemy;
    private Vector3 lastMoveDir;
    private float timeToDie = 4f;


    private void Update() {
        Vector3 moveDir;

        if (targetEnemy != null) {
            moveDir = (targetEnemy.transform.position - transform.position).normalized;
            lastMoveDir = moveDir;
        } else {
            moveDir = lastMoveDir;
        }

        float moveSpeed = 20f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        //transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVector(moveDir));

        timeToDie -= Time.deltaTime;
        if (timeToDie < 0f) {
            Destroy(gameObject);
        }
    }

    private void SetTarget(Enemy targetEnemy) {
        this.targetEnemy = targetEnemy;
    }

    private void OnCollisionEnter(Collision other)
    {////////////////////////////////////////////////
        Debug.Log("vuruldu");
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null) {
            // Hit an enemy!
            //int damageAmount = 10;
            enemy.GetComponent<EnemyAI>().health -= 30;
            //enemy.GetComponent<HealthSystem>().Damage(damageAmount);

            Destroy(this.gameObject);
        }    
    }

    private void OnTriggerEnter(Collider collision) {
        Debug.Log("Hasar vuruldu");
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) {
            // Hit an enemy!
            enemy.GetComponent<EnemyAI>().health -= 50;
            //int damageAmount = 10;
            //enemy.GetComponent<HealthSystem>().Damage(damageAmount);

            Destroy(this.gameObject);
        }
    }

}
