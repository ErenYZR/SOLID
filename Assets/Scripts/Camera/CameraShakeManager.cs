using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{
	public static CameraShakeManager Instance { get; private set; }

	[SerializeField] private CinemachineVirtualCamera virtualCamera;
	private float shakeTimer;
	CinemachineBasicMultiChannelPerlin perlin;


	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;

		perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
	}

	public void ShakeCamera(float intensity,float time)
	{
		perlin.m_AmplitudeGain = intensity;
		shakeTimer = time;
	}

	private void Update()
	{
		if (shakeTimer > 0)
		{
			shakeTimer -= Time.deltaTime;
			if (shakeTimer <= 0)
			{
				perlin.m_AmplitudeGain = 0f;
			}
		}
	}
}