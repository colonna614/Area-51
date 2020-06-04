
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerSpriteController : MonoBehaviour {

    public float moveSpeed;
    Animator anim;
    Rigidbody2D playerRigidBody;
    bool playerMoving;
    Vector2 lastMove;
    bool movementEnabled = true;


	// Use this for initialization
    void Start () {

        anim = GetComponent<Animator> ();
        playerRigidBody = GetComponent<Rigidbody2D> ();

	}

    // Update is called once per frame
    void Update () {
        if (!movementEnabled) return;
        float xInput = Input.GetAxisRaw("Horizontal");


        playerMoving = false;

        if (xInput > 0.5f || xInput < -0.5f) // Moving horizontally
        {
            playerRigidBody.velocity = new Vector2(xInput * moveSpeed, playerRigidBody.velocity.y);
            anim.gameObject.transform.Translate(new Vector3(xInput * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(xInput, 0f);
        }
        else
        {
            playerRigidBody.velocity = new Vector2( 0f, playerRigidBody.velocity.y);
        }

        //if (xInput < -0.2f && StepCounter.stepCount > 0)
        //{
        //    StepCounter.stepCount -= 1;
        //}

        anim.SetFloat("MoveX", xInput);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

	}

   public void OnSpawnPlayer(Vector2 directionToFace)
    {
        lastMove = directionToFace;
    }

    public void EnableMovement(bool enable)
    {
        movementEnabled = enable;
        if(!enable)
        {
            playerMoving = false;
            playerRigidBody.velocity = new Vector2(0f, 0f);

            anim.SetFloat("MoveX", 0f);
            anim.SetBool("PlayerMoving", playerMoving);
        }
    }
    void OnParticleCollision(GameObject other)
    {

        if (other.tag == "Bossatt")
        {
            Debug.Log("hit  me");
            Destroy(gameObject);
            SceneManager.LoadScene("You Lose");
        }

    }

}
