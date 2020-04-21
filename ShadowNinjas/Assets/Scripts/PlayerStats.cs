using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float shuriken;
    public float life;
    public Image shuriken1;
    public Image shuriken2;
    public Image shuriken3;
    public Image life1;
    public Image life2;
    public Image life3;
    private bool lost;

    // Start is called before the first frame update
    void Start()
    {
        shuriken = 3;
        life = 3;
        lost = false;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        shuriken = data.shuriken;
        life = data.life;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
