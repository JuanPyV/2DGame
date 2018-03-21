using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PausarBoton : MonoBehaviour {

    public static bool JuegoPausado = false;

    public GameObject menuPausa;
    public GameObject pausa;
    public GameObject controles;

    void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Pausa"))
        {
            pausa.SetActive(false);
            controles.SetActive(false);


            if (JuegoPausado)
            {
                Reanudar ();
            }
            else
            {
                Pausar ();
            }

        }
	}

    public void Reanudar ()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;

        pausa.SetActive(true);
        controles.SetActive(true);
    }

    void Pausar ()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
