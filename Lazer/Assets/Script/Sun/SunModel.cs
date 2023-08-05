using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FUTADA
{
    public class SunModel
    {
        /// <summary>�����_���ړ�����</summary>
        private float moveSpan;

        /// <summary>�Ǝ˃p���[</summary>
        private float flamePower;

        /// <summary>�ړ��X�s�[�h</summary>
        private float moveSpeed;

        /// <summary>�ړ����� </summary>
        private SunVector moveVec;
         
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="span">�����_���ړ�����</param>
        /// <param name="power">�Ǝ˃p���[</param>
        /// <param name="speed">�ړ��X�s�[�h</param>
        public SunModel(float span, float power, float speed)
        {
            this.moveSpan = span;
            this.flamePower = power;
            this.moveSpeed = speed;
        }

        /// <summary>
        /// �ړ��X�s�[�h�擾
        /// </summary>
        /// <returns></returns>
        public float GetMoveSpeed()
        {
            return moveSpeed;
        }

        /// <summary>
        /// �Ǝ˃p���[�擾
        /// </summary>
        /// <returns></returns>
        public float GetFlamePower()
        {
            return flamePower;
        }


        /// <summary>
        /// �ړ������擾
        /// </summary>
        /// <returns></returns>
        public float GetMoveSpan()
        {
            return moveSpan;
        }

        /// <summary>
        /// T�^��enum�̗v�f�������_���ɑI������W�F�l���b�N���\�b�h
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public SunVector GetRandomEnum()
        {
            System.Array enumValues = System.Enum.GetValues(typeof(SunVector));
            SunVector randomEnumValue =  (SunVector)enumValues.GetValue(Random.Range(0, enumValues.Length));

            moveVec = randomEnumValue;
            return randomEnumValue;
        }

    }
}
