using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Transform target;
	public float attackRange = 2.0f;
    public float attackDamage = 10.0f;
    public float attackCooldown = 1.0f;

	private float attackCooldownTimer = 0.0f;


	void Start()
    {
		GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
		if (targetObject != null)
		{
			target = targetObject.transform;
		}
	}
    void Update()
    {
		attackCooldownTimer -= Time.deltaTime;
		if (target == null) return;

		if (CanAttack(target) && attackCooldownTimer <= 0f)
        {
			Attack();
		}

	}

    private bool CanAttack(Transform target)
	{
		float distanceToTarget = Vector3.Distance(transform.position, target.position);
		return distanceToTarget <= attackRange;
	}

    private void Attack()
    {
		if (target.TryGetComponent<IDamageable>(out var damageable))
		{
			damageable.TakeDamage(attackDamage);
		}

		attackCooldownTimer = attackCooldown; 
	}
}