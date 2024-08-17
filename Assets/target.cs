using UnityEngine;

public class target : MonoBehaviour
{
    public Rigidbody2D rb;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.gravityScale = 3f;
            Invoke("Reset", 1.25f);

            GameObject.Find("Text (TMP)").GetComponent<score>().ScoreUpdate();
        }
        
    }

    void Reset()
    {
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.rotation = Quaternion.identity;
        transform.position = new Vector2(Random.Range(0, 9), Random.Range(-4, 5));
    }
}
