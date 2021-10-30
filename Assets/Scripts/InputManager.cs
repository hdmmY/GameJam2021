using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public class InputManager : Singleton<InputManager>
{
    private void Start()
    {
        EnhancedTouchSupport.Enable();
    }

    // private void Update()
    // {
    //     if (Touch.activeFingers.Count == 1)
    //     {
    //         Touch activeTouch = Touch.activeFingers[0].currentTouch;
    //         Debug.Log($"Phase: {activeTouch.phase} | Position: {activeTouch.startScreenPosition}");
    //     }
    // }
}