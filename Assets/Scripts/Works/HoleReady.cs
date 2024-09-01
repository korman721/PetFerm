using UnityEngine;

public class HoleReady : MonoBehaviour
{
    public static HoleReady instance;

    public bool ready;

    private void Start()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TheHole"))
        {
            ready = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TheHole"))
        {
            ready = false;
        }
    }
}
