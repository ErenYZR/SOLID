using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageDealer : MonoBehaviour
{
	[SerializeField] private float damage = 10f;
	[SerializeField] private float cooldown = 1f;

	[Tooltip("Sadece bu etiketlere sahip hedeflere hasar verilir")]
	[SerializeField] private List<string> validTargets;

	private float lastHitTime;

	private void OnTriggerStay2D(Collider2D other)
	{
		if (Time.time < lastHitTime + cooldown) return;

		if (other.TryGetComponent(out IDamageReceiver receiver) &&
			validTargets.Contains(receiver.DamageReceiverTag) &&
			other.TryGetComponent(out IDamageable damageable))
		{
			damageable.TakeDamage(damage);
			lastHitTime = Time.time;
		}
	}
}

