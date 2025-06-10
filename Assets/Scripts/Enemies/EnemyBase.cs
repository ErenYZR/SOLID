using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyBase : MonoBehaviour , IDamageable
{
    [SerializeField]private float maxHealth = 100;
    [SerializeField]private float currentHealth;

	private void Awake()
	{
        currentHealth = maxHealth;
	}

	void Start()
    {
        
    }

    void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
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
        Destroy(gameObject);
    }


}
