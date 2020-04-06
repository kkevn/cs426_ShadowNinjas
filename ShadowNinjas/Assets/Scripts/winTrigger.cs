using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winTrigger : MonoBehaviour
{
    public GameObject levelCompleteMsg;
    private void OnTriggerEnter(Collider other)
    {
        levelCompleteMsg.SetActive(true);
        StartCoroutine(Close(5));
    }

    public IEnumerator Close(float x)
    {
        yield return new WaitForSeconds(x);
        Application.Quit();
    }
}
