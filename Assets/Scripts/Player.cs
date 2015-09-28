using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float playerVelocity;
    private Vector3 playerPosition;
    public float boundary;

    private int playerLives;
    private int playerPoints;

    public AudioClip pointSound;
    public AudioClip lifeSound;
    // Use this for initialization
	void Start() {
        playerPosition = gameObject.transform.localPosition;
	    playerLives = 3;
	    playerPoints = 0;
	}
	
	// Update is called once per frame
    private void Update()
    {
        //horizontal movement
        playerPosition.x += Input.GetAxis("Horizontal")*playerVelocity;

        //leave the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        transform.localPosition =playerPosition;

        // boundaries
        if (playerPosition.x < -boundary)
        {
            transform.localPosition = new Vector3(-boundary, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.x > boundary)
        {
            transform.localPosition = new Vector3(boundary, playerPosition.y, playerPosition.z);
        }

        //check game state
        WinLose();
    }

    private void WinLose()
    {
        //restart the game
        if (playerLives == 0)
        {
            Application.LoadLevel("first");
        }

        //blocks destroyed
        if(GameObject.FindGameObjectsWithTag("Block").Length==0)
        {
            //Check the current level
            if (Application.loadedLevelName == "first")
            {
                Application.LoadLevel("second");
            }
            else
            {
                Application.Quit();
            }
        }
    }
   

    public void AddPoints(int points)
    {
        playerPoints += points;
        GetComponent<AudioSource>().PlayOneShot(pointSound);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(5.0f,3.0f,200.0f,200.0f),"lives:"+playerLives +"Score:" +playerPoints);
    }

    public void TakeLife()
    {
        playerLives--;
        GetComponent<AudioSource>().PlayOneShot(lifeSound);
    }
}
