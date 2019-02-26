using UnityEngine;

public class CollectPlayerController : PlayerController
{
    //Player attack
    

    //Player Animation
    Animator playerAnim;
    bool isWalking;
    int floorMask;
    float camRayLength = 100f;

    //Player health
    public AudioClip hurtSound;
    public AudioClip deathClip;
    public int MaxHealth = 100;
    public int currentHealth;
    bool isDamaged;
    DamageEffect damageEffect;

    void Awake()
    {
        base.Init();
        playerAnim = GetComponent<Animator>();
        isWalking = false;
        floorMask = LayerMask.GetMask("Floor");
        currentHealth = MaxHealth;
        isDamaged = false;
        damageEffect = GetComponent<DamageEffect>();
    }

    void Update()
    {
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
        base.Death();
    }
}
