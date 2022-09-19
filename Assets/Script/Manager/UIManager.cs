using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Image fadePanel;
    [SerializeField] GameObject mainMenu;

    void Update()
    {
        score.text = "Kill : " + GameManager.instance.score;
    }

    // 이 함수를 버튼에 등록할 때 매개 변수로 게임 오브젝트를 등록할 수 있습니다.
    // 등록한 게임 오브젝트를 비활성화할 수 있습니다.
    public void GameStart()
    {
        StartCoroutine(FadeIn(1));
        
        GameManager.instance.state = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Time.unscaledDeltaTime : Time Scale의 영향을 받지 않는 시간입니다.
    }

    // 매개 변수 time은 FadeIn 되는 시간을 조절하는 변수입니다.
    private IEnumerator FadeIn(float time)
    {
        Color color = fadePanel.color;
        
        // 0 ~ 255 (0 ~ 1)사이의 비율로 계산합니다. 
        // Image의 알파값이 0이 되는 순간 While문을 탈출합니다.
        while(color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            fadePanel.color = color;
            yield return null;
        }

        // 코루틴 함수가 다 끝났을 때 mainMenu를 비활성화합니다.
        mainMenu.SetActive(false);
    }
    
}
