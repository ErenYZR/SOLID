using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounterUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI enemyCountText;
	[SerializeField] private WaveManager waveManager;

	private void OnEnable()
	{
		waveManager.OnEnemyCountChanged += HandleEnemyCounterUI;
	}

	private void OnDisable()
	{
		waveManager.OnEnemyCountChanged -= HandleEnemyCounterUI;
	}

	private void Start()
	{
		HandleEnemyCounterUI(waveManager.AliveEnemies);
	}

	private void HandleEnemyCounterUI(int aliveEnemies)
	{
		if (enemyCountText != null)
		{
			enemyCountText.text = $"Alive Enemies: {aliveEnemies}";
		}
		else
		{
			Debug.LogWarning("Enemy Count Text is not assigned in the inspector.");
		}
	}
}
