using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
	private IInputReader inputReader;
	
    [SerializeField] private float movementSpeed = 5f;
	private float lookRotationOffset = 30f;//üçgen sprite'ýndan dolayý 30 derece 


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		inputReader = GetComponent<IInputReader>();
	}

	private void Start()
    {

    }

    private void Update()
    {

    }

	private void FixedUpdate()
    {
        HandleLooking();
		HandleMovement();
	}

    private void HandleMovement()
    {
        Vector2 movementInput = inputReader.ReadMovementInput();
        rb.velocity = movementInput * movementSpeed;
    }

    private void HandleLooking()
    {
        Vector2 lookDir = inputReader.ReadMouseDirection(transform.position);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + lookRotationOffset, Vector3.forward);
    }
}
