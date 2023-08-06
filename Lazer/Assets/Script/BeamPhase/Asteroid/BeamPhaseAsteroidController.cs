using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BeamPhaseAsteroidController : MonoBehaviour
{
    /// <summary>爆風エフェクトコントローラ</summary>
    [SerializeField]
    BoomController boomController;
    
    public void Init()
    {
        this.gameObject.SetActive(true);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 自分を破壊
        Destroy(this.gameObject);

        // 爆風を生成する
        var obj = Instantiate(boomController, this.transform.position, Quaternion.identity);
        obj.Init();

        // 破壊カウントを加算して保持させる
        GameData.breakCount++;
    }
}
