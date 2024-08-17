using UnityEngine;

public class launchable: MonoBehaviour
{
    public Camera camera;
    public Rigidbody2D rb;

    public float launchForce;

    bool held = false;
    bool canLaunch = true;
    Vector3 origin;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Collider2D result = Physics2D.OverlapPoint(camera.ScreenToWorldPoint(Input.mousePosition));
            if (result != null && canLaunch && result.transform.gameObject.name == this.gameObject.name)
            {
                held = true;
                origin = transform.position;
            }
            
        }

        if (held && canLaunch)
        {
            if (camera.ScreenToWorldPoint(Input.mousePosition).x < -1.5f)
            {
                transform.position = new Vector2(camera.ScreenToWorldPoint(Input.mousePosition).x, camera.ScreenToWorldPoint(Input.mousePosition).y);
                print(origin);
            }
            else
            {
                transform.position = new Vector2(-1.5f, camera.ScreenToWorldPoint(Input.mousePosition).y);
                print(origin);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && held && canLaunch)
        {
            held = false;
            canLaunch = false;

            rb.gravityScale = 1f;
            rb.velocity = (new Vector2(-(transform.position.x - origin.x), -(transform.position.y - origin.y)) * Vector2.Distance(transform.position, origin) * launchForce);
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = origin;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        canLaunch = true;
    }
}
