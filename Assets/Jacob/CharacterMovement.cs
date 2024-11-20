using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[Header("References")]
	public CharacterController characterController;
	[Header("Stats")]
	public float moveSpeed = 5;
	public float turnSpeed = 5;
	public bool playerPossessed = false;


	private Vector3 moveDir = Vector3.zero;

	void Update()
	{
		if (playerPossessed)
		{
			Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
			gameObject.transform.Rotate(transform.up, Input.GetAxis("Yaw") * turnSpeed * Time.deltaTime);
		}


		characterController.Move(moveDir * moveSpeed * Time.deltaTime);

	}

	public void Move(Vector3 move)
	{
		moveDir = move;
	}

	//float turnAngle = 0;
	public void Turn(float angle) // negative = left
	{
		if(angle != 0)
		{
			gameObject.transform.Rotate(transform.up, angle * turnSpeed * Time.deltaTime);
		}
		//turnAngle = angle;
	}
}
