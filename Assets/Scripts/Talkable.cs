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
		flowchartManager = GameObject.Find("��ܺ޲z��").GetComponent<Flowchart>();
		playerRigidbody = FindObjectOfType<PlayerController>().GetComponent<Rigidbody2D>();
	}

	void Update()
	{

	}

	public static bool isTalking
	{
		get { return flowchartManager.GetBooleanVariable("��ܤ�"); }
	}

	private void OnCollisionEnter2D(UnityEngine.Collision2D other)
	{
		if (other.gameObject.CompareTag("���a"))
		{
			playerRigidbody.Sleep();
			Block targetBlock = talkFlowchart.FindBlock(onCollosionEnter);
			talkFlowchart.ExecuteBlock(targetBlock);
		}
	}

}
