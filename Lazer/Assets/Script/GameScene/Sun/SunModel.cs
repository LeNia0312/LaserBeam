using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FUTADA
{
    public class SunModel
    {
        /// <summary>ランダム移動周期</summary>
        private float moveSpan;

        /// <summary>照射パワー</summary>
        private float flamePower;

        /// <summary>移動スピード</summary>
        private float moveSpeed;

        /// <summary>移動方向 </summary>
        private SunVector moveVec;
         
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="span">ランダム移動周期</param>
        /// <param name="power">照射パワー</param>
        /// <param name="speed">移動スピード</param>
        public SunModel(float span, float power, float speed)
        {
            this.moveSpan = span;
            this.flamePower = power;
            this.moveSpeed = speed;
        }

        /// <summary>
        /// 移動スピード取得
        /// </summary>
        /// <returns></returns>
        public float GetMoveSpeed()
        {
            return moveSpeed;
        }

        /// <summary>
        /// 照射パワー取得
        /// </summary>
        /// <returns></returns>
        public float GetFlamePower()
        {
            return flamePower;
        }


        /// <summary>
        /// 移動周期取得
        /// </summary>
        /// <returns></returns>
        public float GetMoveSpan()
        {
            return moveSpan;
        }

        /// <summary>
        /// T型のenumの要素をランダムに選択するジェネリックメソッド
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
