using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Fireball Skill")]
public class FireballSkillData : ScriptableObject
{
	[SerializeField]public GameObject projectilePrefab;
	public float speed;
	public float damage;
	public float cooldown;
}