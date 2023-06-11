using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuStartFading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CanvasGroup>().DOFade(0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
