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
    }
}
