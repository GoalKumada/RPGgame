using UnityEngine;
using UnityEngine.EventSystems;

public class ExplainPanel : MonoBehaviour
{
    public static bool isExplained = false;

    private void Start()
    {
        if (isExplained)
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!isExplained && Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
            isExplained = true;
        }
    }
}
