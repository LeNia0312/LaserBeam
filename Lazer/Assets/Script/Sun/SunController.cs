using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FUTADA
{
    public class SunController : MonoBehaviour
    {
        /// <summary>移動間隔</summary>
        [SerializeField]
        private float moveSpan;

        /// <summary>太陽光パワー</summary>
        [SerializeField]
        private float flamePower;

        /// <summary>移動速度</summary>
        [SerializeField]
        private float moveSpeed;

        /// <summary>太陽光</summary>
        [SerializeField]
        GameObject sunLight;

        /// <summary>中心点からの距離（半径）</summary>
        [SerializeField]
        private float radius = 2f;

        /// <summary>太陽データモデル</summary>
        private SunModel model;

        /// <summary>現在の角度</summary>
        private float angle = 0f;

        /// <summary>移動方向</summary>
        private SunVector vec;


        /// <summary>
        /// 初期化
        /// </summary>
        public void Init()
        {
            // モデル作成
            model = new SunModel(moveSpan, flamePower, moveSpeed);

        }

        /// <summary>
        /// 太陽光移動
        /// </summary>
        public void SunLightMove()
        {

            // 角度を更新
            angle += model.GetMoveSpeed() * Time.deltaTime * (int)vec;

            // ラジアンに変換
            float radian = angle * Mathf.Deg2Rad;

            // 中心点の位置に円運動を適用して、オブジェクトの位置を更新
            Vector3 newPosition = this.transform.position + new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0f) * radius;
            sunLight.transform.position = newPosition;

            // オブジェクト自体の回転
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
