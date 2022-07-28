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

        private readonly string[] combatSceneNames = new string[] {"CombatScenery1", "CombatScenery2", "CombatScenery3"};

        // Function used for buttons etc. to start the transition to another scene
        public void ChangeScene()
        {
            StartCoroutine(nameof(LoadLevel));
        }

        // Enumerator to load another scene with a transition time and a transition
        // animation start trigger
        private IEnumerator LoadLevel()
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(sceneName);
        }
        
        public void ChangeToRandomScene()
        {
            StartCoroutine(nameof(LoadRandomLevel));
        }

        private IEnumerator LoadRandomLevel()
        {
            transition.SetTrigger("Start");

            int randomNumber = Random.Range(0, 3);

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(combatSceneNames[randomNumber]);
        }
    }
}
