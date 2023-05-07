using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Acces the SceneManager class
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;

    public int score;

    private bool isGrounded;

    public Ui ui;

    // Update is called once per frame
    void Update()
    {
        //get the horizontsal and vertical inputs
        float x = Input.GetAxis("Horizontal")*moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // set our velocity based on our inputs
        rig.velocity = new Vector3(x, rig.velocity.y , z);

        //create a copy of our velocity variable and set the Y axis to be 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        //if we're moving, rotate to face our moving direction
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }
        
        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(transform.position.y < -2)
        {
            GameOver();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    //Restart the scene when character goes out from floor
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        ui.setScoreText(score);
    }


}
