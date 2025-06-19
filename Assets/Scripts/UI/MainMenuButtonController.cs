using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonController : MonoBehaviour
{
	public void StartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
		Time.timeScale = 1f;
	}

	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Game is quitting...");
	}
}
