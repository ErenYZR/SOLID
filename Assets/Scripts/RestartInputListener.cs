using UnityEngine;
using UnityEngine.InputSystem;

public class RestartInputListener : MonoBehaviour
{
	private void Update()
	{
		if (Time.timeScale == 0 && Keyboard.current.rKey.wasPressedThisFrame)
		{
			LevelManager.Instance.RestartScene();
		}
	}
}