using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
	private void OnEnable()
	{
		PlayerHealth.OnPlayerDied += HandlePlayerDeath;
	}

	private void OnDisable()
	{
		PlayerHealth.OnPlayerDied -= HandlePlayerDeath;
	}


	private void HandlePlayerDeath()
	{
		Time.timeScale = 0f;
	}
}
