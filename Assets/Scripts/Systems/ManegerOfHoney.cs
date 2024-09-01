using TMPro;
using UnityEngine;

public class ManegerOfHoney : MonoBehaviour
{
    public static ManegerOfHoney Instance { get; set; }
    [SerializeField] public int Honey = 6;
    [SerializeField] public TextMeshProUGUI HoneyCombText;

    private void Start()
    {
        Instance = this;
    }
    public void BuyForHoney()
    {
        HoneyCombText.text = Honey.ToString();
    }
}
