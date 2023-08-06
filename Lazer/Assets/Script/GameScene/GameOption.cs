using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOption : MonoBehaviour
{
    [SerializeField]
    private float gameTime;

    [SerializeField]
    private float asteroidSpan;

    [SerializeField]
    List<spawnPoint> point;


    [Serializable]
    public class spawnPoint
    {
        public float minYArea;
        public float maxYArea;
    }


    /// <summary>
    /// ƒQ[ƒ€ŠÔæ“¾
    /// </summary>
    /// <returns></returns>
    public float GetGameTime()
    {
        return gameTime;
    }

    public float GetAsteroidSpan()
    {
        return asteroidSpan;
    }

    public List<spawnPoint> GetSpawnPoint() 
    {
        return point;
    }
}
