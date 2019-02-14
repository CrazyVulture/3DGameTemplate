
public class FlyShootGameController : GameController
{
    public ShipPlayerController shipPlayerController;

    public override void StartGame()
    {
        base.StartGame();
        shipPlayerController.Toggle(true);
    }

    public override void EndGame(bool isWin)
    {
        base.EndGame(isWin);
        shipPlayerController.Toggle(false);
    }
}
