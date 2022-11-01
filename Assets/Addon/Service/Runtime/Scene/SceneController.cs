using Services;

public class SceneController : SceneControllerBase
{
    public static int GameIndex => 2;
    public static bool InGame => SceneControllerUtility.SceneIndex >= GameIndex;
}
