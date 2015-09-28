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

	// Use this for initialization
	void Start() {
        // create the force
        ballInitialForce = new Vector2(2000.0f, 4000.0f);

        // set to inactive
        ballIsActive = false;

        // ball position
        ballPosition = transform.position;

	    ballRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() {
        // check for user input
        if (Input.GetButtonDown("Jump") == true)
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

        if (!ballIsActive && playerObject != null)
        {
            // get and use the player position
            ballPosition.x = playerObject.transform.position.x;

            // apply player X position to the ball
            transform.position = ballPosition;
        }

        //Check if ball falls
        if (ballIsActive && transform.position.y < -6)
        {
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = 65f;
            transform.position = ballPosition;

            ballRigidbody2D.isKinematic = true;
            playerObject.SendMessage("TakeLife");
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ballIsActive)
        {
            GetComponent<AudioSource>().PlayOneShot(hitSound);
        }
    }
}
