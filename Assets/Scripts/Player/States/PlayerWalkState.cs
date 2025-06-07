using UnityEngine;
public class PlayerWalkState : PlayerState
{
	private IInputReader input => player.InputReader;
	private float moveSpeed => player.MovementSpeed;

	public PlayerWalkState(Player player, PlayerStateMachine stateMachine)
		: base(player, stateMachine)
	{ }

	public override void FixedUpdate()
	{
		Vector2 movementInput = input.ReadMovementInput();
		player.Rigidbody.velocity = movementInput * moveSpeed;
	}

	public override void Update()
	{
		HandleLooking();
	}

	private void HandleLooking()
	{
		Vector2 lookDir = input.ReadMouseDirection(player.transform.position);
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
		player.transform.rotation = Quaternion.AngleAxis(angle + player.LookRotationOffset, Vector3.forward);
	}
}
