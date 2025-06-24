using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float angleOffset = -30f;
	private Rigidbody2D rb;
    private float speed = 10f;
    private float damage;
	[SerializeField] private List<string> unvalidTargetTags;


	public void Initialize(float speed, float damage)
	{
		this.speed = speed;
		this.damage = damage;
		rb = GetComponent<Rigidbody2D>();
		float angle = transform.eulerAngles.z + angleOffset;
		Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;

		rb.velocity = direction * speed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.TryGetComponent(out IDamageReceiver receiver) &&
			!unvalidTargetTags.Contains(receiver.DamageReceiverTag) && //listede olmayan nesnelere hasar verilir.
			other.TryGetComponent(out IDamageable damageable))
		{
			damageable.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
