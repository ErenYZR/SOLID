using UnityEngine;

public class PlayerDashState : PlayerState
{
	private float dashTimeLeft;
	private Vector2 dashDir;

	public PlayerDashState(Player player, PlayerStateMachine stateMachine,DashSkillData dashData)
		: base(player, stateMachine) { }

	public override void Enter()
	{
		float angle = player.transform.eulerAngles.z - 30f;//sprite yüzünden 30 derece kaydýrdým
		dashDir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;

		dashTimeLeft = player.dashData.dashDuration;

		player.Rigidbody.velocity = Vector2.zero;
	}

	public override void Update()
	{

		player.Rigidbody.velocity = dashDir * player.dashData.dashSpeed;

		dashTimeLeft -= Time.deltaTime;

		if (dashTimeLeft <= 0f)
		{
			stateMachine.ChangeState(player.WalkState);
		}
	}
}
