
public abstract class EnemyController : BaseController
{
    public int scoreVal;
    public float deathTime=2.0f;

    protected override void Init()
    {
        base.Init();
    }

    public virtual void Death()
    {
        UIMgr.Instance.AddScore(scoreVal);
        Destroy(gameObject,deathTime);
    }

}
