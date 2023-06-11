using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("Colonial_graveyard");
    }
}
