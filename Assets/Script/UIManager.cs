using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text score;

    void Start()
    {
        
    }

    void Update()
    {
        score.text = "Kill : " + GameManager.instance.score;
    }
}
