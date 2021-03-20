using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    //States
    public float interactionRange;
    public bool playerInInteractionRange;
    public PlayerMovement playerMovement;
    public LayerMask whatIsEnemy;
    public Animator animator;
    public bool playerIsAlive;

    private float lookForTargetTimer;
    private float lookForTargetTimerMax = .2f;
    private float shootTimer;
    [SerializeField] private float shootTimerMax;

    private Enemy targetEnemy;
    private MineableOre targetOre;

    public StatSystem statSystem;
    public float health;



    [Header("Mine UI System")]
    // [SerializeField] GameObject mineNumPrefab;  ------> IF WE ADD VISUAL SYSTEM WE WILL NEED THIS CODE 
    [SerializeField] TMP_Text oresCount;
    
    
    [Header("Coin UI System")]
    // [SerializeField] GameObject mineNumPrefab;  ------> IF WE ADD VISUAL SYSTEM WE WILL NEED THIS CODE 
    [SerializeField] TMP_Text coinCount;

    private void Start()
    {
        InvokeRepeating("TextUpdater", 1, 0.3F);
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerIsAlive = true;
    }





    private void Update()
    {

        //statSystem.playerHealth = health;
        health = statSystem.playerHealth;

        


        if (statSystem.playerHealth <= 0)
        {
            playerIsAlive = false;
            statSystem.playerHealth = 0;
            animator.SetFloat("Health", statSystem.playerHealth);
            //playerMovement.animator.SetFloat("Health", statSystem.playerHealth);
            playerMovement.enabled = false;
            // gameOverScreen.SetActive(true);
        }

        if (statSystem.playerHealth > 0)
        {
            playerIsAlive = true;
            HandleTargeting();
            HandleShooting();
        }
    }

    private void TextUpdater()
    {
        oresCount.text = GameDataSaver.oreAmount.ToString();
        coinCount.text = GameDataSaver.coinAmount.ToString();

    }


    private void HandleTargeting()
    {
        lookForTargetTimer -= Time.deltaTime;
        if (lookForTargetTimer < 0f)
        {
            lookForTargetTimer += lookForTargetTimerMax;
            LookForTargets();
        }
    }

    private void LookForTargets()
    {
        //Gets mask for collider check
        LayerMask maska = LayerMask.GetMask("WhatIsEnemy");


        //Searchs colliders in layer mask to get enemy component
        Collider[] collider3DArray = Physics.OverlapSphere(transform.position, interactionRange, maska);

        //Get nearby objects with colliders in array
        foreach (Collider collider3D in collider3DArray)
        {

            Enemy enemy = collider3D.GetComponent<Enemy>();
            if (enemy != null)
            {

                // target yoksa direk aliyor
                if (targetEnemy == null)
                {
                    targetEnemy = enemy;
                }
                else
                { //daha yakin target varsa onu aliyor
                    if (Vector3.Distance(transform.position, enemy.transform.position) <
                        Vector3.Distance(transform.position, targetEnemy.transform.position))
                    {

                        targetEnemy = enemy;


                    }
                }
            }

            //same for ores
            MineableOre ore = collider3D.GetComponent<MineableOre>();

            if (ore != null)
            {
                // ENEMY OLSA DA OREU TARGETLIYOR OLMASI LAZIM ONCELIKLE
                if (targetOre == null)
                {
                    targetOre = ore;
                }
                else
                { //daha yakin target varsa onu aliyor
                    if (Vector3.Distance(transform.position, ore.transform.position) <
                        Vector3.Distance(transform.position, targetOre.transform.position))
                    {

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
            //playerMovement.animator.SetBool("IsAttack", false);

        }
    }



    private void HandleShooting()
    {

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            shootTimer += shootTimerMax;
            if (targetEnemy != null)
            {

                Debug.Log("Player Atak");
                animator.SetTrigger("Attack");
                targetEnemy.GetComponent<EnemyAI>().health -= statSystem.PlayerDamage * 1000;
                //statSystem.enemyHealth -= statSystem.PlayerDamage * 1000;
                //ATTACK KODU PLAYER ICIN
                // playerMovement.animator.SetBool("IsAttack",true);
            }

            if (targetOre != null)
            {
                //Play an attack animation    
                animator.SetTrigger("Attack");
                Debug.Log("Mine Bum");
                //MINE KODU PLAYER ICIN
                targetOre.Shatter();
            }
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("ShatteredOre"))
        {
            GameDataSaver.oreAmount+=10;
            Destroy(col.gameObject);
            Debug.Log("Getting Mine");
            //oresCount.text = GameDataSaver.oreAmount.ToString();
            //Adding mine visual system
        }
        if (col.gameObject.CompareTag("CoinObj"))
        {
            int coinRange = Random.Range(0, 10);
            GameDataSaver.coinAmount += coinRange;
            TextUpdater();
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("HealthObj"))
        {
            statSystem.playerHealth += 50;
            Destroy(col.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }

}
