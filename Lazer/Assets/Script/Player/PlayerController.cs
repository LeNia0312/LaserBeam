using FUTADA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FUTADA
{
    public class PlayerController : MonoBehaviour
    {
        /// <summary>現在のエネルギー値</summary>
        [SerializeField]
        private float currentEnergy;

        /// <summary>エネルギー貯蓄最大値 </summary>
        [SerializeField]
        private float maxtEnergy;

        /// <summary>移動速度</summary>
        [SerializeField]
        private float moveSpeed;

        /// <summary>太陽オブジェクト</summary>
        [SerializeField]
        private GameObject sunObject;

        /// <summary>プレイヤーModel</summary>
        private PlayerModel model;
        
        /// <summary>中心点からの距離（半径）</summary>
        private float radius;

        /// <summary>現在の角度</summary>
        private float angle = 0f;

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="sun"></param>
        public void Init()
        {
           
            // モデル作成
            model = new PlayerModel(currentEnergy, maxtEnergy, moveSpeed);

            // 食器座標からプレイヤーと太陽の距離を測定
            radius = Vector3.Distance(sunObject.transform.position, this.transform.position);
        }

        /// <summary>
        /// プレイヤー移動
        /// </summary>
        public void PlayerMove(float time, SunVector vec)
        {
            // 角度を更新
            angle += model.GetMoveSpeed() * time * (int)vec;

            // ラジアンに変換
            float radian = angle * Mathf.Deg2Rad;

            // 中心点の位置に円運動を適用して、オブジェクトの位置を更新
            Vector3 newPosition = sunObject.transform.position + new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0f) * radius;
            this.transform.position = newPosition;

            // オブジェクト自体の回転
            float rotationAngle = angle + 90f;
            this.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }
    }
}
