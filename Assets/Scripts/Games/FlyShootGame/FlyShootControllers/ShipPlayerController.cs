using UnityEngine;

public class ShipPlayerController : PlayerController
{
    //Move
    public float tilt;
    public Boundary playerBoundary;

    //Fire
    public Transform shooter;
    public GameObject lazer;
    public float fireRate;
    float nextFire;
    public AudioClip fireSound;

    //Death
    public GameObject playerExplosion;
    public AudioClip deathSound;
    
    void Awake()
    {
        base.Init();
    }

    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time>nextFire)
            Fire();
    }

    void FixedUpdate()
    {
        if (canMove)
            Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        if (other.tag == "Enemy")
            EventMgr.Instance.PlayerDead();
    }

    void Move()
    {
        GetAxisMove();
        playerStatus = PlayerStatus.MOVE;
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity=movement * speed;

        //Set player section boundary
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, playerBoundary.xMin, playerBoundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, playerBoundary.zMin, playerBoundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, (-tilt)*rb.velocity.x);
        playerStatus = PlayerStatus.DEFAULT;
    }

    void Fire()
    {
        nextFire = Time.time + fireRate;
        Instantiate(lazer, shooter.position, shooter.rotation);
        SoundMgr.Instance.PlaySound(fireSound);
    }

    public override void Death()
    {
        Instantiate(playerExplosion, transform.position, transform.rotation);
        SoundMgr.Instance.PlaySound(deathSound);
        base.Death();
    }
}
