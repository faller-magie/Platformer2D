using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{

    [SerializeField] private GameObject loadingScreen; //Initialization du Canvas de chargement
    [SerializeField] private string SceneToLoad;


    public void LoadScene(string SceneToLoad)
    {
        StartCoroutine(Load(SceneToLoad));
    }

    private IEnumerator Load(string SceneToLoad)
    {
        var Loading_ScreenInstance = Instantiate(loadingScreen);
        DontDestroyOnLoad(Loading_ScreenInstance);
        var loadingAnimator = Loading_ScreenInstance.GetComponent<Animator>();
        var AnimationTime = loadingAnimator.GetCurrentAnimatorStateInfo(0).length;
        var loading = SceneManager.LoadSceneAsync(SceneToLoad);

        loading.allowSceneActivation = false;

        while (!loading.isDone)
        {
            if (loading.progress >= 0.9f)
            {
                loading.allowSceneActivation = true;
                loadingAnimator.SetTrigger("Disparition");
            }

            yield return new WaitForSeconds(AnimationTime);

        }

    }
}
