using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Cutscene1 : MonoBehaviour {

    //public GameObject main;
    //public GameObject controls;

    public Color textColor;
    public Color backgroundColor;

    public RawImage background;

    public List<Text> text_list = new List<Text>();

    private float timer;
    private float transitionTime = 3.0f;
    private float fadeSpeed = 0.5f;
    private int state;

    void Start() {
        timer = 0f;
        state = 0;
    }

    void Update() {
        timer += Time.deltaTime;

        // increment to next text object in list every transition time that has passed
        if (timer >= transitionTime * (state + 1)) {
            state++;
        }

        // only fade in text objects found in list
        if (state <= text_list.Count - 1) {
            text_list[state].color = Color.Lerp(text_list[state].color, textColor, fadeSpeed * Time.deltaTime);
        }
        else {
            background.color = Color.Lerp(background.color, backgroundColor, fadeSpeed * Time.deltaTime);
        }

        // transition to first level after cutscene finishes
        if (timer >= transitionTime * (text_list.Count + 1)) {
            SceneManager.LoadScene("Level_0");
        }
    }
}
