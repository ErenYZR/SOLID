using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private float spawnOffset = 2f;

	public void Spawn(Action onDeathCallback)
	{
		Vector3 randomVector = new Vector3(UnityEngine.Random.Range(-spawnOffset, spawnOffset) , UnityEngine.Random.Range(-spawnOffset, spawnOffset) , 0);
		int randIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
		var enemy = Instantiate(enemyPrefab, spawnPoints[randIndex].position + randomVector, Quaternion.identity);

		if (enemy.TryGetComponent<EnemyHealth>(out var enemyHealth))
		{
			enemyHealth.OnEnemyDied = onDeathCallback;
		}
	}
}