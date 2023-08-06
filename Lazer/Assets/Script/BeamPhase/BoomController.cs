using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    // 爆風雨のアニメーター
    [SerializeField]
    private Animator anim;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init()
    {    
        this.gameObject.SetActive(true);

        // 爆破アニメーション"boom_Play"を再生
        anim.Play("boom_Play", 0, 0);
    }
}
