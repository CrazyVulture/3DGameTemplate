
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected Rigidbody rb;
    protected bool canMove;
    public float speed;

    protected virtual void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected abstract void Move();

    public void Toggle(bool toggle)
    {
        canMove = toggle;
    }

}
