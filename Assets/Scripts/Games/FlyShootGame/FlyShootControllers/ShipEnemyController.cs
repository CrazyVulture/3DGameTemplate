
using UnityEngine;

public class ShipEnemyController : EnemyController
{
    //Fire
    public Transform shooter;
    public GameObject lazer;
    public float fireRate;
    float nextFire;
    public AudioClip fireSound;

    void Start()
    {
        base.Init();
        rb.velocity = transform.forward * speed;
        canMove = true;
    }

    void Update()
    {
        if (Time.time > nextFire)
            Fire();
    }

    void FixedUpdate()
    {
        if (canMove)
            Move();
    }

    void Fire()
    {
        nextFire = Time.time + fireRate;
        Instantiate(lazer, shooter.position, shooter.rotation);
        SoundMgr.Instance.PlaySound(fireSound);
    }

    protected override void Move()
    {

    }
}
