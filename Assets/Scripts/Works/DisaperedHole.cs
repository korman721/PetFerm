using UnityEngine;

public class DisaperedHole : MonoBehaviour
{
    public static DisaperedHole Instance;

    [SerializeField] public int index;

    private void Start()
    {
        Instance = this;
    }
    private void OnMouseDown()
    {
        BuySystem.Instance.hole = index;
    }
}