using UnityEngine;

public class BuyHole : MonoBehaviour
{

    [SerializeField] private GameObject Window;

    private BoxCollider2D Box;
    private CircleCollider2D Circle;

    private int Check = 0;

    private void Start()
    {
        Box = GetComponentInParent<BoxCollider2D>();
        Circle = GetComponent<CircleCollider2D>();
    }

    public void HoleBuy(int price)
    {
        if (ManegerOfPollen.Instance.Pollen >= price)
        {
            ManegerOfPollen.Instance.Pollen -= price;
            ManegerOfPollen.Instance.pollenText.text = ManegerOfPollen.Instance.Pollen.ToString();

            Check++;

            Window.SetActive(false);

            Circle.enabled = false;
            Box.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Check == 0)
        {
            Window.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Check == 0)
        {
            Window.SetActive(false);
        }
    }
}
