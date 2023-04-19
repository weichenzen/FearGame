using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Talkable : MonoBehaviour
{

	public static Flowchart flowchartManager;
	public Flowchart talkFlowchart;
	public string onCollosionEnter;
	Rigidbody2D playerRigidbody;

	void Awake()
	{
		flowchartManager = GameObject.Find("對話管理器").GetComponent<Flowchart>();
		playerRigidbody = FindObjectOfType<PlayerController>().GetComponent<Rigidbody2D>();
	}

	void Update()
	{

	}

	public static bool isTalking
	{
		get { return flowchartManager.GetBooleanVariable("對話中"); }
	}

	private void OnCollisionEnter2D(UnityEngine.Collision2D other)
	{
		if (other.gameObject.CompareTag("玩家"))
		{
			playerRigidbody.Sleep();
			Block targetBlock = talkFlowchart.FindBlock(onCollosionEnter);
			talkFlowchart.ExecuteBlock(targetBlock);
		}
	}

}
