using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
