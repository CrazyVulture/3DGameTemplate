
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
    }

    public override void PlayerDead()
    {
        collectPlayerController.Death();
        collectPlayerController.Toggle(false);
    }
}
