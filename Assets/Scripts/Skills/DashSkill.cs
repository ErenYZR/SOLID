using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : ISkill
{
	private Rigidbody2D rb;
	[SerializeField]private DashSkillData dashSkillData;
	private Transform playerTransform;
	private Player player;

	private float lastUsedTime = -Mathf.Infinity;
	public bool UsesState => true;
	public DashSkill(Rigidbody2D rb, DashSkillData data, Transform playerTransform,Player player)
	{
		this.rb = rb;
		this.dashSkillData = data;
		this.playerTransform = playerTransform;
		this.player = player;
	}
	public void Use()
	{

		if (rb == null || dashSkillData == null || playerTransform == null) return;

		if (Time.time < lastUsedTime + dashSkillData.cooldown)
			return;

		lastUsedTime = Time.time;

		player.StateMachine.ChangeState(player.DashState);
		float angle = playerTransform.eulerAngles.z - 60f;//sprite yüzünden 60 derece kaydýrdým
		Vector2 dashDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;


		rb.AddForce(dashDirection * dashSkillData.dashDistance, ForceMode2D.Impulse);

	}
}