using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene("lvl_0");
    }

    public void lvl_1()
    {
        SceneManager.LoadScene("lvl_1");
    }

    public void lvl_2()
    {
        SceneManager.LoadScene("lvl_2");
    }

    public void lvl_3()
    {
        SceneManager.LoadScene("lvl_3");
    }
}
