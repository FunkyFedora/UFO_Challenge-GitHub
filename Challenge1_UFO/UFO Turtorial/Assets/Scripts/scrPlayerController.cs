using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrPlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int count;
    private int livesCount = 3;
    private bool levelTwo = true;

    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        count = 0;

        winText.text = "";

        setCountText();

        setLivesText();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            setCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);

            livesCount = livesCount - 1;

            setLivesText();
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count == 12 && levelTwo == true)
        {
            transform.position = new Vector2(70.2f, 0f);
            levelTwo = false;
        }

        if (count >= 20)
        {
            winText.text = "Congratulations, you have collected all 12 gems! You Win! -Jenna Ward";
            rb2d.isKinematic = true;
            rb2d.velocity = Vector2.zero;
        }
    }

    void setLivesText()
    {
        livesText.text = "Lives: " + livesCount.ToString();

        if (livesCount <= 0)
        {
            winText.text = "You lose :( -Jenna Ward";
            Destroy(this.gameObject);
        }
    }
}