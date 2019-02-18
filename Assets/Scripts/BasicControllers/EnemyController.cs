﻿
public abstract class EnemyController : BaseController
{
    public int scoreVal;

    protected override void Init()
    {
        base.Init();
    }

    public void Death()
    {
        UIMgr.Instance.AddScore(scoreVal);
        Destroy(gameObject);
    }

}