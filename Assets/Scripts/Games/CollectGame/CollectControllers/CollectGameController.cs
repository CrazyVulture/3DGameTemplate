
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
        collectPlayerController.Toggle(false);
        collectPlayerController.WinAction();
    }

    public override void PlayerDead()
    {
        collectPlayerController.Toggle(false);
        collectPlayerController.Death();
    }
}
