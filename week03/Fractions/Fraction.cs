public class Fraction
{
    private int _top_numbers;
    private int _bottom_numbers;

    public Fraction()
    {
        _top_numbers = 1;
        _bottom_numbers = 1;
    }

    public Fraction(int top)
    {
        _top_numbers = top;
        _bottom_numbers = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top_numbers = top;
        _bottom_numbers = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top_numbers}/{_bottom_numbers}";
    }

    public double GetDecimalValue()
    {
        return (double)_top_numbers / _bottom_numbers;
    }
    
    public void SetFractionString(int top, int bottom)
    {
        _top_numbers = top;
        _bottom_numbers = bottom;
    }
}