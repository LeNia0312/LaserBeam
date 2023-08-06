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


    [SerializeField]
    private BoomController boom;

    /// <summary>model</summary>
    private AsteroidModel model;

    private float halfScreenHeight;

    public void Awake()
    {
        model = new AsteroidModel(moveSpeed, power);
        model.SetVector(CheckVector());
    }

    public void Init()
    {
        this.gameObject.SetActive(true);

        halfScreenHeight = Camera.main.orthographicSize;
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

        CheckForOutOfBoundsObjects();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "player")
        {
            // ばくふー
            var obj = Instantiate(boom, this.transform.position, Quaternion.identity);
            obj.Init();

            // プレイヤー
            Destroy(this.gameObject);

        }
    }

    void CheckForOutOfBoundsObjects()
    {
        if (this.transform.position.y < -halfScreenHeight)
        {
            Destroy(this.gameObject);
        }
        
    }
}
