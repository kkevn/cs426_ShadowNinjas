using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsButton : MonoBehaviour
{
	
	
	public void ReturnToMainMenu(string level) {
		SceneManager.LoadScene(level);
	}
}
