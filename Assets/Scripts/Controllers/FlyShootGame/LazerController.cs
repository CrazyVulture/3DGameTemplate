
public class LazerController : BaseController
{
    void Start()
    {
        base.Init();
        rb.velocity = transform.forward*speed;
    }

}
