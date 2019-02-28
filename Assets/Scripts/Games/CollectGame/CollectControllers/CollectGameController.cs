
public class CollectGameController : GameController
{
    public CollectPlayerController collectPlayerController;

    public override void StartGame()
    {
        base.StartGame();
        collectPlayerController.Toggle(true);
    }

    public override void EndGame(bool isWin)
    {
        base.EndGame(isWin);
        if (isWin)
            collectPlayerController.WinAction();
        collectPlayerController.Toggle(false);
    }

    public override void PlayerDead()
    {
        collectPlayerController.Toggle(false);
        collectPlayerController.Death();
    }
}
