using System;
using System.Collections;
using System.Collections.Generic;
using _Code;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchButton : MonoBehaviour
{
    [SerializeField] private Button btn;

    private void OnEnable()
    {
        btn.onClick.AddListener(() =>
        {
                SceneManager.LoadScene(1);
        });
    }
}
