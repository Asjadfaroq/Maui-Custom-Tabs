namespace MAUI_Custom_Tabs.ViewModels;

public partial class TrendsViewModel : BaseViewModel
{
    public List<TrendModel> TrendList { get; set; } = new List<TrendModel>();
    public TrendsViewModel()
    {
        PopulateList();
    }

    private void PopulateList()
    {
        TrendList = new List<TrendModel>
        {
        new TrendModel
        {
            Category = "Office Supplies",
            Period = "This Month",
            TrendDirection = "Up",
            ChangePercentage = 24.5,
            CurrentAmount = 1850,
            PreviousAmount = 1486,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = true,
            TrendBar4Active = true,
            TrendBar5Active = false
        },
        new TrendModel
        {
            Category = "Marketing",
            Period = "Q2 2024",
            TrendDirection = "Down",
            ChangePercentage = -15.2,
            CurrentAmount = 3200,
            PreviousAmount = 3775,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = false,
            TrendBar4Active = false,
            TrendBar5Active = false
        },
        new TrendModel
        {
            Category = "Software Licenses",
            Period = "This Quarter",
            TrendDirection = "Up",
            ChangePercentage = 8.7,
            CurrentAmount = 5250,
            PreviousAmount = 4830,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = true,
            TrendBar4Active = false,
            TrendBar5Active = false
        },
        new TrendModel
        {
            Category = "Travel Expenses",
            Period = "This Month",
            TrendDirection = "Stable",
            ChangePercentage = 2.1,
            CurrentAmount = 890,
            PreviousAmount = 872,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = true,
            TrendBar4Active = true,
            TrendBar5Active = true
        },
        new TrendModel
        {
            Category = "Equipment",
            Period = "This Year",
            TrendDirection = "Up",
            ChangePercentage = 42.8,
            CurrentAmount = 12500,
            PreviousAmount = 8750,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = true,
            TrendBar4Active = true,
            TrendBar5Active = true
        },
        new TrendModel
        {
            Category = "Utilities",
            Period = "This Month",
            TrendDirection = "Down",
            ChangePercentage = -6.3,
            CurrentAmount = 425,
            PreviousAmount = 454,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = true,
            TrendBar4Active = false,
            TrendBar5Active = false
        },
        new TrendModel
        {
            Category = "Professional Services",
            Period = "This Quarter",
            TrendDirection = "Up",
            ChangePercentage = 18.9,
            CurrentAmount = 6800,
            PreviousAmount = 5720,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = true,
            TrendBar4Active = true,
            TrendBar5Active = false
        },
        new TrendModel
        {
            Category = "Office Rent",
            Period = "This Year",
            TrendDirection = "Stable",
            ChangePercentage = 0.0,
            CurrentAmount = 18000,
            PreviousAmount = 18000,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = true,
            TrendBar4Active = true,
            TrendBar5Active = true
        },
        new TrendModel
        {
            Category = "Client Entertainment",
            Period = "This Month",
            TrendDirection = "Up",
            ChangePercentage = 35.6,
            CurrentAmount = 780,
            PreviousAmount = 575,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = true,
            TrendBar4Active = false,
            TrendBar5Active = false
        },
        new TrendModel
        {
            Category = "Insurance",
            Period = "This Quarter",
            TrendDirection = "Down",
            ChangePercentage = -3.8,
            CurrentAmount = 1250,
            PreviousAmount = 1300,
            TrendBar1Active = true,
            TrendBar2Active = true,
            TrendBar3Active = true,
            TrendBar4Active = true,
            TrendBar5Active = false
        } };
    }
}