using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Wave.Enemy;

namespace User
{
    public class UserInput : MonoBehaviour, IPointerDownHandler
    {
        public EventHandler<UserInputEventArgs> OnTap;

        public void OnPointerDown(PointerEventData eventData)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            OnTap?.Invoke(this, new UserInputEventArgs(ray));
        }
    }
}