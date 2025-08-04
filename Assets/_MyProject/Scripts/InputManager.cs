using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public InputSystem_Actions actions;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (Instance == null)
        {
            GameObject inputManagerObject = new GameObject("InputManager");
            Instance = inputManagerObject.AddComponent<InputManager>();
            DontDestroyOnLoad(inputManagerObject);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        actions = new InputSystem_Actions();
        actions.Enable();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
            actions.Disable();
        }
    }
}
