using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextSceneState : State
{
    

    public override void OnEnter()
    {
        base.OnEnter();
        SceneManager.LoadSceneAsync("scn");
    }
}
