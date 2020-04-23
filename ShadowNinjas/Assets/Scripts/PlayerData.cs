using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public float life;
    public float shuriken;
    public int scene;
    public float[] position;

    public PlayerData(PlayerStats playerStats)
    {
        life = playerStats.life;
        shuriken = playerStats.shuriken;
        scene = SceneManager.GetActiveScene().buildIndex;
        position = new float[3];
        position[0] = playerStats.transform.position.x;
        position[1] = playerStats.transform.position.y;
        position[2] = playerStats.transform.position.z;
    }
}
