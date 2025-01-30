namespace DeveloperStore.Api.Domain.VOs;

public class Rating
{
    public int Count { get; set; }
    public double Rate { get; set; }

    public Rating(double rate, int count)
    {
        if(rate < 0 || rate > 5)
            throw new ArgumentOutOfRangeException("Rating must be between 0 and 5.");
        if(count < 0)
            throw new ArgumentOutOfRangeException("Rating count must be non-negative.");
        
        Rate = rate;
        Count = count;
    }
}