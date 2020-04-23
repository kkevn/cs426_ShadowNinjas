using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void loadLevel()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.scene + 1);
    }
}
