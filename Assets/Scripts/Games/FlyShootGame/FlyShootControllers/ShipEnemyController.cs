
using UnityEngine;
using System.Collections;

public class ShipEnemyController : EnemyController
{
    //Fire
    float nextFire;
    public Transform shooter;
    public GameObject lazer;
    public float fireRate;
    public AudioClip fireSound;

    //Evade
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 manenverWait;
    float targetManeuver;
    Transform playerManeuver;

    //Move action
    public float smoothing;
    public Boundary enemyBoundary;
    public float tilt;
    public float speed;
    float currentSpeed;

    void Start()
    {
        base.Init();
        rb.velocity = transform.forward* speed;
        currentSpeed = rb.velocity.z;
        playerManeuver = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Evade());
    }

    void Update()
    {
        if (Time.time > nextFire)
            Fire();
    }

    void FixedUpdate()
    {
         Move();
    }

    void Fire()
    {
        nextFire = Time.time + fireRate;
        Instantiate(lazer, shooter.position, shooter.rotation);
        SoundMgr.Instance.PlaySound(fireSound);
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x,startWait.y));
        while (PlayerController.GetPlayerStatus() != PlayerStatus.DEAD)
        {
            targetManeuver = playerManeuver.position.x;
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(manenverWait.x,manenverWait.y));
        }
    }

    void Move()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        //Set enemy section boundary
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, enemyBoundary.xMin, enemyBoundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, enemyBoundary.zMin, enemyBoundary.zMax));

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, (-tilt) * rb.velocity.x);
    }
}
