using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    public int attack = 20;

    // 오브젝트 자체에서 어떤 pool에 들어가야 하는지 선언해주는 과정입니다.
    private IObjectPool<Bullet> lazerPool;

    void Update()
    {
        if (GameManager.instance.state == false) return;

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        lazerPool = pool;
    }

    // 게임 오브젝트와 충돌을 했을 때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        // 메모리 풀에 반환되는 함수
        lazerPool.Release(this);
    }
}
