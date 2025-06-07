using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Fireball Skill")]
public class FireballSkillData : ScriptableObject
{
	public GameObject projectilePrefab;
	public float damage;
	public float cooldown;
}