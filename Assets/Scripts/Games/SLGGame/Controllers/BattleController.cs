using UnityEngine;

public class BattleController : StateMachine
{
    public CamereRig camereRig;
    public Board board;
    public LevelData levelData;
    public Transform selector;
    public Point pos;

    void Start()
    {
        ChangeState<InitBattleState>();
    }
}
