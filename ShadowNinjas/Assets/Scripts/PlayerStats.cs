using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public float shuriken;
    public float life;
    public int sceneIndex;
    public Image shuriken1;
    public Image shuriken2;
    public Image shuriken3;
    public Image life1;
    public Image life2;
    public Image life3;
    public GameObject levelLoseMsg;
    public GameObject retrieve;
    public GameObject plant;
    public GameObject explosive1;
    public GameObject explosive2;
    public GameObject goal;
    private bool lost;
    private bool explosives;
    private int planted;
    AsyncOperation asyncLoad;
    

    // Start is called before the first frame update
    void Start()
    {
        shuriken = 3;
        life = 3;
        lost = false;
        explosives = false;
        planted = 0;
        PlayerData data = SaveSystem.LoadPlayer();
        sceneIndex = data.scene;

        if(SceneManager.GetActiveScene().buildIndex != SavedInfo.scene)
        {
            SavedInfo.scene = SceneManager.GetActiveScene().buildIndex;
            SavedInfo.life = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(planted == 2)
        {
            goal.gameObject.SetActive(true);
        }

        if(life > SavedInfo.life)
        {
            life = SavedInfo.life;
        }
        else if(SavedInfo.life > life)
        {
            SavedInfo.life = life;
        }

        SavedInfo.shuriken = shuriken;

        if(shuriken == 3)
        {
            shuriken1.enabled = true;
            shuriken2.enabled = true;
            shuriken3.enabled = true;
        }
        else if(shuriken == 2)
        {
            shuriken1.enabled = true;
            shuriken2.enabled = true;
            shuriken3.enabled = false;
        }
        else if (shuriken == 1)
        {
            shuriken1.enabled = true;
            shuriken2.enabled = false;
            shuriken3.enabled = false;
        }
        else if (shuriken == 0)
        {
            shuriken1.enabled = false;
            shuriken2.enabled = false;
            shuriken3.enabled = false;
        }

        if (life == 3)
        {
            life1.enabled = true;
            life2.enabled = true;
            life3.enabled = true;
        }
        else if (life == 2)
        {
            life1.enabled = true;
            life2.enabled = true;
            life3.enabled = false;
        }
        else if (life == 1)
        {
            life1.enabled = true;
            life2.enabled = false;
            life3.enabled = false;
        }
        else if (life == 0)
        {
            life1.enabled = false;
            life2.enabled = false;
            life3.enabled = false;
        }
    }

    public void UseShuriken()
    {
        shuriken -= 1;
    }

    public void AddShuriken()
    {
        shuriken += 1;
    }

    public void UseLife()
    {
        life -= 1;
    }

    public void AddLife()
    {
        life += 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Lose") && !lost)
        {
            UseLife();
            lost = true;
        }
        else if(other.gameObject.CompareTag("Arrow") && !lost)
        {
            UseLife();
            lost = true;
            levelLoseMsg.SetActive(true);
            StartCoroutine(Close(3));
        }

        if(other.gameObject.CompareTag("Ammo"))
        {
            shuriken = 3;
            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Retrieve"))
        {
            retrieve.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Plant1") || other.gameObject.CompareTag("Plant2"))
        {
            plant.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Retrieve"))
        {
            retrieve.SetActive(true);
        }

        if(other.gameObject.CompareTag("Plant1") || other.gameObject.CompareTag("Plant2"))
        {
            plant.SetActive(true);
        }

        if (other.gameObject.CompareTag("Retrieve") && Input.GetKey(KeyCode.E))
        {
            other.gameObject.SetActive(false);
            retrieve.gameObject.SetActive(false);
            explosives = true;
        }

        if (other.gameObject.CompareTag("Plant1") && Input.GetKey(KeyCode.E) && explosives)
        {
            other.gameObject.SetActive(false);
            explosive1.SetActive(true);
            plant.gameObject.SetActive(false);
            planted += 1;
        }

        if (other.gameObject.CompareTag("Plant2") && Input.GetKey(KeyCode.E) && explosives)
        {
            other.gameObject.SetActive(false);
            explosive2.SetActive(true);
            plant.gameObject.SetActive(false);
            planted += 1;
        }
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        LoadLevel();
        shuriken = data.shuriken;
        life = data.life;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    IEnumerator LoadLevel()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        asyncLoad = SceneManager.LoadSceneAsync(data.scene, LoadSceneMode.Single);
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator Close(float x)
    {
        yield return new WaitForSeconds(x - 1);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        levelLoseMsg.SetActive(false);
    }
}
