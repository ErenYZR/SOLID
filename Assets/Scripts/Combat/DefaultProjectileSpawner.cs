using UnityEngine;
public class DefaultProjectileSpawner : MonoBehaviour, IProjectileSpawner
{
	public void SpawnProjectile(GameObject prefab, Vector3 position, Quaternion rotation, float speed, float damage)
	{
		GameObject obj = Instantiate(prefab, position, rotation);
		var projectile = obj.GetComponent<Projectile>();
		projectile.Initialize(speed, damage);
	}
}