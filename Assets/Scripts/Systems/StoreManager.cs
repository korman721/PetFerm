using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance { get; set; }

    [SerializeField] private GameObject Store;
    [SerializeField] public GameObject Honeystore;
    [SerializeField] private GameObject Pollitestore;

    public int edin = 0;
    private void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        OpenStoreCls();
    }
    public void OpenStoreCls()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            edin += 1;
            if (edin == 1)
            {
                Store.SetActive(true);
            }
            else
            {
                Store.SetActive(false);
                edin = 0;
                if (Honeystore.activeSelf)
                {
                    Honeystore.SetActive(false);
                }
                if (Pollitestore.activeSelf) { Pollitestore.SetActive(false); }
                
            }
        }
    }
}
