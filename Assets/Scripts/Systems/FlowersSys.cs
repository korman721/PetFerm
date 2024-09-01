using UnityEngine;

public class FlowersSys : MonoBehaviour
{

    [SerializeField] private GameObject[] flowers;
    [SerializeField] private int[] costs;
    private GameObject flyingFlower;
    private Camera mainCamera;


    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void StartPlacingFlower(int number)
    {
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

    private void Update()
    {
        if (flyingFlower != null)
        {
            Vector2 vector2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 WordPos = mainCamera.ScreenToWorldPoint(vector2);

            flyingFlower.transform.position = new Vector3(WordPos.x, WordPos.y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                flyingFlower = null;
            }
        }
    }
}
