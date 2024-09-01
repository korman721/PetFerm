using UnityEngine;

public class PollenCollect : MonoBehaviour
{
    [SerializeField] public Animator anim;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Pollen", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Pollen", false);
        }
    }
}
