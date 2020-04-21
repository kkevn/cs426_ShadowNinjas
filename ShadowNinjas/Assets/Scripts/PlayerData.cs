[System.Serializable]
public class PlayerData
{
    public float life;
    public float shuriken;
    public float[] position;

    public PlayerData(PlayerStats playerStats)
    {
        life = playerStats.life;
        shuriken = playerStats.shuriken;

        position = new float[3];
        position[0] = playerStats.transform.position.x;
        position[1] = playerStats.transform.position.y;
        position[2] = playerStats.transform.position.z;
    }
}
