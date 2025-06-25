using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour, IDamageable, IDamageReceiver, IHealth
{
	[SerializeField] private float maxHealth = 100f;
	[SerializeField] private float currentHealth;
	public float MaxHealth => maxHealth;
	public float CurrentHealth => currentHealth;

	public string DamageReceiverTag => "Player";


	public static event Action OnPlayerDied;
	public event Action<float,float> OnHealthChanged;

	private void Awake()
	{
		currentHealth = maxHealth;
	}

	private void Update()
	{
		if (Keyboard.current.tKey.wasPressedThisFrame)
		{
			TakeDamage(10f);
		}
	}

	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		OnHealthChanged?.Invoke(currentHealth,maxHealth);
		Debug.Log($"{gameObject.name} took {amount} damage. Remaining: {currentHealth}");

		if (currentHealth <= 0) Die();
	}

	protected virtual void Die()
	{
		OnPlayerDied?.Invoke();
		Destroy(gameObject);
	}
}