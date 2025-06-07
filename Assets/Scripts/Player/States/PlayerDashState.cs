using UnityEngine;

public class PlayerDashState : PlayerState
{
	private float dashTimeLeft;
	private Vector2 dashDir;

	public PlayerDashState(Player player, PlayerStateMachine stateMachine,DashSkillData dashData)
		: base(player, stateMachine) { }

	public override void Enter()
	{
		dashDir = player.transform.right;
		dashTimeLeft = player.dashData.dashDuration;

		player.Rigidbody.velocity = Vector2.zero;
		player.Rigidbody.AddForce(dashDir * player.dashData.dashDistance, ForceMode2D.Impulse);
	}

	public override void Update()
	{
		dashTimeLeft -= Time.deltaTime;
		if (dashTimeLeft <= 0f)
		{
			stateMachine.ChangeState(player.WalkState); // yürümeye geri dön
		}
	}
}
