using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[ ] randomPosition;

    float timer;

    void Start()
    {
        // Invoke : 지정된 시간 후에 함수를 호출하는 함수입니다.
        // InvokeReapeating : 지정된 시간 후에 함수를 호출한 뒤 특정한 시간마다 반복 실행하는 함수입니다.
        InvokeRepeating(nameof(CreateInfinite), 0, 5);

        // 성능 -> 1.Coroutine, 2 Update(), 3.InvokeRepeating()
        // 0초 뒤에 5초마다 반복 실행됩니다.
    }

    // 게임 오브젝트(Enemy)를 생성하는 함수
    public void CreateInfinite()
    {
        if (GameManager.instance.state == false)  return;
        
        Instantiate
        (
            Resources.Load<GameObject>("Enemy"),
            randomPosition[Random.Range(0,5)].position,
            Quaternion.identity
        );
    }
}
