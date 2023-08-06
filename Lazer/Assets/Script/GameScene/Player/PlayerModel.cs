using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FUTADA
{
    public class PlayerModel
    {
        /// <summary>エネルギー現在地</summary>
        private float currentEnergy;

        /// <summary>エネルギー貯蓄最大値</summary>
        private float maxEnergy;

        /// <summary>移動スピード</summary>
        private float moveSpeed;

        /// <summary>砲台移動スピード</summary>
        private float cannonMoveSpeed;

        /// <summary>
        /// コンストラクタ
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
        /// 移動速度取得
        /// </summary>
        /// <returns></returns>
        public float GetMoveSpeed()
        {
            return moveSpeed;
        }

        /// <summary>
        /// 現在のエネルギー残量の更新
        /// </summary>
        /// <param name="value"></param>
        public void UpdateCurrentEnergy(float value)
        {
            currentEnergy = value;
            if(currentEnergy > maxEnergy) currentEnergy = maxEnergy;
            if(currentEnergy < 0) currentEnergy = 0;
        }

        /// <summary>
        /// 現在のエネルギー残量取得
        /// </summary>
        /// <returns></returns>
        public float GetCurrentEnergy()
        {
           return currentEnergy;
        }
    }
}
