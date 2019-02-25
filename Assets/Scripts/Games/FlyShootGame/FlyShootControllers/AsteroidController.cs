
public class AsteroidController : EnemyController
{
    public float speed;

    void Start()
    {
        base.Init();
        rb.velocity = transform.forward * speed;
    }
}
