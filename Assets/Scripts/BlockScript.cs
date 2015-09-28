using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour
{
    public int hitsTokill;
    public int points;
    private int numberOfHits;

	// Use this for initialization
	void Start()
	{
	    numberOfHits = 0;
	}
	
	// Update is called once per frame
	void Update() {
	  
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;
            if (numberOfHits == hitsTokill)
            {
                //get reference of player object
                //GameObject player = GameObject.FindGameObjectWithTag("Player");

                //send message 
                //player.SendMessage("AddPoints", points);

                //destroy the object
                //Destroy(this.gameObject);


				//set it display
				gameObject.SetActive(false);
				GameManager.score += points;
				GameManager.blockCount --;
            }
        }
    }
}
