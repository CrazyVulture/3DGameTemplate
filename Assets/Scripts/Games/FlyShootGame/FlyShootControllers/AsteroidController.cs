
public class AsteroidController : EnemyController
{
    void Start()
    {
        base.Init();
        rb.velocity = transform.forward * speed;
    }
}
