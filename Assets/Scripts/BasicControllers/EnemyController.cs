
public abstract class EnemyController : BaseController
{
    public int scoreVal;

    protected override void Init()
    {
        base.Init();
    }

    public virtual void Death(float lifetime=2.0f)
    {
        UIMgr.Instance.AddScore(scoreVal);
        Destroy(gameObject,lifetime);
    }

}
