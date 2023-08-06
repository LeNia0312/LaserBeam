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

        /// <summary>トリガー内にいる</summary>
        private bool isInTrigger = false;

        /// <summary>太陽光にあたっている時間</summary>
        private float stayTime = 0f;

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="sun"></param>
        public void Init()
        {         
            // モデル作成
            model = new PlayerModel(currentEnergy, maxtEnergy, moveSpeed);

            // 初期座標からプレイヤーと太陽の距離を測定
            radius = Vector3.Distance(sunObject.transform.position, this.transform.position);

            // プレイヤーの移動処理初期化１
            PlayerMove(0, 0);
        }

        /// <summary>
        /// プレイヤー移動
        /// </summary>
        public void PlayerMove(float time, SunVector vec)
        {
            // 角度を更新
            angle += model.GetMoveSpeed() * Time.deltaTime * (int)vec;

            // ラジアンに変換
            float radian = angle * Mathf.Deg2Rad;

            // 中心点の位置に円運動を適用して、オブジェクトの位置を更新
            Vector3 newPosition = sunObject.transform.position + new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0f) * radius;
            this.transform.position = newPosition;

            // オブジェクト自体の回転
            float rotationAngle = angle + 90f;
            this.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }

        /// <summary>
        /// 現在のエネルギー量取得
        /// </summary>
        /// <returns></returns>
        public float GetCurrentEnergy()
        {
            return model.GetCurrentEnergy();
        }

        /// <summary>
        /// エネルギー最大値のエネルギー取得
        /// </summary>
        /// <returns></returns>
        public float GetMaxEnergy()
        {
            return maxtEnergy;
        }


        /// <summary>
        /// トリガー内に滞在している時
        /// </summary>
        void OnTriggerStay2D(Collider2D other)
        {
            // 太陽光だったら
            if (other.tag == "sun")
            {
                // 滞在時間をカウント
                stayTime += Time.deltaTime;

                // 0.5秒毎にエネルギーをチャージする
                if(stayTime > 0.5f)
                {
                    model.UpdateCurrentEnergy(model.GetCurrentEnergy() + 1);
                    stayTime = 0f;
                }     
            }
        }

        /// <summary>
        /// トリガーから出た時
        /// </summary>
        void OnTriggerExit2D(Collider2D other)
        {
            // 滞在時間初期化
            stayTime = 0f;
        }

        /// <summary>に
        /// トリガーに当たった時
        /// </summary>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // アステロイドなら
            if (collision.tag == "asteroid")
            {
                // エネルギーを減らす
                model.UpdateCurrentEnergy(model.GetCurrentEnergy() - 5);
            }
        }

    }
}
