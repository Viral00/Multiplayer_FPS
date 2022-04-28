public class PlayerService : MonoSingleton<PlayerService>
{
    public PlayerView playerPrefab;

    public void Start()
    {
        PlayerModel playerModel = new PlayerModel(1000f, 500f, 5f, 6f, 2f, 0.2f);
        PlayerController playerController = new PlayerController(playerModel, playerPrefab);
    }
}
