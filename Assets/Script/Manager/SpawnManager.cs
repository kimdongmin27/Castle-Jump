using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[ ] randomPosition;

    float timer;

    void Start()
    {
        // Invoke : ������ �ð� �Ŀ� �Լ��� ȣ���ϴ� �Լ��Դϴ�.
        // InvokeReapeating : ������ �ð� �Ŀ� �Լ��� ȣ���� �� Ư���� �ð����� �ݺ� �����ϴ� �Լ��Դϴ�.
        InvokeRepeating(nameof(CreateInfinite), 0, 5);

        // ���� -> 1.Coroutine, 2 Update(), 3.InvokeRepeating()
        // 0�� �ڿ� 5�ʸ��� �ݺ� ����˴ϴ�.
    }

    // ���� ������Ʈ(Enemy)�� �����ϴ� �Լ�
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
