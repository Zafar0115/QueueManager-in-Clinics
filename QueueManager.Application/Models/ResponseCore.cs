namespace QueueManager.Application.Models
{
    public class ResponseCore<T>
    {
        public ResponseCore(bool succeeded, Object errors)
        {
            Succeeded = succeeded;
            Errors = errors;
        }
        public ResponseCore(T result)
        {
            Result = result;
        }
        public bool Succeeded { get; set; } = true;

        public Object Errors { get; set; }

        public T Result { get; set; }

       
    }
}
