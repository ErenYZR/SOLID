using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
	[SerializeField] private GameObject deathEffectPrefab;
	[SerializeField] private float shakeDuration = 0.2f;
	[SerializeField] private float shakeIntensity = 1f;

	private void OnEnable()
	{
		EnemyHealth.OnEnemyDiedFeedback += HandleEnemyDied;
	}

	private void OnDisable()
	{
		EnemyHealth.OnEnemyDiedFeedback -= HandleEnemyDied;
	}

	private void HandleEnemyDied(Vector3 position)
	{
		//Instantiate(deathEffectPrefab, position, Quaternion.identity);
		CameraShakeManager.Instance.ShakeCamera(shakeIntensity, shakeDuration);
	}
}