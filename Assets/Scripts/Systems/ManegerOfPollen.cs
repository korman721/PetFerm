using TMPro;
using UnityEngine;

public class ManegerOfPollen : MonoBehaviour
{
    public static ManegerOfPollen Instance { get; set; }

    [SerializeField] public int Pollen;
    [SerializeField] public TextMeshProUGUI pollenText;

    private void Start()
    {
        Instance = this;
    }

    public void SetScore(int Polle)
    {
        Pollen += Polle;
        pollenText.text = Pollen.ToString();
    }
}
