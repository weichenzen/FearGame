using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
	public float speed = 1f;

	public Animator ani;

	public Rigidbody2D rigid;

	private bool facingRight = true; // 是否面向右邊

	private Vector3 movement = Vector3.zero; // 移動用的向量

	private bool allowJump = true; // 允許跳躍

	public float jumpSpeed = 6f; // 跳躍速度

	public float groundDetectRadius = 0.2f; // 地板偵測器半徑

	public LayerMask groundLayers = 1; // 地板的圖層

	private bool grounded = false; // 是否站在地面上

	[SerializeField] private PhysicsMaterial2D zeroFrictionMaterial; // 物理材質

	// Start is called before the first frame update
	void Start()
	{
		if (ani == null)
		{
			ani = GetComponent<Animator>();
		}
		if (rigid == null)
		{
			rigid = GetComponent<Rigidbody2D>();
		}
		if (transform.localScale.x < 0)
		{
			facingRight = false;
		}
		if (zeroFrictionMaterial == null)
		{
			zeroFrictionMaterial = rigid.sharedMaterial;
		}
	}

	// Update is called once per frame
	void Update()
	{
		// 地面偵測
		grounded = Physics2D.OverlapCircle(transform.position, groundDetectRadius, groundLayers);

		float h = Input.GetAxis("Horizontal");
		movement = new Vector3(speed * h, rigid.velocity.y, 0);

		if (Input.GetButtonDown("Jump") && allowJump && grounded)
		{
			movement.y = jumpSpeed;
		}

		rigid.velocity = movement;

		if ((h > 0 && !facingRight) || (h < 0 && facingRight))
		{
			Flip();
		}

		//if (Input.GetKey(KeyCode.RightArrow))
		//{
		//         //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		//    rigid.velocity = new Vector3(speed, rigid.velocity.y, 0);
		//    ani.SetFloat("Speed", 1);
		//    if (!facingRight)
		//    {
		//        Flip();
		//    }
		//}
		//else if (Input.GetKey(KeyCode.LeftArrow))
		//{
		//         //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
		//    rigid.velocity = new Vector3(-speed, rigid.velocity.y, 0);
		//    ani.SetFloat("Speed", 1);
		//    if (facingRight)
		//    {
		//        Flip();
		//    }
		//}
		//else
		//{
		//    rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
		//    ani.SetFloat("Speed", 0);
		//}

		if (!grounded)
		{
			ani.SetBool("Jump", true);
			rigid.sharedMaterial = zeroFrictionMaterial;
		}
		else
		{
			ani.SetBool("Jump", false);
			ani.SetFloat("Speed", h);
			rigid.sharedMaterial = null;
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 actorScale = transform.localScale;
		actorScale.x *= -1;
		transform.localScale = actorScale;
	}

	void MovementController()
	{
		if (!Talkable.isTalking)
		{
		}
	}
}
