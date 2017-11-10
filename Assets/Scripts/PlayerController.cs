using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
	static int idSpeed = Animator.StringToHash("Speed");
	
	[SerializeField]
	float Speed = 3.0f;

	Transform cameraTransform;
	Animator animator;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;

		if (move != Vector2.zero)
		{
			Vector3 direction = cameraForward * move.y + cameraTransform.right * move.x;
			transform.localRotation = Quaternion.LookRotation(direction);

			// キャラクターの位置を移動させる
			agent.Move(direction * (Time.deltaTime * Speed));
		}

		animator.SetFloat(idSpeed, move.magnitude);
	}
}
