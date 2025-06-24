using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour, IDamageable, IDamageReceiver
{
	[SerializeField] private float maxHealth = 100f;
	[SerializeField] private float currentHealth;
	public Action OnEnemyDied;

	public string DamageReceiverTag => "Enemy";

	private void Awake()
	{
		currentHealth = maxHealth;
	}

	private void Update()
	{
		if (Keyboard.current.rKey.wasPressedThisFrame)
		{
			TakeDamage(10f);
		}
	}

	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		Debug.Log($"{gameObject.name} took {amount} damage. Remaining: {currentHealth}");

		if (currentHealth <= 0) Die();
	}

	protected virtual void Die()
    {
		OnEnemyDied?.Invoke();
		Destroy(gameObject);
    }
}