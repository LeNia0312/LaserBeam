using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{

    [SerializeField]
    private Animator anim;

    public void Init()
    {
        this.gameObject.SetActive(true);
        anim.Play("boom_Play", 0, 0);
    }
}
