using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

	public GameManager gameManger;

	//ball is fall
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ball")
			gameManger.DecreaseLives ();
	}
}
