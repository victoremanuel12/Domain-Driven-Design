namespace Wpm.Clinic.Domain.ValueObjects
{
    public record DateTimeRange
    {


        public DateTime StartedAt { get; init; }
        public DateTime? EndedAt { get; private set; }

        public TimeSpan? Duration { get; private set; }
        public DateTimeRange(DateTime startedAt)
        {
            StartedAt = startedAt;
        }
        public void SetEndTime(DateTime endedAt)
        {
            ValidDateTime(StartedAt, endedAt);
            EndedAt = endedAt;
            Duration = EndedAt - StartedAt;
        }
        public static implicit operator DateTimeRange(DateTime startedAt)
        {
            return new DateTimeRange(startedAt);
        }
        private void ValidDateTime(DateTime startedAt, DateTime endedAt)
        {
            if (startedAt.Equals(endedAt))
                throw new InvalidDataException("The start can't be equals the end time");
            if (endedAt <= startedAt)
                throw new InvalidDataException("End time must be after start time");
        }
    }

}
