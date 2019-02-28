using UnityEngine;

public class CollectPlayerController : PlayerController
{
    //Attack
    bool canFire;
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public AudioClip fireSound;
    public Transform fireEnd;
    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    //Animation
    Animator playerAnim;
    bool isWalking;
    int floorMask;
    float camRayLength = 100f;

    //Health
    public AudioClip hurtSound;
    public AudioClip deathClip;
    public int MaxHealth = 100;
    int currentHealth;
    bool isDamaged;
    DamageEffect damageEffect;

    void Awake()
    {
        base.Init();
        //attack
        canFire = true;
        timer = 0f;
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles=GetComponentInChildren<ParticleSystem>();
        gunLine=GetComponentInChildren<LineRenderer>();
        gunLight=GetComponentInChildren<Light>();
        //move
        playerAnim = GetComponent<Animator>();
        isWalking = false;
        floorMask = LayerMask.GetMask("Floor");
        //health
        currentHealth = MaxHealth;
        isDamaged = false;
        damageEffect = GetComponent<DamageEffect>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (canFire && Input.GetButton("Fire1") && timer>=timeBetweenBullets)
            Fire();

        if (timer>=(timeBetweenBullets*effectsDisplayTime))
            DisableEffects();

        if (isDamaged)
            damageEffect.showEffect(true);
        else
            damageEffect.showEffect(false);

        isDamaged = false;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Move();
            Turning();
            MoveAnim();
        }
    }

    void Move()
    {
        GetAxisMove(true);
        playerStatus = PlayerStatus.MOVE;
        movement.Set(moveHorizontal,0f,moveVertical);
        movement = movement.normalized*speed*Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay,out floorHit,camRayLength,floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }

    void MoveAnim()
    {
        if (moveHorizontal == 0 && moveVertical == 0)
            isWalking = false;
        else
            isWalking = true;
        playerAnim.SetBool("IsWalking", isWalking);
    }

    void Fire()
    {
        timer = 0f;

        SoundMgr.Instance.PlaySound(fireSound);

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, fireEnd.position);

        shootRay.origin = fireEnd.position;
        shootRay.direction = fireEnd.forward;

        if (Physics.Raycast(shootRay,out shootHit,range,shootableMask))
        {
            CollectEnemyController enemyController = shootHit.collider.GetComponent<CollectEnemyController>();

            if (enemyController)
            {
                enemyController.TakeDamage(damagePerShot, shootHit.point);
            }

            gunLine.SetPosition(1, shootHit.point);
        }

        else
        {
            gunLine.SetPosition(1, shootRay.origin+shootRay.direction*range);
        }

    }

    void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    public void TakeDamage(int amount)
    {
        isDamaged = true;
        currentHealth=UIMgr.Instance.TakeHealth(currentHealth, amount);
        SoundMgr.Instance.PlaySound(hurtSound);
        if (currentHealth<=0)
            EventMgr.Instance.PlayerDead();
    }

    public override void Death()
    {
        playerAnim.SetTrigger("Die");
        SoundMgr.Instance.PlayMusic(deathClip);
        damageEffect.enabled = false;
        DisableEffects();
        canFire = false;
        base.Death();
    }

    public override void WinAction()
    {
        playerAnim.enabled = false;
        DisableEffects();
        canFire = false;
        base.WinAction();
    }
}
