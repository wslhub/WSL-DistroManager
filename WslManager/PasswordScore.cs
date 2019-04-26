using System;

namespace WslManager
{
    [Serializable]
    public enum PasswordScore : int
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }
}
