using UnityEngine;

public abstract class PlayerController : BaseController
{
    //Move
    protected float moveHorizontal;
    protected float moveVertical;

    protected override void Init()
    {
        base.Init();
    }

    protected override void Move()
    {
        base.Move();
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }
}