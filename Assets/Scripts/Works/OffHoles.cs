using UnityEngine;

public class OffHoles : MonoBehaviour
{
    public static OffHoles Instance;

    [SerializeField] GameObject[] holes;

    void Start()
    {
        Instance = this;
    }

    public void WorkWithHoles(int index)
    {
        holes[index].gameObject.SetActive(false);
    }
    public bool FreeHoles()
    {
        for(int i = 0; i < holes.Length; i++)
        {
            if (holes[i].gameObject.activeSelf == false)
            {
                continue;
            }
            else
            {
                return true;
            }
        }
        return false;
    }
}
