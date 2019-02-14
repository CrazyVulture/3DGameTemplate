
public class LazerController : PlayerController
{
    void Start()
    {
        Init();
        rb.velocity = transform.forward*speed;
    }

}
