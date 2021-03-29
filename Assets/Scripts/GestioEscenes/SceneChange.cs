﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class SceneChange : MonoBehaviour
{
    public bool isStreet;
    public static int fase = 1;
    public GameObject HUD;
    public Animator transition;

    private void Start()
    {

        HUD = GameObject.Find("HUD");
        lastPhase();
        HUD.GetComponent<HUD_manager>().newScene();
        HUD.SetActive(false);
    }

    private void OnTriggerEnter2D()
    {
        StartCoroutine(LoadLevel());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            HUD.SetActive(true);
        }
        
    }
     
    IEnumerator LoadLevel ()
    {
        transition.SetTrigger("starts");
        yield return new WaitForSeconds(1);
        HUD.SetActive(true);
        if (isStreet)
        {
            ScenesManager.Load(ScenesManager.Scene.escena_habitacio);
        }
        else
        {
            switch (fase)
            {
                case 1:
                    ScenesManager.Load(ScenesManager.Scene.Fase_1);
                    break;
                case 2:
                    ScenesManager.Load(ScenesManager.Scene.Fase_2);
                    break;
                case 3:
                    ScenesManager.Load(ScenesManager.Scene.Fase_3);
                    break;
            }
        }
    }

    //Funcio per canviar de fase
    public void changePhase()
    {
        fase++;
        lastPhase();
    }

    //En l'ultima
    private void lastPhase()
    {
        if(fase>= 3)
        {
            Debug.Log("FASE 3");
            GameObject.Find("canviFase").GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}