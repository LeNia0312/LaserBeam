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

        [SerializeField]
        private BoomController boom;

        /// <summary>プレイヤーModel</summary>
        private PlayerModel model;
        
        /// <summary>中心点からの距離（半径）</summary>
        private float radius;

        /// <summary>現在の角度</summary>
        private float angle = 0f;

        /// <summary>トリガー内にいる</summary>
        private bool isInTrigger = false;

        private float stayTime = 0f;

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


        void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag == "sun")
            {
                stayTime += Time.deltaTime;
                if(stayTime > 0.5f)
                {
                    model.UpdateCurrentEnergy(model.GetCurrentEnergy() + 1);
                    stayTime = 0f;
                }     
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            stayTime = 0f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.tag == "asteroid")
            {
                // アステロイドに当たったら破壊する
                Destroy(collision.gameObject);

                // ばくふー
                var obj = Instantiate(boom, collision.transform.position, Quaternion.identity);
                obj.Init();

                // エネルギーを減らす
                model.UpdateCurrentEnergy(model.GetCurrentEnergy() - 1);

                Debug.Log($"aa");
              
            }
        }

    }
}
