using System;
using UnityEngine;

namespace User
{
    public class UserInputEventArgs : EventArgs
    {
        public Ray TapRay;

        public UserInputEventArgs(Ray tapRay)
        {
            TapRay = tapRay;
        }
    }
}