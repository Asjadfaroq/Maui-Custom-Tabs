public class TrendModel
{
    public string Category { get; set; }
    public string Period { get; set; }
    public string TrendDirection { get; set; }
    public double ChangePercentage { get; set; }
    public decimal CurrentAmount { get; set; }
    public decimal PreviousAmount { get; set; }
    public bool TrendBar1Active { get; set; }
    public bool TrendBar2Active { get; set; }
    public bool TrendBar3Active { get; set; }
    public bool TrendBar4Active { get; set; }
    public bool TrendBar5Active { get; set; }
}