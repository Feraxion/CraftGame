using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public StatSystem statSystem;
    public GameObject gameOverScreen;
    public LayerMask whatIsGround, whatIsPlayer;
    public Animator animator;
    public float health;
    private float shootTimer;
    [SerializeField] private float shootTimerMax;
    public bool enemyIsAlive;
    public bool playerAlive;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Coin or health

    //public GameObject[] lootPrefab;
    int randLoot;
    public GameObject CoinPrefab;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        health = statSystem.enemyHealth;
        enemyIsAlive = true;
        playerAlive = true;
    }

    private void Update()
    {
        agent.SetDestination(player.position);
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        
        if (enemyIsAlive)
        {
            if (health <= 0)
            {
                enemyIsAlive = false;
                EnemyDeath();
                //animator.SetFloat("Health", 0);
                //Destroy(this.gameObject, 5f);
            }
        }

        if (!player.GetComponentInChildren<Player>().playerIsAlive)
        {
            playerAlive = false;
            animator.SetBool("IsAttack", false);

        }
        

        if (!playerInAttackRange)
        {
            animator.SetBool("IsAttack", false);

        }
        
        if (playerAlive)
        {
          //  if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
        

        
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        TakeDamage();
    //    }
    //}

    private void Patroling()
    {

        //SET DESTINATION TO BUILD 
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
        animator.SetFloat("Speed", 1);
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animator.SetFloat("Speed", 1);


    }

    private void AttackPlayer()
    {
        ////Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);


        if (playerInAttackRange)
        {

            if (!alreadyAttacked)
            {
                //playAnimation;
                animator.SetBool("IsAttack", true);
                //attack code
                statSystem.playerHealth = statSystem.playerHealth - statSystem.enemyDamage;
                Debug.Log("Atak yapıyor");
                //End of the attack code

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }




        //TAKE ATTACK and HEALTH STATS FROM CHARACTER CLASS

        //if (!alreadyAttacked)
        //{
        //    ///Attack code here
        //    Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //    rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        //    rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        //    ///End of attack code

        //    alreadyAttacked = true;
        //    Invoke(nameof(ResetAttack), timeBetweenAttacks);
        //}

    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void TakeDamage()
    {
        statSystem.enemyHealth -= statSystem.PlayerDamage;

        if (statSystem.enemyHealth <= 0)
        {
            animator.SetFloat("Health", statSystem.enemyHealth);
            Destroy(this.gameObject);
        }
    }
    private void EnemyDeath()
    {
        
        animator.SetFloat("Health", 0);
        //randLoot = Random.Range(0, 2);
        //Instantiate(lootPrefab[randLoot], transform.position, transform.rotation);
        DropCoin();
        animator.SetFloat("Speed", 0);
        agent.SetDestination(transform.position);
        Destroy(this.gameObject, 3f);
    }

    private void DropCoin()
    {
        Vector3 position = transform.position;
        GameObject coin = Instantiate(CoinPrefab, position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
        //coin.SetActive(true);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
