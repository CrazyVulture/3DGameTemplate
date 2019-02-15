
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected Rigidbody rb;

    //Move
    protected bool canMove;
    public float speed;

    protected virtual void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Move()
    {

    }

    public void Toggle(bool toggle)
    {
        canMove = toggle;
    }

}
