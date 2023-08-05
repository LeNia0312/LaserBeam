using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FUTADA
{
    public class SunController : MonoBehaviour
    {
        /// <summary>�ړ��Ԋu</summary>
        [SerializeField]
        private float moveSpan;

        /// <summary>���z���p���[</summary>
        [SerializeField]
        private float flamePower;

        /// <summary>�ړ����x</summary>
        [SerializeField]
        private float moveSpeed;

        /// <summary>���z��</summary>
        [SerializeField]
        GameObject sunLight;

        /// <summary>���S�_����̋����i���a�j</summary>
        [SerializeField]
        private float radius = 2f;

        /// <summary>���z�f�[�^���f��</summary>
        private SunModel model;

        /// <summary>���݂̊p�x</summary>
        private float angle = 0f;

        /// <summary>�ړ�����</summary>
        private SunVector vec;


        /// <summary>
        /// ������
        /// </summary>
        public void Init()
        {
            // ���f���쐬
            model = new SunModel(moveSpan, flamePower, moveSpeed);

        }

        /// <summary>
        /// ���z���ړ�
        /// </summary>
        public void SunLightMove()
        {

            // �p�x���X�V
            angle += model.GetMoveSpeed() * Time.deltaTime * (int)vec;

            // ���W�A���ɕϊ�
            float radian = angle * Mathf.Deg2Rad;

            // ���S�_�̈ʒu�ɉ~�^����K�p���āA�I�u�W�F�N�g�̈ʒu���X�V
            Vector3 newPosition = this.transform.position + new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0f) * radius;
            sunLight.transform.position = newPosition;

            // �I�u�W�F�N�g���̂̉�]
            float rotationAngle = angle;
            sunLight.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }

        public void ChangeVector()
        {
            vec = model.GetRandomEnum();
        }

        public float GetTimeSpan()
        {
            return model.GetMoveSpan();
        }

    }
}
