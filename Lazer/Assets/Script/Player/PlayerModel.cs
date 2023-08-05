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
    }
}
