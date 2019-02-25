using UnityEngine;

public class CollectPlayerController : PlayerController
{
    //Hurt
    public AudioClip hurtSound;

    //Privates
    Animator playerAnim;
    bool isWalking;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        base.Init();
        isWalking = false;
        floorMask = LayerMask.GetMask("Floor");
        playerAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Move();
            Turning();
            MoveAnim();
        }
            
    }

    void Move()
    {
        GetAxisMove(true);
        playerStatus = PlayerStatus.MOVE;
        movement.Set(moveHorizontal,0f,moveVertical);
        movement = movement.normalized*speed*Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay,out floorHit,camRayLength,floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }

    void MoveAnim()
    {
        if (moveHorizontal == 0 && moveVertical == 0)
            isWalking = false;
        else
            isWalking = true;
        playerAnim.SetBool("IsWalking", isWalking);
    }
}
