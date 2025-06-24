using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveUIHandler : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI waveText;
	[SerializeField] private WaveManager waveManager;

	private void OnEnable()
	{
		waveManager.BeforeWaveStarted += HandleWaveStarted;
	}

	private void OnDisable()
	{
		waveManager.BeforeWaveStarted -= HandleWaveStarted;
	}

	private void HandleWaveStarted()
	{
		waveText.text = "Yeni Dalga Baþladý!" + $"Wave {waveManager.CurrentWave}";
	}
}
