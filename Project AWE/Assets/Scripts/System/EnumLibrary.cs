namespace EnumLibrary
{
    /*
    public enum DirectorID
    {
        Input   = 1 << 0,
        Game    = 1 << 1,
        Sound   = 1 << 2
    }
    */

    public enum InputID
    {
        Melee       = 0,
        Range       = 1,
        Defend      = 2,
        Jump        = 3,
        Roll        = 4
    }

    public enum ButtonType
    {
        Single      = 0,
        Multi       = 1
    }
}