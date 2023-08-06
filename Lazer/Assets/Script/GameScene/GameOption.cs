using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOption : MonoBehaviour
{
    /// <summary>ゲーム時間</summary>
    [SerializeField]
    private float gameTime;

    /// <summary><アステロイドの生成間隔/summary>
    [SerializeField]
    private float asteroidSpan;

    /// <summary>アステロイドのスポーンポイント(使ってない)</summary>
    [SerializeField]
    List<spawnPoint> point;

    /// <summary>アステロイドのスポーンポイントクラス(使ってない)</summary>
    [Serializable]
    public class spawnPoint
    {
        public float minYArea;
        public float maxYArea;
    }

    /// <summary>
    /// ゲーム時間取得
    /// </summary>
    /// <returns></returns>
    public float GetGameTime()
    {
        return gameTime;
    }

    /// <summary>
    /// アステロイド生成間隔取得
    /// </summary>
    /// <returns></returns>
    public float GetAsteroidSpan()
    {
        return asteroidSpan;
    }

    /// <summary>
    /// アステロイド生成位置取得(使ってない)
    /// </summary>
    /// <returns></returns>
    public List<spawnPoint> GetSpawnPoint() 
    {
        return point;
    }
}
