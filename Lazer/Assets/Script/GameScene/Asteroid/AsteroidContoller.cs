using FUTADA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidContoller : MonoBehaviour
{
    /// <summary>�ړ����x</summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>�p���[(��)</summary>
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
    /// �ړ�
    /// </summary>
    public void UpdateMove()
    {
        SunVector vector = model.GetVector();
        float speed = model.GetSpeed();

        switch (vector)
        {
            case SunVector.RIGHT:
                // �E�����Ɉړ�
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;

                case SunVector.LEFT:
                // �������Ɉړ�
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
        }
       
    }

    private void Update()
    {
        UpdateMove();
    }

    /// <summary>
    /// �i�s����������
    /// �������ꂽ���W�ɂ���ĕύX����
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
