using UnityEngine;
public interface IProjectileSpawner
{
	void SpawnProjectile(GameObject prefab, Vector3 position, Quaternion rotation, float speed, float damage);
}