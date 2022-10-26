using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d;
    public Text livesText;
    public float speed;
    public Text score;
    private int scoreValue;
    private int lives;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        livesText.text = "Lives:" + lives.ToString();
        anim= GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement* speed)); 

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject); 
        }
        if(collision.collider.tag =="Enemy")
        {
            lives -= 1;
            livesText.text = "Lives:" + lives.ToString();
            Destroy(collision.collider.gameObject);
        }
        if(lives == 0)
        {
            gameObject.SetActive(false);
        }
        if(scoreValue == 4)
        { 
            scoreValue = 0;
            lives = 3;
            score.text = scoreValue.ToString();
            livesText.text = "Lives:" + lives.ToString();
            transform.position = new Vector3(70.0f,0.0f,0.0f);

        }

    } 


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag =="Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0,3), ForceMode2D.Impulse);
            }
        }
    }
}
