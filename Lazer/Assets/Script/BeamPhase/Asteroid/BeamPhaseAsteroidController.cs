using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BeamPhaseAsteroidController : MonoBehaviour
{

    [SerializeField]
    BoomController boomController;
    public void Init()
    {
        this.gameObject.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        var obj = Instantiate(boomController, this.transform.position, Quaternion.identity);
        obj.Init();

        GameData.breakCount++;
    }
}
