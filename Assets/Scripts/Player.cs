using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float playerVelocity;
    private Vector3 playerPosition;

    private int playerLives;
    private int playerPoints;
    // Use this for initialization
	void Start () {
        playerPosition = gameObject.transform.position;
	    playerLives = 3;
	    playerPoints = 0;
	}
	
	// Update is called once per frame
    private void Update()
    {
        //horizontal movement
        playerPosition.x += Input.GetAxis("Horizontal")*playerVelocity;
        if (playerPosition.x > 110 && playerPosition.x < 615)
        {
            
        }
        else if (playerPosition.x < 110)
        {
            playerPosition.x = 110;
        }
        else if (playerPosition.x > 615)
        {
            playerPosition.x = 615;
        }
        transform.position = playerPosition;

        

        //leave the game 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    public void addPoints(int points)
    {
        playerPoints += points;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(5.0f,3.0f,200.0f,200.0f),"lives:"+playerLives +"Score:" +playerPoints);
    }

    public void TakeLife()
    {
        playerLives--;
    }
}
