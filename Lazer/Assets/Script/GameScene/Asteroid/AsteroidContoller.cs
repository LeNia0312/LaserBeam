using FUTADA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidContoller : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>パワー(仮)</summary>
    [SerializeField]
    private float power;

    /// <summary>model</summary>
    private AsteroidModel model;

    public void Awake()
    {
        model = new AsteroidModel(moveSpeed, power);
        model.SetVector(CheckVector());
    }

    public void Init()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 移動
    /// </summary>
    public void UpdateMove()
    {
        SunVector vector = model.GetVector();
        float speed = model.GetSpeed();

        switch (vector)
        {
            case SunVector.RIGHT:
                // 右方向に移動
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;

                case SunVector.LEFT:
                // 左方向に移動
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
        }
       
    }

    private void Update()
    {
        UpdateMove();
    }

    /// <summary>
    /// 進行方向を決定
    /// 生成された座標によって変更する
    /// </summary>
    /// <returns></returns>
    private SunVector CheckVector()
    {
        SunVector vec = SunVector.LEFT;

        if(this.gameObject.transform.position.x < 0)
        {
            vec = SunVector.RIGHT;
        }

        return vec;
    }
}
