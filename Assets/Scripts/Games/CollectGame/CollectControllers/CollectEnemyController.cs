
using UnityEngine;
using UnityEngine.AI;

public class CollectEnemyController : EnemyController
{
    //Enemy move
    Transform player;
    NavMeshAgent nav;

    //Enemy attack
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    CollectPlayerController collectPlayerController;
    Animator enemyAnim;
    bool playerInRange;
    float timer;

    //Enemy health
    public AudioClip hurtSound;
    public int MaxHealth = 50;
    int currentHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        collectPlayerController = player.GetComponent<CollectPlayerController>();
        nav = GetComponent<NavMeshAgent>();
        enemyAnim=GetComponent<Animator>();
        timer = 0f;
        currentHealth = MaxHealth;
    }

    void Update()
    {
        if (PlayerController.GetPlayerStatus() != PlayerStatus.DEAD)
        {
            nav.SetDestination(player.position);
            timer += Time.deltaTime;
            if (timer > timeBetweenAttacks && playerInRange && currentHealth > 0f)
            {
                timer = 0f;
                collectPlayerController.TakeDamage(attackDamage);
            }
        }
            
        else
        {
            enemyAnim.SetTrigger("IsPlayerDead");
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform==player)
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform == player)
            playerInRange = false;
    }
}
