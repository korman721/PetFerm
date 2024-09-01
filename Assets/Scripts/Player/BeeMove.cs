using System.Collections;
using UnityEngine;

public class BeeMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movePos;
    private Animator anim;

    public float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movePos.x = Input.GetAxisRaw("Horizontal");
        movePos.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movePos.x);
        anim.SetFloat("Vertical", movePos.y);
        anim.SetFloat("Speed", movePos.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movePos * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            StartCoroutine(WaitForPollite(1f));
        }
    }
    private static IEnumerator WaitForPollite(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ManegerOfPollen.Instance.SetScore(1);
    }
}
