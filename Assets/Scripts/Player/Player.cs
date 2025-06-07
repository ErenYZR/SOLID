using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D Rigidbody { get; private set; }
	public IInputReader InputReader { get; private set; }

	public float MovementSpeed => movementSpeed;
	public float LookRotationOffset => lookRotationOffset;

	public PlayerStateMachine StateMachine { get; private set; }

	public PlayerWalkState WalkState { get; private set; }
	public PlayerDashState DashState { get; private set; }

	[SerializeField] private float movementSpeed = 5f;
	[SerializeField] private float lookRotationOffset = 30f;

	[SerializeField] public DashSkillData dashData;

	private void Awake()
	{
		Rigidbody = GetComponent<Rigidbody2D>();
		InputReader = GetComponent<IInputReader>();
		StateMachine = new PlayerStateMachine();

		WalkState = new PlayerWalkState(this, StateMachine);
		DashState = new PlayerDashState(this, StateMachine, dashData);
	}

	private void Start()
	{
		StateMachine.Initialize(WalkState);
	}

	private void Update()
	{
		StateMachine.Update();
	}

	private void FixedUpdate()
	{
		StateMachine.FixedUpdate();
	}
}
