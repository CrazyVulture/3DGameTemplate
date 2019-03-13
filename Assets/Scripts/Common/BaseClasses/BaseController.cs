
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected Rigidbody rb;
    protected bool canMove;

    protected virtual void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Toggle(bool toggle)
    {
        canMove = toggle;
    }

}
