using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    protected Rigidbody rb;

    //Move
    protected bool canMove;
    public float speed;
    protected float moveHorizontal;
    protected float moveVertical;

    protected void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }

    public void Toggle(bool toggle)
    {
        canMove = toggle;
    }
}