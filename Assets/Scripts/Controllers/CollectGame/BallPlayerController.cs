using UnityEngine;

public class BallPlayerController : PlayerController
{
    void Start()
    {
        base.Init();
    }

    void FixedUpdate()
    {
        if (canMove)
            Move();
    }

    protected override void Move()
    {
        base.Move();
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

}
