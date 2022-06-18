using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamecampPeli
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private float transitionTime = 1f;
        [SerializeField] private Animator transition;

        public void ChangeScene()
        {
            StartCoroutine(nameof(LoadLevel));
        }

        private IEnumerator LoadLevel()
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(sceneName);
        }
    }
}
