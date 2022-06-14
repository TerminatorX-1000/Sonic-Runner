using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static int NumberOfRings;
        public TextMeshProUGUI numberOfRingsText;

        public static int CurrentHealth = 100;
        public Slider healthBar;

        public static bool GameOver;
        public static bool WinLevel;

        public GameObject gameOverPanel;

        public float timer = 0;

        private void Start()
        {
            NumberOfRings = 0;
            GameOver = WinLevel = false;
        }

        // Update is called once per frame
        void Update()
        {
            //CurrentHealth -= 1;
            Debug.Log("Жизнь: " + CurrentHealth);
            Debug.Log("Ring: " + NumberOfRings);
            numberOfRingsText.text = "Кольца: " + NumberOfRings;
            healthBar.value = CurrentHealth;

            //game over
            if (CurrentHealth < 0)
            {
                GameOver = true;
                gameOverPanel.SetActive(true);
                if (CurrentHealth < 0)
                {
                    GameOver = true;
                    gameOverPanel.SetActive(true);
                    CurrentHealth = 100;
                }

                if (FindObjectsOfType<Enemy.Enemy>().Length == 0)
                {
                    //Win Level
                    WinLevel = true;
                    timer += Time.deltaTime;
                    if (timer > 5)
                    {
                        /*int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                        if (nextLevel == 4)
                            SceneManager.LoadScene(0);

                        if(PlayerPrefs.GetInt("ReachedLevel", 1) < nextLevel)
                            PlayerPrefs.SetInt("ReachedLevel", nextLevel);

                        SceneManager.LoadScene(nextLevel);*/

                    }

                }
            }

        }
    }
}