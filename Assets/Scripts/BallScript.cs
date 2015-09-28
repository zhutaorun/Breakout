using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    private Rigidbody2D ballRigidbody2D;
    // GameObject
    public GameObject playerObject;

    public AudioClip hitSound;

	public GameManager gameManager;

	// Use this for initialization
	void Start() {
        // create the force
        ballInitialForce = new Vector2(2000.0f, 4000.0f);

        // set to inactive
        ballIsActive = false;

        // ball position
        ballPosition = new Vector3(playerObject.transform.position.x,playerObject.transform.position.y+25.0f,playerObject.transform.position.z);
		 
	    ballRigidbody2D = GetComponent<Rigidbody2D>();

		ballRigidbody2D.velocity = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update() {
        

        if (!ballIsActive && playerObject != null)
       	{
            // get and use the player position
    	   ballPosition.x = playerObject.transform.position.x;

            // apply player X position to the ball
           transform.position = ballPosition;
        }

       
	}

	//when ball hit block,play sound
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ballIsActive)
        {
            GetComponent<AudioSource>().PlayOneShot(hitSound);
        }
    }

	public void StartBall()
	{
		// check if is the first play
		if (!ballIsActive){
			// add a force
			ballRigidbody2D.isKinematic = false;
			ballRigidbody2D.AddForce(ballInitialForce);
			// set ball active
			ballIsActive = !ballIsActive;
		}
	}

	public void StopBall()
	{
		//Check if ball falls
		if (ballIsActive)
		{
			ballIsActive = !ballIsActive;
			//ballPosition.x = playerObject.transform.position.x;
			//ballPosition.y = playerObject.transform.position.y+25.0f;
			transform.position = ballPosition;
			
			ballRigidbody2D.isKinematic = true;
			//playerObject.SendMessage("TakeLife");

			gameManager.DecreaseLives();
		}
	}

}
