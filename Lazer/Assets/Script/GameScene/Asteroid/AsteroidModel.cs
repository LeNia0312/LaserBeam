using FUTADA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidModel
{
    /// <summary>移動速度 </summary>
    private float moveSpeed;

    /// <summary>パワー(使ってない)</summary>
    private float power;

    /// <summary>移動方向 </summary>
    private SunVector vec;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="power"></param>
   public AsteroidModel(float speed, float power)
    {
        this.moveSpeed = speed;
        this.power = power;

    }

    /// <summary>
    /// 移動方向取得
    /// </summary>
    /// <returns></returns>
    public SunVector GetVector() { return this.vec; }

    /// <summary>
    /// 移動速度取得
    /// </summary>
    /// <returns></returns>
    public float GetSpeed() { return moveSpeed; }

    /// <summary>
    /// 移動方向セット
    /// </summary>
    /// <param name="vec"></param>
    public void SetVector(SunVector vec)
    {
        this.vec = vec;
    }
}
