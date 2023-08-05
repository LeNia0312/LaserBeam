using FUTADA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FUTADA
{
    public class PlayerController : MonoBehaviour
    {
        /// <summary>���݂̃G�l���M�[�l</summary>
        [SerializeField]
        private float currentEnergy;

        /// <summary>�G�l���M�[���~�ő�l </summary>
        [SerializeField]
        private float maxtEnergy;

        /// <summary>�ړ����x</summary>
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private GameObject sunObject;

        private PlayerModel model;


        /// <summary>���S�_����̋����i���a�j</summary>
        private float radius;

        /// <summary>���݂̊p�x</summary>
        private float angle = 0f;

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sun"></param>
        public void Init()
        {
           
            // ���f���쐬
            model = new PlayerModel(currentEnergy, maxtEnergy, moveSpeed);

            radius = Vector3.Distance(sunObject.transform.position, this.transform.position);
        }

        /// <summary>
        /// �v���C���[�ړ�
        /// </summary>
        public void PlayerMove(float time, SunVector vec)
        {
            // �p�x���X�V
            angle += model.GetMoveSpeed() * time * (int)vec;

            // ���W�A���ɕϊ�
            float radian = angle * Mathf.Deg2Rad;

            // ���S�_�̈ʒu�ɉ~�^����K�p���āA�I�u�W�F�N�g�̈ʒu���X�V
            Vector3 newPosition = sunObject.transform.position + new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0f) * radius;
            this.transform.position = newPosition;

            // �I�u�W�F�N�g���̂̉�]
            float rotationAngle = angle + 90f;
            this.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }
    }
}
