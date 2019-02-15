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

    protected override void Init()
    {
        base.Init();
    }

    public static PlayerStatus GetPlayerStatus()
    {
        return playerStatus;
    }

    protected override void Move()
    {
        base.Move();
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }
    
}