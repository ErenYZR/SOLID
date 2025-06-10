using UnityEngine;
public class EnemyChaser : EnemyBase
{
	[SerializeField] private float moveSpeed = 3f;
	private Transform target;

	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void FixedUpdate()
	{
		if (target == null) return;

		Vector2 direction = (target.position - transform.position).normalized;
		transform.position += (Vector3)(direction * moveSpeed * Time.fixedDeltaTime);

		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}