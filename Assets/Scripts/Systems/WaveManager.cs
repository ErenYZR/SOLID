using UnityEngine;
using System.Collections;
using System;

public class WaveManager : MonoBehaviour
{
	[SerializeField] private int totalWaveCount = 5;
	[SerializeField] private float timeBetweenWaves = 3f;
	[SerializeField] private EnemySpawner spawner;
	public Action BeforeWaveStarted;
	public Action<int> AfterWaveStarted;

	private int currentWave = 0;
	public int CurrentWave => currentWave;
	private int aliveEnemies = 0;

	private void Start()
	{
		StartWaves();
	}

	public void StartWaves()
	{
		currentWave = 0;
		StartCoroutine(StartNextWave());
	}

	private IEnumerator StartNextWave()
	{
		BeforeWaveStarted?.Invoke();
		yield return new WaitForSeconds(timeBetweenWaves);
		currentWave++;

		AfterWaveStarted?.Invoke(currentWave);
		if (currentWave > totalWaveCount)
		{
			Debug.Log("Tüm dalgalar tamamlandý!");
			yield break;
		}

		int enemyCount = CalculateEnemyCount(currentWave);
		aliveEnemies = enemyCount;

		for (int i = 0; i < enemyCount; i++)
		{
			spawner.Spawn(OnEnemyDied); // callback olarak veriyoruz
		}
	}

	private int CalculateEnemyCount(int wave)
	{
		return wave * 2 + 1; // Basit örnek
	}

	private void OnEnemyDied()
	{
		aliveEnemies--;

		if (aliveEnemies <= 0)
		{
			StartCoroutine(StartNextWave());
		}
	}
}