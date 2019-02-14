
public class CollectGameController : GameController
{
    public BallPlayerController ballController;

    public override void StartGame()
    {
        base.StartGame();
        ballController.Toggle(true);
    }

    public override void EndGame(bool isWin)
    {
        base.EndGame(isWin);
        ballController.Toggle(false);
    }
}
