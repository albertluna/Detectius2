﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesManager {

    public enum Scene
    {
        Fase_1,
        escena_habitacio,
        Fase_2,
        Fase_3,
        Fase_0,
        menu
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}