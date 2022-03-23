using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    public void SetPlayerName()
    {
        DataManager.Instance.SetPlayerName();
        DataManager.Instance.LoadHighScore();
    }
}
