using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int dragon;

    // bool 변수는 초기화를 하지 않으면 false 값이 자동으로 들어갑니다.
    public bool state;
    
    private void Awake()
    {
        // Start 함수 이전에 시작이 됩니다.
        if (instance == null)
        {
            instance = this;
        }

        // 게임 데이터를 게임이 시작할 때 불러옵니다.
        Load();
    }

    public void Save()
    {
        // PlayerPrefs.SetInt 정수형 데이터를 저장하는 함수
        // KEY - VALUE를 가지고 저장합니다.
        PlayerPrefs.SetInt("Score", score);

        PlayerPrefs.SetInt("Dragon", dragon);
    }

    public void Load()
    {
        // PlayerPrefs.GetInt 정수형 데이터를 불러오는 함수
        score = PlayerPrefs.GetInt("Score");

        dragon = PlayerPrefs.GetInt("Dragon");
    }
}
