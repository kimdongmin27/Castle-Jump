using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer enemySprite;

    private Material enemyMaterial;

    [SerializeField] int health = 100;
    [SerializeField] Material flash;
    [SerializeField] GameObject effect;

    private void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        enemyMaterial = enemySprite.material;

        flash = new Material(flash);
    }

    void Update()
    {
        if (GameManager.instance.state == false) return;

        transform.Translate(Vector3.down * Time.deltaTime);

        if(transform.position.y <= -4.5f || health <= 0)
        {
            // effect가 활성화되어 파티클이 보이도록 설정합니다.
            effect.gameObject.SetActive(true);

            // Enemy 오브젝트가 0.25초 뒤에 파괴됩니다.
            Destroy(gameObject, 0.25f);
        }
    }

    // 게임 오브젝트와 충돌을 했을 때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {      
        // 충돌한 게임 오브젝트의 태그가 Lazer라면
        if(other.CompareTag("Lazer"))
        {
            health -= other.GetComponent<Bullet>().attack;
            StartCoroutine(nameof(Damage));
        }

        // Character라는 태그를 가진 게임 오브젝트가 충돌했을 때
        if(other.CompareTag("Character"))
        {
            // 충돌당한 게임 오브젝트가 파괴됩니다.
            Destroy(other.gameObject);
        }
    }

    // 게임 오브젝트가 파괴되었을 때 호출되는 함수
    private void OnDestroy()
    {
        GameManager.instance.score += 100;

        // 게임 데이터를 저장합니다.
        GameManager.instance.Save();

        SoundManager.instance.SoundStart(1);
    }

    private IEnumerator Damage()
    {
        enemySprite.material = flash;
        flash.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(0.05f);

        enemySprite.material = enemyMaterial;
    }
}
