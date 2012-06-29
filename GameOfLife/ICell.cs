namespace GameOfLife
{
    using System.Collections.Generic;

    public interface ICell
    {
        IGrid Grid { get; }

        bool IsAlive { get; }

        void SetState(IEnumerable<ICell> neighbourStates);
    }
}