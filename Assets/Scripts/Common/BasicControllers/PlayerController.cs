﻿using UnityEngine;

public enum PlayerStatus
{
    DEFAULT = 0,
    MOVE,
    DEAD,
    WIN
};

public abstract class PlayerController : BaseController
{
    protected static PlayerStatus playerStatus;

    //Move
    public float speed;
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
        playerStatus = PlayerStatus.DEAD;
    }

    public virtual void WinAction()
    {
        playerStatus = PlayerStatus.WIN;
    }
    
}