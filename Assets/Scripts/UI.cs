using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject chooseBattleOrRunWindow;
    [SerializeField] private GameObject runCheckWindow;
    [SerializeField] private GameObject chooseAllyWindow;
    [SerializeField] private GameObject chooseCommandWindow;
    [SerializeField] private GameObject chooseEnemyWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void WindowActivated(GameObject window)
    {
        window.SetActive(true);
    }

}
