namespace WslManager
{
    public sealed class BackgroundWorkerResult<T>
    {
        public BackgroundWorkerResult(bool hasTriggeredByUser, T result)
        {
            HasTriggeredByUser = hasTriggeredByUser;
            Result = result;
        }

        public bool HasTriggeredByUser { get; }

        public T Result { get; }

        public override string ToString() =>
            $"Triggered By User: {HasTriggeredByUser}, Result: {Result}";
    }
}
