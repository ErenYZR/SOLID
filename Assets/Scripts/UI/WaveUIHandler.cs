using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveUIHandler : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI waveText;
	[SerializeField] private WaveManager waveManager;
	[SerializeField] private float fadeDuration = 0.5f;
	[SerializeField] private float displayDuration = 1.5f;


	private void OnEnable()
	{
		waveManager.BeforeWaveStarted += ShowPrepareText;
		waveManager.AfterWaveStarted += ShowWaveText;
	}

	private void OnDisable()
	{
		waveManager.BeforeWaveStarted -= ShowPrepareText;
		waveManager.AfterWaveStarted -= ShowWaveText;
	}

	private void ShowPrepareText()
	{
		StopAllCoroutines();
		StartCoroutine(ShowTextWithFade("READY!"));
	}

	private void ShowWaveText(int wave)
	{
		StopAllCoroutines();
		StartCoroutine(ShowTextWithFade($"Wave {wave}"));
	}

	private IEnumerator ShowTextWithFade(string text)
	{
		waveText.text = text;
		waveText.alpha = 0f;

		// Fade In
		float time = 0f;
		while (time < fadeDuration)
		{
			waveText.alpha = Mathf.Lerp(0, 1, time / fadeDuration);
			time += Time.deltaTime;
			yield return null;
		}
		waveText.alpha = 1f;

		// Wait
		yield return new WaitForSeconds(displayDuration);

		// Fade Out
		time = 0f;
		while (time < fadeDuration)
		{
			waveText.alpha = Mathf.Lerp(1, 0, time / fadeDuration);
			time += Time.deltaTime;
			yield return null;
		}
		waveText.alpha = 0f;
	}
}
