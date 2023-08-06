using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FUTADA
{
    public class PlayerModel
    {
        /// <summary>�G�l���M�[���ݒn</summary>
        private float currentEnergy;

        /// <summary>�G�l���M�[���~�ő�l</summary>
        private float maxEnergy;

        /// <summary>�ړ��X�s�[�h</summary>
        private float moveSpeed;

        /// <summary>�C��ړ��X�s�[�h</summary>
        private float cannonMoveSpeed;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="currentEnergy"></param>
        /// <param name="maxEnergy"></param>
        /// <param name="speed"></param>
        public PlayerModel(float currentEnergy, float maxEnergy, float speed)
        {
            this.currentEnergy = currentEnergy;
            this.maxEnergy = maxEnergy;
            this.moveSpeed = speed;
        }

        /// <summary>
        /// �ړ����x�擾
        /// </summary>
        /// <returns></returns>
        public float GetMoveSpeed()
        {
            return moveSpeed;
        }

        /// <summary>
        /// ���݂̃G�l���M�[�c�ʂ̍X�V
        /// </summary>
        /// <param name="value"></param>
        public void UpdateCurrentEnergy(float value)
        {
            currentEnergy = value;
            if(currentEnergy > maxEnergy) currentEnergy = maxEnergy;
            if(currentEnergy < 0) currentEnergy = 0;
        }

        /// <summary>
        /// ���݂̃G�l���M�[�c�ʎ擾
        /// </summary>
        /// <returns></returns>
        public float GetCurrentEnergy()
        {
           return currentEnergy;
        }
    }
}
