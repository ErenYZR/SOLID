using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Dash Skill")]
public class DashSkillData : ScriptableObject
{
	public float dashSpeed;
	public float dashDuration;
	public float cooldown;
}