
using UnityEngine;
using UnityEngine.AI;

public class CollectEnemyController : EnemyController
{
    Animator enemyAnim;

    //Enemy move
    Transform player;
    NavMeshAgent nav;

    //Enemy attack
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    CollectPlayerController collectPlayerController;
    bool playerInRange;
    float timer;

    //Enemy health
    public AudioClip hurtSound;
    public int maxHealth = 100;
    int currentHealth;

    //Enemy death
    public AudioClip deathClip;
    public float sinkSpeed = 2.5f;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    void Awake()
    {
        base.Init();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        collectPlayerController = player.GetComponent<CollectPlayerController>();
        nav = GetComponent<NavMeshAgent>();
        enemyAnim=GetComponent<Animator>();
        timer = 0f;
        currentHealth = maxHealth;
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        //Dead effect
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
        //Attack
        else if (PlayerController.GetPlayerStatus() != PlayerStatus.DEAD && 
                 PlayerController.GetPlayerStatus() != PlayerStatus.WIN && 
                 currentHealth>0)
        {
            nav.SetDestination(player.position);
            timer += Time.deltaTime;
            if (timer > timeBetweenAttacks && playerInRange)
            {
                timer = 0f;
                collectPlayerController.TakeDamage(attackDamage);
            }
        }
        else
        {
            nav.enabled = false;
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

    public void TakeDamage(int amount,Vector3 hitPoint)
    {
        if (isDead)
            return;

        SoundMgr.Instance.PlaySound(hurtSound);

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
            DeathEffect();

    }

    void DeathEffect()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        enemyAnim.SetTrigger("IsDead");

        SoundMgr.Instance.PlaySound(deathClip);
    }

    public void StartSinking()
    {
        nav.enabled = false;

        rb.isKinematic = true;

        isSinking = true;

        base.Death();
    }
}
