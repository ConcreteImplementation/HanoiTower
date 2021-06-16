namespace HanoiTower
{
    interface IGetPins
    {
        int GetFromPin(int move);
        int GetToPin(int move, int from);
    }
}
