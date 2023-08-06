using FUTADA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidModel
{
    /// <summary>�ړ����x </summary>
    private float moveSpeed;

    /// <summary>�p���[(�g���ĂȂ�)</summary>
    private float power;

    /// <summary>�ړ����� </summary>
    private SunVector vec;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="power"></param>
   public AsteroidModel(float speed, float power)
    {
        this.moveSpeed = speed;
        this.power = power;

    }

    /// <summary>
    /// �ړ������擾
    /// </summary>
    /// <returns></returns>
    public SunVector GetVector() { return this.vec; }

    /// <summary>
    /// �ړ����x�擾
    /// </summary>
    /// <returns></returns>
    public float GetSpeed() { return moveSpeed; }

    /// <summary>
    /// �ړ������Z�b�g
    /// </summary>
    /// <param name="vec"></param>
    public void SetVector(SunVector vec)
    {
        this.vec = vec;
    }
}
