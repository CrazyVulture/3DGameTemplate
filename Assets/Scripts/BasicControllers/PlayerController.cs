using UnityEngine;

public enum PlayerStatus
{
    DEFAULT = 0,
    MOVE,
    DEAD
};

public abstract class PlayerController : BaseController
{
    protected static PlayerStatus playerStatus;

    //Move
    protected float moveHorizontal;
    protected float moveVertical;
    protected Vector3 movement;

    protected override void Init()
    {
        base.Init();
        playerStatus = PlayerStatus.DEFAULT;
    }

    public static PlayerStatus GetPlayerStatus()
    {
        return playerStatus;
    }

    protected void GetAxisMove(bool isRaw=false)
    {
        if (isRaw)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
        playerStatus = PlayerStatus.DEAD;
    }
    
}