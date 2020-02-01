using System;
using System.ComponentModel;
using System.Reflection;


namespace DiamondInvoiceViewer.Misc_Classes
{
    public static class Enums
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (!(fi is null))
            {
                DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            } else
            {
                return "";
            }
        }
    }
    public enum Allocated
    {
        [Description("Allocated")]
        InStockReorder = 1,

        [Description("Not Allocated")]
        OrderIncrease = 0,
    }

    public enum OrderType
    {
        [Description("in-stock Reorder received via reship through a Diamond Distribution Center.")]
        InStockReorder = 2,

        [Description("Order Increase")]
        OrderIncrease = 3,

        [Description("Advance Reorder filled from extras")]
        AdvanceReorder = 4,

        [Description("Back Order")]
        BackOrder = 5,

        [Description("Credit[s]")]
        Credit = 6,

        [Description("In-stock Reorder sent via direct ship from The Reorder Universe (TRU)/Star System")]
        InStockReorder2 = 7,

        [Description("Initial Order")]
        InitialOrder = 8
    }

    public enum Catagory
    {
        [Description("Comimcs")]
        Comimcs = 0,

        [Description("Magazines")]
        Magazines = 1,

        [Description("CTrades")]
        Trades = 2,

        [Description("Novels")]
        Novels = 3,

        [Description("Games")]
        Games = 4,

        [Description("Cards")]
        Cards = 5,

        [Description("Novelties - Comics")]
        NoveltiesComics = 6,

        [Description("Novelties - Non Comics")]
        NoveltiesNonComics = 7,

        [Description("Apparel")]
        Apparel = 8,

        [Description("Toys & Models")]
        ToysModels = 9,

        [Description("Suplies - Card")]
        SupliesCard = 10,

        [Description("Supplies - Comic")]
        SuppliesComic = 11,

        [Description("Sales Tools")]
        SalesTools = 12,

        [Description("Diamond Publications")]
        DiamondPublications = 13,

        [Description("Posters/Prints/Portfolies/Calendars")]
        PostersPrintsPortfoliesCalendars = 14,

        [Description("Video/Audio/Video Games")]
        VideoAudioVideoGames = 15
    }
}

