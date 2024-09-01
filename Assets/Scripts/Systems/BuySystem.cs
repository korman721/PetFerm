using UnityEngine;

public class BuySystem : MonoBehaviour
{
    public static BuySystem Instance;

    [SerializeField] private GameObject[] flowers;
    [SerializeField] private int[] costs;

    [SerializeField] public int hole;

    private GameObject flyingFlower;
    private Camera mainCamera;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    public void Buy(int number)
    {
        if (ManegerOfHoney.Instance.Honey >= costs[number] && OffHoles.Instance.FreeHoles())
        {
            ManegerOfHoney.Instance.Honey -= costs[number];
            ManegerOfHoney.Instance.BuyForHoney();

            if (flyingFlower != null)
            {
                Destroy(flyingFlower);
            }

            for (int i = 0; i < flowers.Length; i++)
            {
                if (i == number)
                {
                    flyingFlower = Instantiate(flowers[number]);
                    StoreManager.Instance.Honeystore.SetActive(false);
                    StoreManager.Instance.edin = 0;
                }
            }
        }
    }
    private void Update()
    {
        if (flyingFlower != null)
        {
            Vector2 vector2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 WordPos = mainCamera.ScreenToWorldPoint(vector2);

            flyingFlower.transform.position = new Vector3(WordPos.x, WordPos.y, 0);

            bool ready = HoleReady.instance.ready;

            if (ready && Input.GetMouseButtonDown(0))
            {
                OffHoles.Instance.WorkWithHoles(hole);
                flyingFlower.GetComponentInChildren<BoxCollider2D>().enabled = true;
                flyingFlower.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
                flyingFlower = null;
            }
        }
    }
    public void BuyHoneyComb(int costs)
    {
        if (ManegerOfPollen.Instance.Pollen >= costs)
        {
            ManegerOfPollen.Instance.Pollen -= costs;
            ManegerOfPollen.Instance.pollenText.text = ManegerOfPollen.Instance.Pollen.ToString();
            ManegerOfHoney.Instance.Honey += 1;
            ManegerOfHoney.Instance.BuyForHoney();
        }
    }
}
