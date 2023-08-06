using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    /// <summary>破壊カウント表示テキスト</summary>
    [SerializeField]
    private Text breakCount;

    private void Start()
    {
        // UI表示
        breakCount.text = GameData.breakCount.ToString();
    }

    void Update()
    {
        // スペースキーでタイトルに戻る
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TItle");
        }
    }

}
