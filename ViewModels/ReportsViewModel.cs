namespace MAUI_Custom_Tabs.ViewModels;

public partial class ReportsViewModel : BaseViewModel
{
    public List<ReportModel> ReportList { get; set; } = new List<ReportModel>();
    public ReportsViewModel()
    {
        PopulateList();
    }
    private void PopulateList()
    {
        ReportList = new List<ReportModel>
{
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 7, 15),
        Description = "Office Supplies - Printer Paper and Ink Cartridges",
        GrandTotal = 127
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 7, 14),
        Description = "Business Lunch - Client Meeting at Downtown Bistro",
        GrandTotal = 82
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 7, 12),
        Description = "Software License - Microsoft Office 365 Annual Subscription",
        GrandTotal = 299
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 7, 10),
        Description = "Travel Expenses - Taxi to Airport",
        GrandTotal = 35
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 7, 8),
        Description = "Equipment Purchase - Wireless Mouse and Keyboard Set",
        GrandTotal = 89.99m
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 7, 5),
        Description = "Marketing Materials - Business Cards and Brochures",
        GrandTotal = 156
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 7, 3),
        Description = "Utility Bill - Internet Service Provider Monthly Fee",
        GrandTotal = 79
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 7, 1),
        Description = "Professional Development - Online Training Course",
        GrandTotal = 199.00m
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 6, 28),
        Description = "Office Rent - Monthly Payment for Co-working Space",
        GrandTotal = 450
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 6, 25),
        Description = "Client Entertainment - Dinner at Italian Restaurant",
        GrandTotal = 134
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 6, 22),
        Description = "Fuel Expenses - Gas Station Fill-up for Business Trip",
        GrandTotal = 58
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 6, 20),
        Description = "Conference Registration - Tech Summit 2024",
        GrandTotal = 485
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 6, 18),
        Description = "Insurance Premium - Business Liability Insurance",
        GrandTotal = 275
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 6, 15),
        Description = "Maintenance Service - Office Equipment Cleaning",
        GrandTotal = 95
    },
    new ReportModel
    {
        ReceiptDate = new DateTime(2024, 6, 15),
        Description = "Consulting Services - IT Security Audit",
        GrandTotal = 750
    }
};
    }
}