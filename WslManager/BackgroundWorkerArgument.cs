using System;

namespace WslManager
{
    public sealed class BackgroundWorkerArgument<T> : EventArgs
    {
        public BackgroundWorkerArgument(bool hasTriggeredByUser, T argument) : base()
        {
            HasTriggeredByUser = hasTriggeredByUser;
            Argument = argument;
        }

        public bool HasTriggeredByUser { get; }

        public T Argument { get; }

        public override string ToString() =>
            $"Triggered By User: {HasTriggeredByUser}, Argument: {Argument}";
    }
}
