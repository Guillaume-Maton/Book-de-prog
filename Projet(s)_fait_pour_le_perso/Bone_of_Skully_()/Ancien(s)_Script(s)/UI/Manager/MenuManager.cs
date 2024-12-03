using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    
    public static GameObject mainMenu, soundMenu, quitMenu, pauseMenu;
    public bool IsInitialized { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            mainMenu = canvas.transform.Find("MenuMenu").gameObject;
            soundMenu = canvas.transform.Find("SoundMenu").gameObject;
            quitMenu = canvas.transform.Find("QuitMenu").gameObject;
            pauseMenu = canvas.transform.Find("PauseMenu").gameObject;
            IsInitialized = true;
        }
    }

    public void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialized)
            Init();

        switch (menu)
        {
            case Menu.MAIN:
                mainMenu.SetActive(true);
                break;

            case Menu.SOUND:
                soundMenu.SetActive(true);
                break;

            case Menu.QUIT:
                quitMenu.SetActive(true);
                break;
            case Menu.PAUSE:
                pauseMenu.SetActive(true);
                break;
        }
        if (callingMenu != null) 
        {
            callingMenu.SetActive(false); 
        }
    }
}