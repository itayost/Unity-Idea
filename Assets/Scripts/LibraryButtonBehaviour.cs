using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryButtonBehaviour : MonoBehaviour
{
   public void LoadLibrary()
    {
        SceneManager.LoadScene(1); // index 1 for move to another scene
    }
}
