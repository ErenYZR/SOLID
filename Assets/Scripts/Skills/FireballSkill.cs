using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : ISkill
{
	private FireballSkillData fireballSkillData;
	private Transform firePoint;
	private IProjectileSpawner projectileSpawner;
	public bool UsesState => false;

	public FireballSkill(FireballSkillData data, Transform firePoint, IProjectileSpawner spawner)
	{
		this.fireballSkillData = data;
		this.firePoint = firePoint;
		this.projectileSpawner = spawner;
	}

	public void Use()
	{
		projectileSpawner.SpawnProjectile(
			fireballSkillData.projectilePrefab,
			firePoint.position,
			firePoint.rotation,
			fireballSkillData.speed,
			fireballSkillData.damage);
	}
}

