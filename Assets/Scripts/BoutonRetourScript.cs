using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonRetourScript : MonoBehaviour
{
    public void boutonRetour()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
