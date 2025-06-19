using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RestartInputListener : MonoBehaviour
{
	private void Update()
	{
		if (Time.timeScale == 0 && Keyboard.current.rKey.wasPressedThisFrame)
		{
			SceneLoader.Instance.RestartCurrentScene();
		}
	}

	public void RestartScene()
	{
		SceneLoader.Instance.RestartCurrentScene();
	}
	public void ReturnMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}